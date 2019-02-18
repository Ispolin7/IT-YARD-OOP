using System;
using IT_YARD.Common;
using System.Runtime.Serialization;

namespace IT_YARD.Models
{
    /// <summary>
    /// Users model
    /// </summary>
    public class User : EntityBase
    {
        /// <summary>
        /// Class properties
        /// </summary>
        public string Username { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public User(string username, string password) : base()
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
        public override bool Validate()
        {
            return !(
                string.IsNullOrWhiteSpace(this.Username) &&
                string.IsNullOrWhiteSpace(Cryptographer.Decrypt(this.Password))
            );
        }
    }
}
