using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationMicroservice.Service
{
    public interface IService
    {
        string GetToken(string username, string password);
    }
}
