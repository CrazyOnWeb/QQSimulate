using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRY.Core.Net;

namespace CRY.QQ.Simulate
{
    public class HaomaRule : MulitCheck {
        //private HttpClientProxy _proxy = new HttpClientProxy();
        private string _url;
        public HaomaRule(IEnumerable<string> qqnums) {
            QQNums = qqnums;
            _url = "http://hm.vip.qq.com/cgi-bin/HaomaSearch.fcgi?cmd=Search&num={0}";
        }
        public override bool IsExist(string qqNum) {
            //var json = _proxy.Client.GET(string.Format(_url, qqNum)).GetString();
            //var haoma = JsonConvert.DeserializeObject<Haoma>(json);
            //if (haoma != null
            //    && haoma.Data != null
            //    && haoma.Data.Data != null
            //    && qqNum == haoma.Data.Data.First().Num)
            //    return true;
            return false;
        }
    }
    public class Haoma {
        public HaomaFirst Data { get; set; }
    }
    public class HaomaFirst {
        public HaomaTwo[] Data { get; set; }
    }
    public class HaomaTwo {
        public string Num { get; set; }
    }
}
