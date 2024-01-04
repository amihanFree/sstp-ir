using Event.Data;
using Event.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Event.Pages.Admin
{
    public class GroupModel : PageModel
    {
        private readonly EventDbContext _dbContext;


        public GroupModel(EventDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Group> Allgroups { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Allgroups = await _dbContext.Groups.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int groupId)
        {
            var group = await _dbContext.Groups.FindAsync(groupId);
            if (group != null)
            {
                
                _dbContext.Groups.Remove(group);
                await _dbContext.SaveChangesAsync();
            }
            return Redirect("group");
        }

    }
}
