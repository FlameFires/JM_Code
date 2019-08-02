using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;

namespace JM_Computer.Error
{
    public partial class ErrorShow : Form
    {
        ILog log = LogManager.GetLogger(typeof(ErrorShow));

        public bool IsEntity { get;private set; }
        public ErrorShow():this("")
        {

        }
        public ErrorShow(string text)
        {
            InitializeComponent();
            IsEntity = true;
            this.label1.Text = text;
        }

        public void SetMessage(string str)
        {
            this.label1.Text = str;
        }

        private void ErrorShow_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void ErrorShow_Load(object sender, EventArgs e)
        {
        
        }
    }
}
