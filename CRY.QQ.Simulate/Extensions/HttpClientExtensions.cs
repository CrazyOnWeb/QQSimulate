using CRY.Core.Net;
using CRY.Core.Extensions;
using CRY.QQ.Simulate.Login;
using CRY.QQ.Simulate.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CRY.QQ.Simulate.Extensions {
    internal static class HttpClientExtensions {
        public static RegmasterRes GetRemasterRes(this IHttpClient client) {
            var context = client.GetString();
            var contextSplited = context.Split(',');
            var verifycode = contextSplited[1].Trim('\'');
            var mustHaveVerifycode = verifycode.Length != 4;
            if (mustHaveVerifycode) {
                return new RegmasterRes {
                    PTVcode = "1",
                    MustHaveVerifycode = mustHaveVerifycode,
                    Salt = contextSplited[2].Trim('\''),
                    Verifysession = contextSplited[1].Trim('\'')
                };
            }
            return new RegmasterRes {
                PTVcode = "0",
                MustHaveVerifycode = mustHaveVerifycode,
                Verifycode = contextSplited[1].Trim('\''),
                Salt = contextSplited[2].Trim('\''),
                Verifysession = contextSplited[3].Trim('\'')
            };
        }

        public static ImageReq GetImageReq(this IHttpClient client) {
            var context = client.GetString();
            var startIndex = context.IndexOf("{");
            var endIndex = context.IndexOf("}");
            return context.Substring(startIndex, endIndex - (startIndex - 1)).DeserializeObject<ImageReq>();
        }

        public static string GetVsig(this IHttpClient client) {
            var context = client.GetString();
            var sig = context.DeserializeObject<Sig>();
            return sig.Vsig;
        }

        public static VerifyCodeRes GetVerifyCode(this IHttpClient client) {
            var context = client.GetString();
            var sig = context.DeserializeObject<VerifyCodeRes>();

            return new VerifyCodeRes {
                Ticket = sig.Ticket,
                Randstr = sig.Randstr
            };
        }
        public static LoginRes GetLoginRes(this IHttpClient client) {
            var loginRes = new LoginRes();
            var res = client.GetResponse();
            if (string.IsNullOrEmpty(res.Cookies.GetValueOf("skey"))) {
                return loginRes;
            }
            loginRes.IsLogin = true;
            loginRes.SetCookies = res.Cookies;
            return loginRes;
        }
    }
}
