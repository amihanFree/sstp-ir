using Event.Data;
using Event.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Event.Pages.Register_idea
{
    [Authorize]
    public class RegisteringModel : PageModel
    {
        private readonly EventDbContext dbContext;
        public RegisteringModel(EventDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            this.dbContext = dbContext;
            _userManager = userManager;
        }

        [BindProperty]
        public Group Group { get; set; }

        
            private readonly UserManager<IdentityUser> _userManager;
            public string UserEmail { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
                
                var user = await _userManager.GetUserAsync(User);
                UserEmail = user.Email;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["error"] = "لطفا اطلاعات فرم را با دقت پر کنید";

                return Page();
            }
            
            var userForm = await _userManager.GetUserAsync(User);
            Group.GroupEmail = userForm.Email;
            if (Group.file != null && Group.file.Length > 0)
            {
                    var uniqueIdentifier = DateTime.Now.Ticks.ToString();
                    var newFileName = $"{uniqueIdentifier}_{Group.file.FileName}";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload", newFileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Group.file.CopyToAsync(stream);
                        Group.GroupFile = newFileName;
                    }

            }
            
            dbContext.Groups.Add(Group);
                await dbContext.SaveChangesAsync();
                ViewData["message"] = "فرم شما با موفقیت بارگذاری شد";
                ModelState.Clear();
                return Redirect("~/Identity/Account/Manage/UserEventData");
        
            }

    }
}
