using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM_Core.Platforms.Jm_Plat
{
    public class Jm_Provider
    {
        public static JM_Model.Services.Jm_Plat GetPlat(string jm)
        {
            JM_Model.Services.Jm_Plat jmp = null;
            switch (jm)
            {
                case "火云":
                    jmp = new HuoYun();
                    break;
                case "芒果云":
                    jmp = new MangGuo();
                    break;
            }
            return jmp;
        }

        public static string[] JmPlats = new string[] { 
            "芒果云",
            "火云",
            ""
        };
    }
}
