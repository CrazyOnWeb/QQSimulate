using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CRY.Core.Extensions {
    public static class JsonConvertExtension {
        public static string SerializeObject(this object obj) {
            return JsonConvert.SerializeObject(obj);
        }
        public static TObject DeserializeObject<TObject>(this string json) {
            return JsonConvert.DeserializeObject<TObject>(json);
        }
    }
}
