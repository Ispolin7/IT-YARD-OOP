using System;
using System.Collections.Generic;
using System.Text;

namespace IT_YARD.Models
{
    /// <summary>
    /// Base mosels class
    /// </summary>
    class EntityBase
    {        

        /// <summary>
        /// Show entity information
        /// </summary>
        public void DisplayEntityInfo()
        {
            Console.WriteLine("Entity information");
        }

        /// <summary>
        /// Validate entity
        /// </summary>
        /// <returns>true if validation success</returns>
        public bool Validate()
        {
            return true;
        }
    }
}
