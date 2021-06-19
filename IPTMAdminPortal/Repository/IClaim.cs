using IPTMAdminPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace IPTMAdminPortal.Repository
{
    interface IClaim
    {
        int ClaimCost(Claim claim);
    }
}
