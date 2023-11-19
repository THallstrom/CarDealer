using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Models
{
    public class CustomerUpdateForm
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set;} = null!;
        public string? Email { get; set; } = null;
        public string? Phone { get; set; } = null;
        public string? StreetName { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
    }
}
