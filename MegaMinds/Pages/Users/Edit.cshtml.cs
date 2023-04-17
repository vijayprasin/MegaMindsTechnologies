using MegaMinds.Data;
using MegaMinds.Models.Domain;
using MegaMinds.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MegaMinds.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly MegaMindsDbContext dbContext;

        [BindProperty]

        public EditUserViewModel EditUserViewModel { get; set; }

        public EditModel(MegaMindsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        public void OnGet(Guid id)
        {
            var register = dbContext.Registers.Find(id);

            if(register!=null)
            {
                //convert domain model to view model
                EditUserViewModel = new EditUserViewModel()
                {
                    Id = register.Id,
                    Name = register.Name,
                    Email = register.Email,
                    Phone = register.Phone,
                    Address = register.Address,
                    City = register.City,
                    State = register.State
                };
            }
        }

        public void OnPostUpdate()
        {
            if (EditUserViewModel != null)
            {
                var existingRegister = dbContext.Registers.Find(EditUserViewModel.Id);

                if (existingRegister != null)
                {

                    //Convert ViewModel to DomainModel
                    existingRegister.Name = EditUserViewModel.Name;
                    existingRegister.Email = EditUserViewModel.Email;
                    existingRegister.Phone = EditUserViewModel.Phone;
                    existingRegister.Address = EditUserViewModel.Address;
                    existingRegister.City = EditUserViewModel.City;
                    existingRegister.State = EditUserViewModel.State;

                    
                    dbContext.SaveChanges();
                    ViewData["Message"] = "User Updated Successfully!";

                }
            }
        }

        public IActionResult OnPostDelete()
        {
            var existingRegister = dbContext.Registers.Find(EditUserViewModel.Id);

            if (existingRegister != null)
            {
                dbContext.Registers.Remove(existingRegister);
                dbContext.SaveChanges();

                return RedirectToPage("/Users/List");
            }

            return Page();
        }

    }
}
