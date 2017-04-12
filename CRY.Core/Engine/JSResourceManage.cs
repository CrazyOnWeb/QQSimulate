using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CRY.Core.Engine
{
    public class JSResourceManage
    {
        public JSResourceManage(Assembly asm)
        {
            _Assembly = asm;
        }
        private Assembly _Assembly;
        public static IDictionary<string, string> JsContentManage { get; private set; }
        public string Get(string fileName)
        {
            var result = string.Empty;
            if (JsContentManage == null)
            {
                JsContentManage = new Dictionary<string, string>();
            }
            if (JsContentManage.ContainsKey(fileName))
            {
                result = JsContentManage[fileName];
            }
            else {
                var nameSpace = _Assembly.FullName.Split(',')[0];
                var jsStream = _Assembly.GetManifestResourceStream(nameSpace + ".Resources." + fileName);
                using (var streamReader = new StreamReader(jsStream))
                {
                    result = streamReader.ReadToEnd();
                    JsContentManage.Add(fileName,result);
                }
            }
            return result;
        }
    }
}
