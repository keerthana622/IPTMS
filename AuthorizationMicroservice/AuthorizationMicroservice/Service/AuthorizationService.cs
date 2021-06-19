using AuthorizationMicroservice.Repository;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationMicroservice.Service
{
    public class AuthorizationService : IService
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IAuthorization _repo;
        public AuthorizationService(IAuthorization repo)
        {
            this._repo = repo;
        }
        public string GetToken(string username, string password)
        {
            log.Info("Generating token...");
            try
            {
                string token = _repo.CreateToken(username, password);
                if (token == null)
                {
                    log.Error("Invalid credentials");
                    return null;
                }
                log.Info("Token generated");
                return token;
            }
            catch (Exception ex)
            {
                log.Error($"Token Generation failed due to some error.\n {ex.Message}");
                return null;
            }
        }
    }
}
