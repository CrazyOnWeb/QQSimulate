using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRY.QQ.Simulate
{
    public class PloyBase {
        public IEnumerable<string> QQNums { get; private set; }
        public PloyBase(IEnumerable<string> qqnums) {
            QQNums = qqnums;
        }
        public virtual Func<QQExistInfo> PloyAction()
        {
            return () =>
            {
                return new QQExistInfo();
            };
        }
        public QQExistInfo Run() {
            return PloyAction()();
        }
    }
}
