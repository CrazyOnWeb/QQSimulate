using CRY.Core.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRY.QQ.Simulate
{
    public class QzoneHeadRule : MulitCheck {
        //private HttpClientProxy _proxy = new HttpClientProxy();
        private string _url;
        public QzoneHeadRule(IEnumerable<string> qqnums) {
            QQNums = qqnums;
            _url = "http://qlogo3.store.qq.com/qzone/{0}/{0}/100";
        }

        public override bool IsExist(string qqnum) {
            //_proxy.Client.GET(string.Format(_url, qqnum)).GetString();
            //if (_proxy.Client.ResponseHeaders["X-ErrNo"] != null) {
            //    return false;
            //}
            return true;
        }
    }
}
