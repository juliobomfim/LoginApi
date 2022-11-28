using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApiJCBomfim.Domain.Entities
{
    public class User : Entity
    {
        public User(string username, string password, string name, Profile profile) :this ()
        {
            Username = username;
            Password = password;
            Name = name;
            Profile = profile;
        }

        protected User() : base() { }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public virtual Profile Profile { get; set; }

    }
}
