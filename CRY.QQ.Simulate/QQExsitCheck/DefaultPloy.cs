using CRY.QQ.Simulate.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRY.QQ.Simulate
{
    public class DefaultPloy:PloyBase
    {
        public DefaultPloy(IEnumerable<string> qqnums) : base(qqnums)
        {

        }

        public override Func<QQExistInfo> PloyAction()
        {
            return () =>
            {
                MulitCheck haomaRule = new HaomaRule(QQNums);
                MulitCheck qzoneHeadRule = new QzoneHeadRule(QQNums);
                return qzoneHeadRule.Or(haomaRule);
            };
        }
    }
}
