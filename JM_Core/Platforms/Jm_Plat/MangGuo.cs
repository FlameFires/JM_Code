using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JM_Model;
using JM_Model.Results;
using JM_Util.HttpUtil;

namespace JM_Core.Platforms.Jm_Plat
{
    public class MangGuo : JM_Model.Services.Jm_Plat
    {
        #region 变量
        public string Token { get; private set; }
        #endregion

        // http://www.mango888.top:9000/api.html
        public override JM_Model.Results.Jm_Result Login()
        {
            HttpItem item = new HttpItem()
            {
                URL = "http://www.mangopt.com:9000/doApi/loginIn?name=" + JmMod.Jm_Name + "&password=" + JmMod.Jm_Pwd,
                Method = "GET"
            };
            HttpResult hr = HttpHelper.getHtml(item);
            string html = hr.Html;
            string[] result = hr.Html.Split('|');
            // 1|token(token是重要的返回参数，后面所有的请求都要传这个参数值)
            if (result[0] == "1")
            {
                SuccMod.Jm_token = result[1];
                Token = result[1];
                return new JM_Model.Results.Jm_Result
                {
                    IsSucc = true,
                    Status = JM_Status.success
                };
            }
            else
                return new JM_Model.Results.Jm_Result
                {
                    IsSucc = false,
                    Status = JM_Status.fail,
                    Result = html,
                    ErrMsg = result[1]
                };
        }

        public override JM_Model.Results.Jm_Result GetInfo()
        {
            HttpItem item = new HttpItem()
            {
                URL = "http://www.mangopt.com:9000/doApi/getSummary?token=" + SuccMod.Jm_token,
                Method = "GET"
            };

            throw new NotImplementedException();
        }

        public override JM_Model.Results.Jm_Result Receive()
        {
            throw new NotImplementedException();
        }

        public override Jm_Result GetPhone(int index)
        {
            
            HttpItem item = new HttpItem()
            {
                URL = "http://www.mangopt.com:9000/doApi/getPhone?sid="+CfgMod.ProjectId+"&token="+Token,
                Method = "GET"
            };
            HttpResult hr = HttpHelper.getHtml(item);
            string html = hr.Html;
            string[] result = hr.Html.Split('|');
            // 1|手机号
            if (result[0] == "1")
            {
                Jm_Result jr = new JM_Model.Results.Jm_Result
                {
                    IsSucc = true,
                    Status = JM_Status.success,
                    Result = html,
                    phone = result[1]
                };
                SuccMod.Jm_Phones.Add(index, jr);
                return jr;
            }
            else
                return new JM_Model.Results.Jm_Result
                {
                    IsSucc = false,
                    Status = JM_Status.fail,
                    Result = html
                };
        }

        public override Jm_Result Black()
        {
            throw new NotImplementedException();
        }

        public override Jm_Result Cancel()
        {
            throw new NotImplementedException();
        }
    }
}
