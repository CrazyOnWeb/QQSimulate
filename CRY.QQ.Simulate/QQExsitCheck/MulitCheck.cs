using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRY.QQ.Simulate
{
    public class MulitCheck : IQQExistCheck {
        public IEnumerable<string> QQNums { get; protected set; }
        public virtual bool IsExist(string qqnum) { return false; }
        public QQExistInfo IsExistMulti(IEnumerable<string> qqnums) {
            var qqExistInfo = new QQExistInfo();
            qqExistInfo.InfoDic = new Dictionary<string, QQInfo>();
            if (qqnums.Count() > 0) {
                qqnums = qqnums.Distinct();
                foreach (var qqnum in qqnums.ToList()) {
                    qqExistInfo.InfoDic.Add(qqnum, new QQInfo { IsExist = IsExist(qqnum), PrintInfo = qqnum });
                }
            }
            return qqExistInfo;
        }
    }
}
