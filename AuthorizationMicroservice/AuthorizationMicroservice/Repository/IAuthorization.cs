using AuthorizationMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationMicroservice.Repository
{
    public interface IAuthorization
    {
        public string CreateToken(string username, string password);
    }
}
