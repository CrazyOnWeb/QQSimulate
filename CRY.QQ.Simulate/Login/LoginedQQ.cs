using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CRY.QQ.Simulate.Login
{
    public class LoginedQQ
    {
        public string NickName { get;  set; }
        public string QQ { get;  set; }
        public IEnumerable<Cookie> Cookie { get; set; }
    }
}
