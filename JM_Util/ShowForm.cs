using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JM_Util
{
    public class ShowForm
    {

        public static void ShowTipForm(string text,string caption,MessageBoxButtons buttons,MessageBoxIcon icon,MessageBoxDefaultButton defaultButton)
        {
            MessageBox.Show(text,caption,buttons,icon,defaultButton);
        }
    }
}
