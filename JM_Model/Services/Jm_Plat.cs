using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JM_Model.Results;

namespace JM_Model.Services
{
    public abstract class Jm_Plat
    {
        public abstract Jm_Result Login();
        public abstract Jm_Result GetInfo();
        public abstract Jm_Result Receive();
    }
}
