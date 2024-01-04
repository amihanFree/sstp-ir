using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Event.Pages.Admin
{
    public class UsersModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UsersModel(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public class UserWithRoles
        {
            public IdentityUser User { get; set; }
            public IList<string> Roles { get; set;}
        }
        /*public List<IdentityUser> Users { get; set; }*/
        public List<UserWithRoles> UsersWithRoles { get; set; }
        public async Task OnGetAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            UsersWithRoles = new List<UserWithRoles>();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                UsersWithRoles.Add(new UserWithRoles { User = user, Roles = roles });
            }
        }


        public async Task<IActionResult> OnPostAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return Page();
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                /*if (result.Succeeded)
                {
                    // User successfully deleted
               
                }
                else
                {
                    // Handle the error
                }*/
            }

            return Redirect("users");
        }


    }
}
