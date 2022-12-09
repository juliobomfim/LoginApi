using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LoginApiJCBomfim.Domain.Model.Input
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public Guid Profile { get; set; }
    }
}
