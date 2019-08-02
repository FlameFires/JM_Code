using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM_Util.TypeHelper
{
    public class ObjectHelper
    {
        public static T Get<T>(string val) where T : class
        {
            if (string.IsNullOrEmpty(val)) return default(T);
            return val as T;
        }
    }
}
