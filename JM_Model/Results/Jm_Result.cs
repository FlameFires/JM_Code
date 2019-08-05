using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM_Model.Results
{
    public class Jm_Result
    {
        public bool IsSucc { get; set; }
        public JM_Status Status { get; set; }
        public string Result { get; set; }
    }

    public enum JM_Status{
        success =200,
        fail = -1,
    }
}
