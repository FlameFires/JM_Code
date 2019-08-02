using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JM_Util.HttpUtil
{
    static public  class CookieHelper
    {

        //写入IE COOKIE
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool InternetSetCookie(string lpszUrlName, string lbszCookieName, string lpszCookieData);
        //读取IE COOKIE
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool InternetGetCookie(string lpszUrlName, string lbszCookieName, StringBuilder lpszCookieData, ref int lpdwSize);
        //获取错误信息
        [DllImport("kernel32.dll")]
        public static extern Int32 GetLastError();
        //
        /// <summary>
        /// 用IE 浏览器打开 URL 可带 COOKIE
        /// </summary>
        /// <param name="url"></param>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static bool OpenIE(string url, string cookie = "")
        {
            bool flag = true;
            try
            {
                SetIECookie(cookie, url);
                Process.Start("iexplore.exe", url);
            }
            catch (Exception e)
            {
                flag = false;
                Debug.WriteLine(e.ToString());
            }

            //
            return flag;
        }

        /// <summary>
        /// 设置 IE 的cookie
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="url">域名</param>
        /// <returns></returns>
        public static bool SetIECookie(string cookie, string url)
        {
            //
            bool flag = true;
            try
            {
                if (string.IsNullOrWhiteSpace(cookie)) return false;

                string GTM_time = "Sun,22-Feb-2099 00:00:00 GMT";
                Regex r = new Regex(@"https?://.*?\.(com|net|cn)");
                Match m = r.Match(url);
                if (!m.Success) return false;
                url = m.Value;
                //
                r = new Regex(@"[a-zA-Z]+?\.(com|net|cn)");
                m = r.Match(url);
                if (!m.Success) return false;
                string domain = m.Value;


                Debug.WriteLine(url);
                Debug.WriteLine(domain);

                string[] cookie_arr = cookie.Split(';');
                foreach (string cookie_str in cookie_arr)
                {
                    //
                    string[] cookie_str_arr = cookie_str.Split('=');
                    if (cookie_str_arr.Length != 2) continue;

                    if (string.IsNullOrWhiteSpace(cookie_str_arr[1])) continue;
                    //
                    //
                    //一定要 加上  有效期 和 domain
                    string cookie_content = cookie_str_arr[1].Trim() + "; expires=" + GTM_time + "; path=/" + "; domain=" + domain;
                    flag = InternetSetCookie(url, cookie_str_arr[0].Trim(), cookie_content);
                }
            }
            catch (Exception e)
            {
                flag = false;
                Debug.WriteLine(e.ToString());
            }
            return flag;
        }


        //
        //
        /// <summary>
        /// 更新合并 cookie
        /// </summary>
        /// <param name="_cookie_New"></param>
        /// <param name="_cookie_old"></param>
        /// <returns>返回合并更新后的cookie</returns>
        static public string fixCookie(string _cookie_New, string _cookie_old)
        {

            if (string.IsNullOrWhiteSpace(_cookie_New))//新的是空的
            {
                return _cookie_old;//返回老的
            }
            if (string.IsNullOrWhiteSpace(_cookie_old))//老的是空的
            {
                return _cookie_New;//返回新的
            }

            _cookie_New = _cookie_New.Replace(";;", ";");
            _cookie_old = _cookie_old.Replace(";;", ";");

            string[] list_New = _cookie_old.ToString().Split(';');

            foreach (string item in list_New)
            {
                //排除重复项
                string[] tmp = item.Trim().Split('=');
                if (tmp.Length == 2)
                {
                    if (!_cookie_New.Contains(tmp[0]))
                    {
                        
                        _cookie_New += ";" + item;
                    }

                }


            }

            return _cookie_New;
        }

        /// <summary>
        /// 删除指定cookei
        /// </summary>
        /// <param name="cook_name"></param>
        /// <returns></returns>
        static public string CookieDelete(string cookie, string cook_name)
        {
            if (string.IsNullOrWhiteSpace(cookie)) return "";

            string[] list_New = cookie.ToString().Split(';');

            string new_cookie = cookie;

            foreach (string item in list_New)
            {
                //排除重复项
                string[] tmp = item.Trim().Split('=');
                if (tmp.Length == 2)
                {
                    if (tmp[0].Equals(cook_name))
                    {
                        new_cookie = new_cookie.Replace(item + ';', "");
                    }

                }


            }

            return new_cookie;

        }

        /// <summary>
        /// 获取指定cookei值
        /// </summary>
        /// <param name="cook_name"></param>
        /// <returns></returns>
        static public string GetCookValue(string cookie, string cook_name)
        {
            if (string.IsNullOrWhiteSpace(cookie)) return "";

            string[] list_New = cookie.ToString().Split(';');

            string new_cookie = cookie;

            foreach (string item in list_New)
            {
                //排除重复项
                string[] tmp = item.Trim().Split('=');
                if (tmp.Length == 2)
                {
                    if (tmp[0].Equals(cook_name))
                    {
                        return tmp[1];
                    }

                }


            }

            return "";

        }


        /// <summary>
        /// 处理COOKIE 比如删除一些没用的东西
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        static public string handlerCookie(string cookie)
        {
            
            if (string.IsNullOrWhiteSpace(cookie)) return "";
           
            cookie = cookie.Replace(" path=/;", "").Replace(" path=/,", "").Replace("HttpOnly,", "").Replace(" HttpOnly", "");

            cookie = cookie.Replace(";,", ";");

            cookie = cookie.Trim();

            if (cookie.Substring(cookie.Length - 1, 1) == ";")
            {
                cookie = cookie.Substring(0, cookie.Length - 1);
            }

           
            return cookie;
        }

        /// <summary>
        /// 查询是否有cookname值
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="cook_name"></param>
        /// <returns></returns>
        static public bool HasCookie(string cookie, string cook_name)
        {
            if (string.IsNullOrWhiteSpace(cookie)) return false;
            string[] list_New = cookie.ToString().Split(';');

            foreach (string item in list_New)
            {
                //排除重复项
                string[] tmp = item.Trim().Split('=');

                if (tmp[0] == cook_name)
                {
                    return true;
                }
            }

            return false;
        }





    }
}
