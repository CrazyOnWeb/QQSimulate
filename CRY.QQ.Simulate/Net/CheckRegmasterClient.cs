using CRY.Core.Extensions;
using CRY.Core.Net;
using CRY.QQ.Simulate.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRY.QQ.Simulate.Net {
    public class CheckRegmasterClient {
        public CheckRegmasterClient() {
            _HttpClient = new DefaultHttpClient();
        }
        private DefaultHttpClient _HttpClient;
        private const string CheckRegmasterUrl = "http://check.ptlogin2.qq.com/check";
        private RegmasterReq _RegmasterReq;
        public RegmasterRes Send(RegmasterReq req) {
            _RegmasterReq = req;
            _HttpClient.Reset();
            _HttpClient.Url = CheckRegmasterUrl.CombineParam(GetCheckRegmasterRequestParam());
            return _HttpClient.GET().GetRemasterRes();
        }

        private RequestParamCollection GetCheckRegmasterRequestParam() {
            return new RequestParamCollection() {
            new RequestParam { Key = "regmaster", Value = "" },
            new RequestParam { Key = "pt_tea", Value = "2" },
            new RequestParam { Key = "pt_vcode", Value = "1" },
            new RequestParam { Key = "uin", Value = _RegmasterReq.QQ},
            new RequestParam { Key = "appid", Value = "8000202" },
            new RequestParam { Key = "js_ver", Value = "10197" },
            new RequestParam { Key = "js_type", Value = "1" },
            new RequestParam { Key = "u1", Value = "http%3A%2F%2Fimgcache.qq.com%2Fclub%2Flianghao%2FhaomaLoginProxy.html%3Fappid%3D8000202%26daid%3D22%26domain%3Dqq.com%26url%3Dhttp%253A%252F%252Fhaoma.qq.com%252F%26callback%3Dptlogin.trigger" },
            new RequestParam { Key = "r", Value = _RegmasterReq.R },
            new RequestParam { Key = "pt_uistyle", Value = "40" }
            };
        }
    }
    public class RegmasterReq {
        public string QQ { get; set; }
        public string R { get; set; }
    }
    public class RegmasterRes {
        public bool MustHaveVerifycode { get; internal set; }
        public string Verifycode { get; internal set; }
        public string Salt { get; internal set; }
        public string Verifysession { get; internal set; }
        public string PTVcode { get; set; }
    }
}
