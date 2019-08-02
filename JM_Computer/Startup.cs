using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;

namespace JM_Computer
{
    public partial class Startup : Form
    {
        public Startup()
        {
            InitializeComponent();
        }

        private void Startup_Load(object sender, EventArgs e)
        {
            //ListViewItem item = new ListViewItem("hello");
            //item.SubItems.AddRange(new string[]{"wlgc","world",});
            //listView2.Items.Add(item);

             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.listView2.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度  

            for (int i = 0; i < 10; i++)   //添加10行数据  
            {
                ListViewItem lvi = new ListViewItem();

                lvi.ImageIndex = i;     //通过与imageList绑定，显示imageList中第i项图标  

                lvi.Text = "subitem" + i;

                lvi.SubItems.Add("第2列,第" + i + "行");

                lvi.SubItems.Add("第3列,第" + i + "行");

                this.listView2.Items.Add(lvi);
            }

            this.listView2.EndUpdate();  //结束数据处理，UI界面一次性绘制。 
        }
    }
}
