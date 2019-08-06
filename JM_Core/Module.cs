using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin.SkinControl;
using JM_Model;
using JM_Model.Results;

namespace JM_Core
{
    public class Module
    {
        static Module() { }

        public Module(Form win,SkinDataGridView _dgv)
        {
            this.wins = win;
            this.dgv = _dgv;
            InitCondition();
        }

        public Form wins { get; set; }
        public Platform p { get; set; }
        public SkinDataGridView dgv { get; set; }


        /// <summary>
        /// 初始化
        /// </summary>
        void InitCondition()
        {
            p = new Platform();
        }

        #region 登录方法
        /// <summary>
        /// 登录
        /// </summary>
        public Jm_Result JM_Login()
        {
            if (string.IsNullOrEmpty(JmMod.Jm_Name) || string.IsNullOrEmpty(JmMod.Jm_Pwd))
            {
                MessageBox.Show("账号和密码不能为空");
                return new Jm_Result { Status = JM_Status.accpwdNull,IsSucc =false };
            }
            p.Get_jmplat(JmMod.Jm_Plat);
            return p.jmplat.Login();
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
        #endregion

        public void Start()
        {

        }

        public void Execute(Action ac)
        {
            if (ac != null)
                ac();
            else
                MessageBox.Show("登录方法为空！");
        }
    }
}
