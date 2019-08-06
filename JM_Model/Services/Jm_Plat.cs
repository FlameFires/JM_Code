using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JM_Model.Results;
using log4net;

namespace JM_Model.Services
{
    public abstract class Jm_Plat
    {
        ILog log = LogManager.GetLogger(typeof(Jm_Plat));
        public abstract Jm_Result Login();
        public abstract Jm_Result GetPhone(int i);
        public abstract Jm_Result GetInfo();
        public abstract Jm_Result Receive();
        public abstract Jm_Result Black();
        /// <summary>
        /// 释放
        /// </summary>
        /// <returns></returns>
        public abstract Jm_Result Cancel();
    }
}
