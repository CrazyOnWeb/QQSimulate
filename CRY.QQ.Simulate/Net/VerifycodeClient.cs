using CRY.Core.Extensions;
using CRY.Core.Net;
using CRY.QQ.Simulate.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRY.Core.Engine;
using System.Reflection;

namespace CRY.QQ.Simulate.Net {
    public class VerifycodeClient {
        public VerifycodeClient() {
            _HttpClient = new DefaultHttpClient();
        }
        private DefaultHttpClient _HttpClient;
        private const string GetTypeUrl = "http://captcha.qq.com/cap_union_new_gettype";
        //private const string GetVSig = "http://captcha.qq.com/cap_union_new_show";
        private const string GetImage = "http://captcha.qq.com/cap_union_new_getcapbysig";
        private const string GetSig = "http://captcha.qq.com/cap_union_new_getsig";
        private const string VerifyURL = "http://captcha.qq.com/cap_union_new_verify";
        private VerifyCodeReq _VerifyCodeReq;
        private ImageReq _ImageReq;

        public byte[] GetVerifyCodeImage(VerifyCodeReq req) {
            _VerifyCodeReq = req;
            _HttpClient.Reset();
            _HttpClient.Url = GetTypeUrl.CombineParam(GetTypeParam());
            _ImageReq = _HttpClient.GET().GetImageReq();
            _ImageReq.Cap_cd = req.Cap_cd;
            _ImageReq.UID = req.UID;
            _HttpClient.Url = GetSig.CombineParam(GetSigParam());
            _ImageReq.Vsig = _HttpClient.GET().GetVsig();
            _ImageReq.Rand = (new Random().NextDouble()).ToString();
            _HttpClient.Url = GetImage.CombineParam(GetImageParam());
            return _HttpClient.GET().GetBytes();
        }

        public VerifyCodeRes Verify(VerifyCodeReq req) {
            _VerifyCodeReq = req;
            var jsEngine = new JSEngine(Assembly.GetExecutingAssembly());
            var now = jsEngine.Execute("TDC", "TDC.now").ToString();
            _HttpClient.Reset();
            _HttpClient.Url = VerifyURL.CombineParam(GetVerifyParam(now));
            foreach (var item in GetImageParam()) {
                var requestParam = (RequestParam)item;
                if (requestParam.Key != "Random" && requestParam.Key != "ischartype" && requestParam.Key != "rand") {
                    _HttpClient.PostingData.Add(requestParam.Key, requestParam.Value);
                }
            }
            _HttpClient.PostingData.Add("subcapclass", "0");
            _HttpClient.PostingData.Add("cdata", "0");

            var begintime = now.Substring(0, now.Length - 3);
            var endtime = (Convert.ToInt64(now) + 30000).ToString();
            endtime = endtime.Substring(0, endtime.Length - 3);
            var focusBlurin = (Convert.ToInt64(now) + 16000).ToString();
            var focusBlurout = focusBlurin;
            var json = "{\"mousemove\":[{\"t\":7,\"x\":206,\"y\":0},{\"t\":8,\"x\":203,\"y\":0},{\"t\":9,\"x\":204,\"y\":65},{\"t\":10,\"x\":240,\"y\":66},{\"t\":11,\"x\":240,\"y\":67}],\"mouseclick\":[{\"t\":8,\"x\":184,\"y\":76}],\"keyvalue\":[9,9,10,10],\"user_Agent\":\"chrome/56.0.2924.87\",\"resolutionx\":1280,\"resolutiony\":1024,\"winSize\":[300,152],\"url\":\"http://captcha.qq.com/cap_union_new_show\",\"refer\":\"http://xui.ptlogin2.qq.com/cgi-bin/xlogin\",\"begintime\":" + begintime + ",\"endtime\":" + endtime + ",\"platform\":1,\"os\":\"Win7\",\"keyboards\":4,\"flash\":1,\"pluginNum\":5,\"index\":1,\"ptcz\":\"\",\"tokenid\":262531355,\"btokenid\":null,\"tokents\":1487908779,\"ips\":{\"in\":[\"192.168.119.44\"]},\"colorDepth\":24,\"cookieEnabled\":true,\"timezone\":9,\"wDelta\":0,\"keyUpCnt\":4,\"keyUpValue\":[9,10,10,10],\"mouseUpValue\":[{\"t\":8,\"x\":184,\"y\":76},{\"t\":11,\"x\":235,\"y\":119}],\"mouseUpCnt\":2,\"mouseDownValue\":[{\"t\":8,\"x\":184,\"y\":74},{\"t\":11,\"x\":235,\"y\":119}],\"mouseDownCnt\":2,\"orientation\":[{\"x\":0,\"y\":0,\"z\":0}],\"bSimutor\":0,\"focusBlur\":{\"in\":[" + focusBlurin + "],\"out\":[" + focusBlurout + "],\"t\":[3136]},\"fVersion\":24,\"charSet\":\"UTF-8\",\"resizeCnt\":0,\"errors\":[],\"screenInfo\":\"1280-1024-984-24-*-*-*\",\"elapsed\":8000,\"clientType\":\"2\",\"trycnt\":1,\"refreshcnt\":0}               ";
            var collect = jsEngine.Execute("TDC", "TDC.getData", json).ToString();
            _HttpClient.PostingData.Add("collect", collect);
            _HttpClient.PostingData.Add("ans", req.VerifyCode);
            return _HttpClient.POST().GetVerifyCode();
        }

