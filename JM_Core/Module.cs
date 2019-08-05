using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JM_Model;

namespace JM_Core
{
    public class Module
    {
        static Module(){}

        public Module()
        {
            InitCondition();
        }

        public Form wins { get; set; }
        public 

        /// <summary>
        /// 初始化
        /// </summary>
        static void InitCondition()
        {

        }

        /// <summary>
        /// 登录
        /// </summary>
        public void JM_Login()
        {
            if(string.IsNullOrEmpty(JmMod.Jm_Name)) MessageBox.Show("账号不能为空");
            if(string.IsNullOrEmpty(JmMod.Jm_Pwd)) MessageBox.Show("密码不能为空");
            Execute(delegate() { });
        }

        public void DM_Login()
        {
            if (string.IsNullOrEmpty(JmMod.Dm_Name)) MessageBox.Show("账号不能为空");
            if (string.IsNullOrEmpty(JmMod.Dm_Pwd)) MessageBox.Show("密码不能为空");
            Execute(delegate() { });
        }

        public void DL_Login()
        {
            if (string.IsNullOrEmpty(JmMod.Dl_Name)) MessageBox.Show("账号不能为空");
            if (string.IsNullOrEmpty(JmMod.Dl_Pwd)) MessageBox.Show("密码不能为空");
            Execute(delegate() { });
        }

        public void Execute(Action ac)
        {
            if (ac != null)
                ac();
            else
                return;
        }
    }
}
