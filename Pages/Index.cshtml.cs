using Event.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Event.Pages
{
    public class IndexModel : PageModel
    {

        private readonly EventDbContext dbContext;

        public IndexModel(EventDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /*[BindProperty]
        public AddUserViewModel AddUserRequest { get; set; }*/




        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync(IFormFile file)
        {
            /*if (file != null && file.Length > 0)
            {
                var uniqueIdentifier = DateTime.Now.Ticks.ToString();
                var newFileName = $"{uniqueIdentifier}_{file.FileName}";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload", newFileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var userDomainModel = new User
                {
                    Name = AddUserRequest.Name,
                    Email = AddUserRequest.Email,
                    Phone = AddUserRequest.Phone,
                    File = newFileName,
                    Created = DateTime.Now
                };
                dbContext.Users.Add(userDomainModel);
                dbContext.SaveChanges();
                ViewData["message"] = "فرم شما با موفقیت بارگذاری شد";
            }*/
            /*   else { ViewData["message"] = "لطفا اطلاعات فرم را با دقت پر کنید"; }*/
            return Page();
        }



    }
}