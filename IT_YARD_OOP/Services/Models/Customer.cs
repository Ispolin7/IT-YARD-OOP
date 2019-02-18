using IT_YARD.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace IT_YARD.Services.Models
{
    public class Customer
    {
        public Customer(IT_YARD.Models.Customer customer, IEnumerable<IT_YARD.Models.Order> orders)
        {
            Id = customer.Id;
            FullName = customer.FullName;
            Email = customer.Email;
            Age = customer.Age;
            Enum.GetName(typeof(GenderEnum), this.Gender);
            Orders = orders;
        }

        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public GenderEnum Gender { get; set; } 
        public IEnumerable<IT_YARD.Models.Order> Orders { get; set; }
    }


}
