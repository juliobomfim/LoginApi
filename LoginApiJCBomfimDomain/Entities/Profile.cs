using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApiJCBomfim.Domain.Entities
{
    public class Profile : Entity
    {
        protected Profile() : base()
        {
            Users = new List<User>();
        }

        public Profile(string description) : this()
        {
            Description = description;
        }

        public string Description { get; set; }
        public virtual ICollection<User> Users { get; set; }


    }
}
