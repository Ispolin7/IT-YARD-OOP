using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT_YARD.Common;

namespace IT_YARD.Models
{
    /// <summary>
    /// Users model
    /// </summary>
    class User : EntityBase
    {
        /// <summary>
        /// Class properties
        /// </summary>
        public string Username { get; }
        public string Password { get; }

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public User(string username, string password) 
        {
            this.Username = username;
            this.Password = Cryptographer.Encrypt(password);
        }

        /// <summary>
        /// Show User information
        /// </summary>
        public new void DisplayEntityInfo()
        {
            Console.WriteLine($"Username - {this.Username} and password - {this.Password}");
        }

        /// <summary>
        /// Decrypte user password and show it
        /// </summary>
        public void DisplayPassword()
        {
            Console.WriteLine($"Password {this.Username} - {Cryptographer.Decrypt(this.Password)}");
        }

        /// <summary>
        /// Validation user properties
        /// </summary>
        /// <returns>true if everything is correct</returns>
        public new bool Validate()
        {
            return !(
                string.IsNullOrWhiteSpace(this.Username) &&
                string.IsNullOrWhiteSpace(Cryptographer.Decrypt(this.Password))
            );
        }
    }
}
