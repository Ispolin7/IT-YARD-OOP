using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace IT_YARD.Models
{
    /// <summary>
    /// Base mosels class
    /// </summary>
    [DataContract]
    public abstract class EntityBase
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
        public abstract bool Validate();

        public virtual bool AppendRelated()
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
