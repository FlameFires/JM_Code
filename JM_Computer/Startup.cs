using System;
using System.Drawing;
using System.Threading;
using CCWin;
using JM_Core;
using JM_Core.Platforms.Dm_Plat;
using JM_Core.Platforms.Jm_Plat;
using JM_Model;
using JM_Model.Results;
using JM_Util.Config;

namespace JM_Computer
{
    public partial class Startup : CCSkinMain
    {
        public Startup()
        {
            InitializeComponent();
        }
        #region 变量
        private Module m_base = null;

        #endregion

        private void Startup_Load(object sender, EventArgs e)
        {
            InitConfig();
            m_base = new Module(this,skinDataGridView1);
            rtbShow("hello", Color.Red);
            Thread.Sleep(100);
            string[] strs = { "架構", "男", "喲發的克里夫拉動機關綠卡" };
            for (int i = 0; i < 20; i++)
            {
                dgvAdd(strs);
            }
        }

        public void Init()
        {
            ConfigHelper.GetVal("");
        }

        System.Timers.Timer xintiao = new System.Timers.Timer(1000);

        /// <summary>
        /// 初始化配置信息
        /// </summary>
        public void InitConfig()
        {
            cbxJm.Items.AddRange(Jm_Provider.JmPlats);
            cbxJm.SelectedIndex = 0;
            cbxDm.Items.AddRange(Dm_Provider.DmPlats);
            cbxDm.SelectedIndex = 0;
            cbxDl.SelectedIndex = 0;
        }
        /// <summary>
        /// 登录赋值
        /// </summary>
        public void InitRightTop()
        {
            JmMod.Jm_Plat = this.cbxJm.SelectedItem.ToString();
            JmMod.Jm_Name = this.tbxJmN.Text.Trim();
            JmMod.Jm_Pwd = this.tbxJmP.Text.Trim();
            //JmMod.Dm_Plat = ;
        }

        #region 窗体事件
        // jm 登录
        private void btnJMLogin_Click(object sender, EventArgs e)
        {
            if (btnJMLogin.Text == "退出")
                btnJMLogin.Text = "登录";
            else
            {
                InitRightTop();
                Jm_Result r = m_base.JM_Login();
                if (r.IsSucc)
                {
                    rtbShow("登录成功");
                    btnJMLogin.Text = "退出";
                }
                else
                {
                    if (r.Status == JM_Status.accpwdNull)
                        return;
                    else
                        rtbShow("登录失败\r\n错误信息：" + r.ErrMsg, Color.Red);
                }
            }
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        private void Startup_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            // 保存配置
            this.SaveConfig();
        }
        public void SaveConfig()
        {
            ConfigHelper.SetVal("ProjectId", "");
            ConfigHelper.SetVal("ThreadNum", "");
            ConfigHelper.SetVal("", "");
        }
        #endregion


        #region UI层显示数据
        public void dgvAdd(string[] vals)
        {
            if (this.skinDataGridView1.InvokeRequired)
            {
                Action<string[]> act = dgvAdd;
                this.skinDataGridView1.Invoke(act, vals);
            }
            else
            {
                int index = this.skinDataGridView1.Rows.Add();
                int colNum = this.skinDataGridView1.ColumnCount;
                this.skinDataGridView1.Rows[index].Cells[0].Value = index + 1;
                for (int i = 1; i < colNum; i++)
                {
                    this.skinDataGridView1.Rows[index].Cells[i].Value = vals[i - 1];
                }
            }
        }
        public void rtbShow(string text)
        {
            if (this.rtfRichTextBox1.InvokeRequired)
            {
                rtfRichTextBox1.BeginInvoke(new Action(() =>
                {
                    this.rtfRichTextBox1.Text += text + "\r\n";
                }));
            }
            else
                this.rtfRichTextBox1.Text += text + "\r\n";
        }
        public void rtbShow(string text, Color color)
        {
            string content = text + "\r\n";
            if (this.rtfRichTextBox1.InvokeRequired)
            {
                Action<string, Color> ac = rtbShow;
                this.rtfRichTextBox1.Invoke(ac, text, color);
            }
            else
            {
                this.rtfRichTextBox1.Text += content;
                int i = rtfRichTextBox1.Text.LastIndexOf(text);
                rtfRichTextBox1.Select(i, content.Length - 2);
                rtfRichTextBox1.SelectionColor = color;
                //rtfRichTextBox1.SelectionFont = new Font();
                rtfRichTextBox1.ScrollToCaret();
            }
        }
        #endregion
    }
}
