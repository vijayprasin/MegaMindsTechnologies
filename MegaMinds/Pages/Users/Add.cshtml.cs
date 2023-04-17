using MegaMinds.Data;
using MegaMinds.Models.Domain;
using MegaMinds.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MegaMinds.Pages.User
{
    public class AddModel : PageModel
    {
        private readonly MegaMindsDbContext dbContext;

        public AddModel(MegaMindsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        [BindProperty]
        public AddUserViewModel AddUserRequest { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            //convert view model to domain model

            var registerDomainModel = new Register
            {
                Name = AddUserRequest.Name,
                Email = AddUserRequest.Email,
                Phone = AddUserRequest.Phone,
                Address = AddUserRequest.Address,
                City = AddUserRequest.City,
                State = AddUserRequest.State
            };

            dbContext.Registers.Add(registerDomainModel);
            dbContext.SaveChanges();

            ViewData["Message"] = "User Created Succesfully!";
        }
    }
}
