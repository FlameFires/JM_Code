using System.Configuration;
using JM_Util.TypeHelper;

namespace JM_Util.Config
{
    public class ConfigHelper
    {
        public static string GetVal(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static void SetVal(string key, string val)
        {
            ConfigurationManager.AppSettings.Set(key,val);
        }

        public static T GetVal<T>(string key) where T : class
	    {
            return ObjectHelper.Get<T>(key);
	    }
    }
}
