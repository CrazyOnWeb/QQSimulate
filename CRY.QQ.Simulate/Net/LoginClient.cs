using CRY.Core.Engine;
using CRY.Core.Extensions;
using CRY.Core.Net;
using CRY.QQ.Simulate.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CRY.QQ.Simulate.Net {
    public class LoginClient {
        public LoginClient() {
            _JsEngine = new JSEngine(Assembly.GetExecutingAssembly());
            _Generate = new Generate();
            _HttpClient = new DefaultHttpClient { KeepContext = true };
        }
        private JSEngine _JsEngine;
        private LoginReq _LoginReq;
        private Generate _Generate;
        private DefaultHttpClient _HttpClient;
        private const string LoginUrl = "http://ptlogin2.qq.com/login";
        public LoginRes Send(LoginReq loginReq) {
            _LoginReq = loginReq;
            _HttpClient.Reset();
            _Generate.P = _JsEngine.Execute("c_login_2", "Encryption.getEncryption",
                new string[] { _LoginReq.Pass, _LoginReq.Regmaster.Salt, _LoginReq.Regmaster.Verifycode }).ToString();
            _Generate.Action = _JsEngine.Execute("c_login_2", "Action").ToString();
            _HttpClient.Url = LoginUrl.CombineParam(GetLoginRequestParam());
            return _HttpClient.GET().GetLoginRes();
        }
        private RequestParamCollection GetLoginRequestParam() {
            return new RequestParamCollection() {
            new RequestParam { Key = "u", Value = _LoginReq.QQ},
            new RequestParam { Key = "verifycode", Value = _LoginReq.Regmaster.Verifycode },
            new RequestParam { Key = "pt_vcode_v1", Value = _LoginReq.Regmaster.PTVcode },
            new RequestParam { Key = "pt_verifysession_v1", Value = _LoginReq.Regmaster.Verifysession },
            new RequestParam { Key = "p", Value = _Generate.P },
            new RequestParam { Key = "pt_randsalt", Value = "2" },
            new RequestParam { Key = "u1", Value = "http%3A%2F%2Fimgcache.qq.com%2Fclub%2Flianghao%2FhaomaLoginProxy.html%3Fappid%3D8000202%26daid%3D22%26domain%3Dqq.com%26url%3Dhttp%253A%252F%252Fhaoma.qq.com%252F%26callback%3Dptlogin.trigger" },
            new RequestParam { Key = "ptredirect", Value = "0" },
            new RequestParam { Key = "h", Value = "1" },
            new RequestParam { Key = "t", Value = "1" },
            new RequestParam { Key = "g", Value = "1" },
            new RequestParam { Key = "from_ui", Value = "1" },
            new RequestParam { Key = "ptlang", Value = "2052" },
            new RequestParam { Key = "action", Value =  _Generate.Action },
            new RequestParam { Key = "js_ver", Value = "10197" },
            new RequestParam { Key = "js_type", Value = "1" },
            new RequestParam { Key = "pt_uistyle", Value = "40" },
            new RequestParam { Key = "aid", Value = "8000202" },
            new RequestParam { Key = "daid", Value = "22" }
            };
        }
        private class Generate {
            internal string P { get; set; }
            internal string Action { get; set; }
        }
    }
    public class LoginReq {
        public string QQ { get; set; }
        public string Pass { get; set; }
        public RegmasterRes Regmaster { get; set; }
    }
    public class LoginRes {
        public bool IsLogin { get; set; }
        public CookieCollection SetCookies { get; set; }
    }
}
