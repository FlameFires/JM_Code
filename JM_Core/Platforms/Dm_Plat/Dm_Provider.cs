using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM_Core.Platforms.Dm_Plat
{
    public class Dm_Provider
    {
        public static JM_Model.Services.Dm_Plat GetPlat(string jm)
        {
            JM_Model.Services.Dm_Plat dmp = null;
            switch (jm)
            {
                case "联众":
                    // jmp = new HuoYun();
                    break;
            }
            return dmp;
        }

        public static string[] DmPlats = new string[] { 
            "",
            "",
            ""
        };
    }
}
