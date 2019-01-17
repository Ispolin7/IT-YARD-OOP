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
        public int CustomerType { get; set; }
        public static int InstanceCount { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        public string FullName
        {
            get
            {
                return this.Name + " " + this.LastName;
            }
        }

        public new void DisplayEntityInfo()
        {
            Console.WriteLine($"Customer Id - {this.Id}, first name - {this.Name}, last name - {this.LastName}");
        }
        public new bool Validate()
        {
            return !(string.IsNullOrWhiteSpace(LastName) || string.IsNullOrWhiteSpace(EmailAddress));
        }
    }
}
