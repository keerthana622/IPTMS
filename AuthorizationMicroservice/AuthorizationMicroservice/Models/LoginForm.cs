using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationMicroservice.Models
{
    public class LoginForm
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
