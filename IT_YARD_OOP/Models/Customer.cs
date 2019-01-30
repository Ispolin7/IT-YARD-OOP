using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace IT_YARD.Models
{
    [DataContract]
    class Customer : EntityBase
    {
        /// <summary>
        /// Customer Types List
        /// </summary>
        public enum CustomersTypes
        {
            retail,
            wholesale
        }

        /// <summary>
        /// Customer properties
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string EmailAddress { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public int CustomerType { get; set; }
        // TODO Stack!
        //{ 
        //    get
        //    {
        //        return CustomerType;
        //    }
        //    set
        //    {
        //        if (Enum.IsDefined(typeof(CustomersTypes), value))
        //        {
        //            Console.WriteLine("Debug");
        //            CustomerType = value;
        //        }
        //        // default type
        //        else
        //        {
        //            CustomerType = 0;
        //        }
        //    }
        //}

        /// <summary>
        /// Customer address list
        /// </summary>
        [DataMember]
        public List<Guid> AddressList = new List<Guid>();

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
        public Customer(string name, string lastName, string email, int type, int id) : base()
        {
            this.Name = name;
            this.LastName = lastName;
            this.EmailAddress = email;
            //TODO Stack Owerflow Exception!!!!!!!!!!!!!!!
            this.CustomerType = type;
            this.UserId = id;
        }

        /// <summary>
        /// Show customer information
        /// </summary>
        public new void DisplayEntityInfo()
        {
            Console.WriteLine($"Full name - {this.FullName},  type - {/*(CustomersTypes)*/this.CustomerType}");
        }

        /// <summary>
        /// Validate customer properties
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            return !(
                string.IsNullOrWhiteSpace(Name) ||
                string.IsNullOrWhiteSpace(LastName) ||
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
                AddressList.Add(newAddress.Id);
                return true;
            }
            return false;           
        }
    }
}
