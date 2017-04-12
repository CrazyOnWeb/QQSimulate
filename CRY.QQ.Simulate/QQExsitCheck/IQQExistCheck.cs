using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRY.QQ.Simulate
{
    interface IQQExistCheck {
        bool IsExist(string qqnum);
    }

    public class QQExistInfo {
        public Dictionary<string, QQInfo> InfoDic { get; set; }
    }

    public class QQInfo : QQInfoBase {
        public bool IsExist { get; set; }
        public string PrintInfo { get; set; }
    }

    public abstract class QQInfoBase {
        public string Name { get; set; }
    }
}
