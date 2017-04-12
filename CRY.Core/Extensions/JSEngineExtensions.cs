using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRY.Core.Extensions {
    public static class JSEngineExtensions {
        public static int ToInt32(this object obj) {
            return Convert.ToInt32(obj);
        }

        public static long ToInt64(this object obj) {
            return Convert.ToInt64(obj);
        }

        //public static TJsonObject ToJsonObject<TJsonObject>(this object obj) {
        //    return obj.ToString().DeserializeObject<TJsonObject>();
        //}
    }
}
