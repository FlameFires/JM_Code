using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JM_Model.Results;

namespace JM_Model
{
    public class SuccMod
    {
        public static string Jm_token { get; set; }
        public static Dictionary<int, Jm_Result> Jm_Phones { get; set; }
        public static string Dm_token { get; set; }
        public static string Dl_token { get; set; }
    }
}
