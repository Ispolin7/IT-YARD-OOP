using System;
using System.Collections.Generic;
using System.Text;
using IT_YARD.Repositories;

namespace IT_YARD.Models
{
    class Customer : EntityBase
    {
        /// <summary>
        /// Customer Types List
        /// </summary>
        public enum CustomerTypes 
        {
            retail,
            wholesale
        }

        /// <summary>
        /// Customer properties
        /// </summary>
        public string Name { get; }
        public string LastName { get; }
        public string EmailAddress { get; }
        public int UserId { get; }
        public int CustomerType
        {
            get
            {
                return CustomerType;
            }
            set
            {
                if(Enum.IsDefined(typeof(CustomerTypes), value))
                {
                    CustomerType = value;
                }
                // default type
                else
                {
                    CustomerType = 0;
                }
            }
        }

        /// <summary>
        /// Customer address list
        /// </summary>
        public List<Address> AddressList = new List<Address>();

        /// <summary>
        /// Я хз что это)))) !!!!!!!!!!!!!!
        /// </summary>
        public static int InstanceCount { get; set; }

        /// <summary>
        /// Virtual fields
        /// </summary>
        public string FullName
        {
            get
            {
                return this.Name + " " + this.LastName;
            }
        }

        /// <summary>
        /// Customer constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="type"></param>
        /// <param name="id"></param>
        public Customer(string name, string lastName, string email, int type, int id)
        {
            this.Name = name;
            this.LastName = lastName;
            this.EmailAddress = email;
            //TODO Stack Owerflow Exception!!!!!!!!!!!!!!!
            //this.CustomerType = type;
            this.UserId = id;
        }

        /// <summary>
        /// Show customer information
        /// </summary>
        public new void DisplayEntityInfo()
        {
            Console.WriteLine($"Full name - {this.FullName},  type - {(CustomerTypes)this.CustomerType}");
        }

        /// <summary>
        /// Validate customer properties
        /// </summary>
        /// <returns></returns>
        public new bool Validate()
        {
            return !(
                string.IsNullOrWhiteSpace(Name) &&
                string.IsNullOrWhiteSpace(LastName) && 
                string.IsNullOrWhiteSpace(EmailAddress)
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
                AddressList.Add(newAddress);
                return true;
            }
            return false;           
        }
    }
}
