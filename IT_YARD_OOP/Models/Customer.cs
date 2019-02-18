using System;
using IT_YARD.Common;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace IT_YARD.Models
{
    public class Customer : EntityBase
    {
        /// <summary>
        /// Customer properties
        /// </summary>
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }
       

        /// <summary>
        /// Customer address list
        /// </summary>
        public List<Guid> AddressList = new List<Guid>();


        /// <summary>
        /// Virtual fields
        /// </summary>
        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

        /// <summary>
        /// list for related products
        /// </summary>
        public IEnumerable<Order> Orders { get; set;}

        /// <summary>
        /// Customer constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        public Customer(string name, string lastName, string email, int gender) : base()
        {
            this.FirstName = name;
            this.LastName = lastName;
            this.Email = email;
            this.Gender = gender;
        }

        public Customer() { }

        /// <summary>
        /// Show customer information
        /// </summary>
        public new void DisplayEntityInfo()
        {
            Console.WriteLine($"Full name - {this.FullName}");
        }

        /// <summary>
        /// Validate customer properties
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            return !(
                string.IsNullOrWhiteSpace(this.FirstName) ||
                string.IsNullOrWhiteSpace(this.LastName) ||
                string.IsNullOrWhiteSpace(this.Email) ||
                !Enum.IsDefined(typeof(GenderEnum), this.Gender)
                );
        }

        /// <summary>
        /// Add new address to customer address list
        /// </summary>
        /// <param name="newAddress"></param>
        /// <returns>true if address added</returns>
        public bool AddAddress(Address newAddress)
        {
            if(newAddress.Validate())
            {
                AddressList.Add(newAddress.Id);
                return true;
            }
            return false;           
        }
    }
}
