using System;
using System.Collections.Generic;
using System.Text;

namespace IT_YARD.Models
{
    /// <summary>
    /// Delivery address model
    /// </summary>
    class Address : EntityBase
    {   
        /// <summary>
        /// Class properties
        /// </summary>
        public int AddressType { get; }
        public string StreetLine1 { get; }
        public string StreetLine2 { get; }
        public string City { get; }
        public string State { get; }
        public string PostalCode { get; }
        public string Country { get; }

        /// <summary>
        /// Address constructor
        /// </summary>
        /// <param name="type"></param>
        /// <param name="street1"></param>
        /// <param name="street2"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="code"></param>
        /// <param name="country"></param>
        public Address(int type, string street1, string street2, string city, string state, string code, string country)
        {
            this.AddressType = type;
            this.StreetLine1 = street1;
            this.StreetLine2 = street2;
            this.City = city;
            this.State = state;
            this.PostalCode = code;
            this.Country = country;
        }

        /// <summary>
        /// Display address information
        /// </summary>
        public new void DisplayEntityInfo()
        {
            Console.WriteLine($"{this.PostalCode} {this.Country} {this.State} {this.City} {this.StreetLine1}");
        }

        /// <summary>
        /// Validate Address properties
        /// </summary>
        /// <returns>true if everything is correct</returns>
        public new bool Validate()
        {
            return !(
                //this.AddressType < 0 &&
                //string.IsNullOrWhiteSpace(this.StreetLine1) &&
                //string.IsNullOrWhiteSpace(this.StreetLine2) &&
                //string.IsNullOrWhiteSpace(this.City) &&
                //string.IsNullOrWhiteSpace(this.State) &&
                //string.IsNullOrWhiteSpace(this.PostalCode) &&
                //string.IsNullOrWhiteSpace(this.Country)
                false
            );
        }
    }
}
