using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM_Model.Platforms.Jm_Plat
{
    public class Jm_Provider
    {
        public static Services.Jm_Plat GetPlat(string jm)
        {
            Services.Jm_Plat jmp = null;
            switch (jm)
            {
                case "火云":
                    jmp = new HuoYun();
                    break;
            }
            return jmp;
        }
    }
}
