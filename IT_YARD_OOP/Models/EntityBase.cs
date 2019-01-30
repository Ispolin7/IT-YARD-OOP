using System;
using System.Runtime.Serialization;

namespace IT_YARD.Models
{
    /// <summary>
    /// Base mosels class
    /// </summary>
    [DataContract]
    class EntityBase
    {
        [DataMember]
        public Guid Id{ get; set; }
        /// <summary>
        /// Show entity information
        /// </summary>
        public virtual void DisplayEntityInfo()
        {
            Console.WriteLine($"ID - {Id}");
        }

        /// <summary>
        /// Validate entity
        /// </summary>
        /// <returns>true if validation success</returns>
        public virtual bool Validate()
        {
            return true;
        }

        /// <summary>
        /// Base constructor
        /// </summary>
        public EntityBase()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