        private RequestParamCollection GetTypeParam() {
            return new RequestParamCollection() {
            new RequestParam { Key = "aid", Value = "8000202" },
            new RequestParam { Key = "asig", Value = "" },
            new RequestParam { Key = "captype", Value = "" },
            new RequestParam { Key = "protocol", Value ="http"},
            new RequestParam { Key = "clientype", Value = "2" },
            new RequestParam { Key = "disturblevel", Value = "" },
            new RequestParam { Key = "apptype", Value = "2" },
            new RequestParam { Key = "curenv", Value = "inner"},
            new RequestParam { Key = "uid", Value = _VerifyCodeReq.UID },
            new RequestParam { Key = "cap_cd", Value = _VerifyCodeReq.Cap_cd },
            new RequestParam { Key = "lang", Value = "2052" },
            new RequestParam { Key = "callback", Value = "_aq_429365" }
            };
        }

        private RequestParamCollection GetSigParam() {
            return new RequestParamCollection() {
            new RequestParam { Key = "aid", Value = "8000202" },
            new RequestParam { Key = "asig", Value = "" },
            new RequestParam { Key = "captype", Value = "" },
            new RequestParam { Key = "protocol", Value ="http"},
            new RequestParam { Key = "clientype", Value = "2" },
            new RequestParam { Key = "disturblevel", Value = "" },
            new RequestParam { Key = "apptype", Value = "2" },
            new RequestParam { Key = "curenv", Value = "inner"},
            new RequestParam { Key = "sess", Value = _ImageReq.Sess},
            new RequestParam { Key = "noBorder", Value = "noborder"},
            new RequestParam { Key = "showtype", Value = "embed"},
            new RequestParam { Key = "uid", Value = _ImageReq.UID },
            new RequestParam { Key = "cap_cd", Value = _ImageReq.Cap_cd },
            new RequestParam { Key = "lang", Value = "2052" },
            new RequestParam { Key = "rnd", Value = "" },
            new RequestParam { Key = "rand", Value = _ImageReq.Rand },
            };
        }

        private RequestParamCollection GetImageParam() {
            return new RequestParamCollection() {
            new RequestParam { Key = "aid", Value = "8000202" },
            new RequestParam { Key = "asig", Value = "" },
            new RequestParam { Key = "captype", Value = "" },
            new RequestParam { Key = "protocol", Value ="http"},
            new RequestParam { Key = "clientype", Value = "2" },
            new RequestParam { Key = "disturblevel", Value = "" },
            new RequestParam { Key = "apptype", Value = "2" },
            new RequestParam { Key = "curenv", Value = "inner"},
            new RequestParam { Key = "sess", Value = _ImageReq.Sess},
            new RequestParam { Key = "noBorder", Value = "noborder"},
            new RequestParam { Key = "showtype", Value = "embed"},
            new RequestParam { Key = "uid", Value = _ImageReq.UID },
            new RequestParam { Key = "cap_cd", Value = _ImageReq.Cap_cd },
            new RequestParam { Key = "lang", Value = "2052" },
            new RequestParam { Key = "rnd", Value = "139565" },
            new RequestParam { Key = "rand", Value = _ImageReq.Rand },
            new RequestParam { Key = "vsig", Value = _ImageReq.Vsig },
            new RequestParam { Key = "ischartype", Value = "1" },
            };
        }

        private RequestParamCollection GetVerifyParam(string now) {
            return new RequestParamCollection() {
                new RequestParam { Key = "random", Value =  now}
            };
        }

    }
    public class ImageReq {
        public string UID { get; set; }
        public string Cap_cd { get; set; }
        public string Sess { get; set; }

        public string Rand { get; set; }

        public string Vsig { get; set; }
    }

    public class Sig {
        public string Vsig { get; set; }
        public string Ques { get; set; }
    }
    public class VerifyCodeReq {
        public string UID { get; set; }
        public string Cap_cd { get; set; }
        public string VerifyCode { get; set; }
    }

    public class VerifyCodeRes {
        public string Ticket { get; set; }

        public string Randstr { get; set; }
    }
}
