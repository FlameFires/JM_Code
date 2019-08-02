using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JM_Util.TypeHelper;

namespace JM_Util.Config
{
    public class MainConfig
    {

        public delegate void DelegateWriteLog(Exception ex);

        public static bool IsDesignMode
        {
            get
            {
#if Computer
                bool returnFlag = LicenseManager.UsageMode == LicenseUsageMode.Designtime;
                return returnFlag;
#else
                return false;
#endif

            }
        }

        public static T GetObject<T>(string configName, params object[] paras)
            where T : class
        {
            string className = GetConfig(configName);
            object obj = ClassHelper.GetObject(className, paras);
            return obj as T;
        }
        public static object GetFormHardLogin()
        {
            string className = GetConfig("RunHardLogin");
            if (string.IsNullOrEmpty(className))
            {
                return null;
            }
            object obj = ClassHelper.GetObject("Piaost.Client.Soft.HardLogin , Piaost.Client.Core");
            return obj;
        }

        public static string GetConfig(string name)
        {
            if (m_Config.Count == 0)
            {
                return Config.ConfigHelper.GetVal(name);
            }
            return m_Config.ContainsKey(name) ? m_Config[name] : string.Empty;
        }

        public static Form GetFormLogin()
        {
            return GetObject<Form>("RunLogin");
        }

        public static Form GetFormMain()
        {
            return GetObject<Form>("FrmMain",new object[]{  });
        }

        public static string ApplicationPath
        {
            get
            {
                string vFile = Assembly.GetExecutingAssembly().GetName().CodeBase;
                string vPath = Path.GetDirectoryName(vFile);
                string vTag = "file:\\";
                if (vPath.StartsWith(vTag))
                {
                    vPath = vPath.Substring(vTag.Length);
                }
                return vPath;
            }
        }

        public static string ApplicationName
        {
            get
            {
                return AppDomain.CurrentDomain.FriendlyName;
            }
        }

        public static string ApplicationRootPath
        {
            get
            {
                string vApplicationPath = ApplicationPath;
                string[] vPaths = vApplicationPath.Split('\\', '/');
                string vRoot = vPaths[0] + '\\';
                return vRoot;
            }
        }

        public static string DesktopPath
        {
            get
            {
#if CE
                string vDesktopPath = @"\Windows\桌面\"; //得到桌面文件夹
#else
                string vDesktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "\\";//得到桌面文件夹
#endif
                return vDesktopPath;
            }
        }

        #region 读取写入配置文件
        private static Dictionary<string, string> m_Config = new Dictionary<string, string>();




        #endregion
    }
}
