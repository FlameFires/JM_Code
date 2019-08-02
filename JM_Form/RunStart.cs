using System;
using System.Text;
using System.Windows.Forms;
using JM_Computer.Error;
using JM_Util.Config;
using log4net;

namespace JM_Form
{
    public class RunStart
    {
        static ILog log = LogManager.GetLogger(typeof(Program));


        public static void Run()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // 处理全局异常
            RunStart.ExceptionControl();
            bool createdNew;
            using (System.Threading.Mutex mu = new System.Threading.Mutex(true, typeof(Program).ToString(), out createdNew))
            {
                if (createdNew)
                {
                    Form main = MainConfig.GetFormMain();
                    Application.Run(main);
                }
                else
                {
                    MessageBox.Show("应用程序已启动");
                }
            }
        }


        /// <summary>
        /// 异常处理方法
        /// </summary>
        public static void ExceptionControl()
        {
            //设置应用程序处理异常方式：ThreadException处理  
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常  
            Application.ThreadException += (sender, e) =>
            {
                log.ErrorFormat("UI线程异常：{0}", e.Exception.Message);
                var str = GetExceptionMsg(e.Exception, e.ToString());
                log.ErrorFormat("UI线程异常信息：{0}", str);
                var messageForm = new ErrorShow();
                messageForm.SetMessage(str);
                var flg = messageForm.IsEntity;
                if (flg) return;
                messageForm.ShowDialog();
            };
            //处理非UI线程异常  
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                log.ErrorFormat("多线程异常：{0}", (e.ExceptionObject as Exception).Message);
                var str = GetExceptionMsg(e.ExceptionObject as Exception, e.ToString());
                log.ErrorFormat("多线程异常信息：{0}", str);
                var messageForm = new ErrorShow();
                messageForm.SetMessage(str);
                var flg = messageForm.IsEntity;
                if (flg) return;
                messageForm.ShowDialog();
            };

        }

        private static object ErrorShow(string p)
        {
            throw new NotImplementedException();
        }
        /// <summary>  
        /// 生成自定义异常消息  
        /// </summary>  
        /// <param name="ex">异常对象</param>  
        /// <param name="backStr">备用异常消息：当ex为null时有效</param>  
        /// <returns>异常字符串文本</returns>  
        private static string GetExceptionMsg(Exception ex, string backStr)
        {
            var sb = new StringBuilder();
            if (ex == null)
            {
                sb.AppendLine("【errmsg】：" + backStr);
            }
            else
            {
                if (ex.GetType().Name.ToLower() == "exception")
                {
                    return ex.Message;
                }
                sb.AppendLine("【msgtime】：" + DateTime.Now);
                sb.AppendLine("【msgtype】：" + ex.GetType().Name);
                sb.AppendLine("【callstack】：" + ex.Message);
                sb.AppendLine("【untreated】：" + ex.StackTrace);
            }
            return sb.ToString();
        }
    }
}
