using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;

namespace JM_Form
{
    static class Program
    {
        static ILog log = LogManager.GetLogger(typeof(Program));
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            RunStart.Run();
        }
    }
}
