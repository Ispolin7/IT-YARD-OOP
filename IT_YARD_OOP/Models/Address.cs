using System;
using System.Text;
using System.Reflection;
using System.Runtime.Serialization;

namespace IT_YARD.Models
{
    /// <summary>
    /// Delivery address model
    /// </summary>
    [DataContract]
    class Address : EntityBase
    {
        /// <summary>
        /// Class properties
        /// </summary>
        [DataMember]
        public int AddressType { get; set; }
        [DataMember]
        public string StreetLine1 { get; set; }
        [DataMember]
        public string StreetLine2 { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
        [DataMember]
        public string Country { get; set; }

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
        public Address(int type, string street1, string street2, string city, string state, string code, string country) : base()
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
        public override bool Validate()
        {
            return true/*!string.IsNullOrWhiteSpace(this.PostalCode)*/;
        }
    }
}
