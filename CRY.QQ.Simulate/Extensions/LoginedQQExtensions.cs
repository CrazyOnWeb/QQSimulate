using CRY.Core.Engine;
using CRY.Core.Extensions;
using CRY.Core.Net;
using CRY.QQ.Simulate.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CRY.QQ.Simulate.Extensions
{
    public static class LoginedQQExtensions
    {
        public static string FindQQ(this LoginedQQ loginedQQ,string qq)
        {
            DefaultHttpClient client = new DefaultHttpClient();
            JSEngine engine = new JSEngine(Assembly.GetExecutingAssembly());
            var cookieCollction = loginedQQ.Cookie.ToCookieCollection();
            var ldw = engine.Execute("c_login_2", "getCSRFToken", cookieCollction.GetValueOf("Skey")).ToString();
            client.Context.Cookies = cookieCollction;
            client.Url = "http://cgi.find.qq.com/qqfind/buddy/search_v3";
            client.PostingData.Add("keyword", qq);
            client.PostingData.Add("online", "1");
            client.PostingData.Add("ldw", ldw);
            return client.POST().GetString();
        }
    }
}
