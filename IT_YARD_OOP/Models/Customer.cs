using System;
using System.Collections.Generic;
using System.Text;

namespace IT_YARD_OOP.Models
{
    class Customer : EntityBase
    {
        public string Name { get; }
        public Customer()
        : this(string.Empty)
        {
        }
        public Customer(string name)
        {
            this.Name = name;
            AddressList = new List<Address>();
        }
        public List<Address> AddressList;
        public int CustomerType;
        public static int InstanceCount;
        public string LastName;
        public string EmailAddress;
        public new void DisplayEntityInfo()
        {
            Console.WriteLine($"Customer Id - {this.Id}, first name - {this.Name}, last name - {this.LastName}");
        }
        public new bool Validate()
        {
            var isValid = true;
            if (string.IsNullOrWhiteSpace(LastName))
            {
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(EmailAddress))
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
