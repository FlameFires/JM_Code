using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JM_Core.Platforms.Jm_Plat;
using JM_Model.Services;

namespace JM_Core
{
    public class Platform
    {
        public Platform() { }
        public Platform(string jmname, string dmname, string dlname)
        {
            this.jmplat = Get_jmplat(jmname);
            this.dmplat = Get_dmplat(dmname);
            //this.dlplat = Get_dlplat(dlname);
        }

        public Jm_Plat jmplat
        {
            get;
            private set;
        }
        public Dm_Plat dmplat
        {
            get;
            private set;
        }
        public Dl_Plat dlplat { get; private set; }

        public Jm_Plat Get_jmplat(string name)
        {
            jmplat = Jm_Provider.GetPlat(name);
            return jmplat;
        }

        public Dm_Plat Get_dmplat(string name)
        {
            dmplat = Platforms.Dm_Plat.Dm_Provider.GetPlat(name);
            return dmplat;
        }

        //public static Dl_Plat Get_dlplat(string name)
        //{
        //    if (jmplat == null) jmplat = Jm_Provider.GetPlat(name);
        //    return jmplat;
        //}
    }
}
