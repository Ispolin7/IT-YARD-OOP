using System;
using System.Collections.Generic;
using System.Text;

namespace IT_YARD_OOP.Models
{
    class EntityBase
    {
        public Guid Id { get; }

        public EntityBase()
        {
            this.Id = new Guid();
        }
        public virtual void DisplayEntityInfo()
        {
            Console.WriteLine("Entity information");
        }
        public virtual bool Validate()
        {
            return true;
        }
    }
}
