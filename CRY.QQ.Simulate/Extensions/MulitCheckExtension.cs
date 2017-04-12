using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRY.QQ.Simulate.Extensions
{
    public static class MulitCheckExtension {
        public static QQExistInfo OneRuleOnly(this MulitCheck mulitCheck) {
            return mulitCheck.IsExistMulti(mulitCheck.QQNums);
        }

        public static QQExistInfo Or(this MulitCheck mulitCheck, MulitCheck multCheckAnthoer) {
            var haoma = mulitCheck.IsExistMulti(mulitCheck.QQNums);
            return haoma.Or(multCheckAnthoer);
        }

        public static QQExistInfo Or(this QQExistInfo qqInfo, MulitCheck multCheckAnthoer) {
            var nextqqNums = qqInfo.InfoDic.Where(_ => !_.Value.IsExist).Select(_ => _.Key).ToList();
            var qzone = multCheckAnthoer.IsExistMulti(nextqqNums);
            qqInfo.InfoDic.ToList().ForEach(hao => {
                if (!hao.Value.IsExist && qzone.InfoDic[hao.Key].IsExist) {
                    qqInfo.InfoDic[hao.Key] = qzone.InfoDic[hao.Key];
                }
            });
            return qqInfo;
        }

        public static QQExistInfo And(this MulitCheck mulitCheck, MulitCheck multCheckAnthoer) {
            var haoma = mulitCheck.IsExistMulti(mulitCheck.QQNums);
            return haoma.And(multCheckAnthoer);
        }

        public static QQExistInfo And(this QQExistInfo qqInfo, MulitCheck multCheckAnthoer) {
            var nextqqNums = qqInfo.InfoDic.Where(_ => _.Value.IsExist).Select(_ => _.Key).ToList();
            var qzone = multCheckAnthoer.IsExistMulti(nextqqNums);
            qqInfo.InfoDic.ToList().ForEach(hao => {
                if (hao.Value.IsExist && !qzone.InfoDic[hao.Key].IsExist) {
                    qqInfo.InfoDic[hao.Key] = qzone.InfoDic[hao.Key];
                }
            });
            return qqInfo;
        }
    }
}
