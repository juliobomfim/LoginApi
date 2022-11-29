using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApiJCBomfim.Domain.Model.Input
{
    public class AuthModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public record SignInRequest(string Username, string Password);
        public record UserClaim(string Type, string Value);
    }
}
