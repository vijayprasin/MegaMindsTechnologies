using System.ComponentModel.DataAnnotations;

namespace MegaMinds.Models.Domain
{
    public class Register
    {
        public Guid Id { get; set; }

        
        public string Name { get; set; }

            
        public string Email { get; set; }

          
        public string Phone { get; set; }

        public string Address { get; set; }

        public string State { get; set; }

        public string City { get; set; }
        

    }
}
