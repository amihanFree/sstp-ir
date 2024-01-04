using Event.Data;
using Event.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Event.Areas.Identity.Pages.Account.Manage
{
    public class UserEventDataModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly EventDbContext _dbContext;
        public UserEventDataModel(UserManager<IdentityUser> userManager, EventDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }
        public List<Group> FormData { get; set; }
        public async Task OnGetAsync()
        {
            var userEmail = User.Identity.Name;
            FormData = await _dbContext.Groups.Where(g => g.GroupEmail == userEmail).ToListAsync();
        }
    }
}
