using IPTMPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPTMPortal.Repository
{
    interface IPatient
    {
        void CreatePlan(Patient patient);
    }
}
