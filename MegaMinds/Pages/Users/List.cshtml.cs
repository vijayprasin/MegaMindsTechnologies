using MegaMinds.Data;
using MegaMinds.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MegaMinds.Pages.Users
{
    public class ListModel : PageModel
    {
        private readonly MegaMindsDbContext dbContext;

        public List<Models.Domain.Register> Registers { get; set; }

        public ListModel(MegaMindsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        public void OnGet()
        {
             Registers = dbContext.Registers.ToList();

        }
    }
}
