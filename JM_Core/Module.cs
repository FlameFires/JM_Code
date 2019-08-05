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

        /// <summary>
        /// 初始化
        /// </summary>
        static void InitCondition()
        {

        }

        /// <summary>
        /// 登录
        /// </summary>
        public void Login()
        {
            if(string.IsNullOrEmpty(JmMod.Jm_Name)) MessageBox.Show("账号不能为空");
            if(string.IsNullOrEmpty(JmMod.Jm_Pwd)) MessageBox.Show("密码不能为空");

        }
    }
}
