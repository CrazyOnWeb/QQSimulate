using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CRY.Core.Engine {
    public class JSEngine {
        public JSEngine(Assembly assmebly) {
            _Resource = new JSResourceManage(assmebly);
        }

        private JSResourceManage _Resource;
        public object Execute(string jsName, string funcName, params string[] arguments) {
            return ExecuteScript(GetExpression(funcName, arguments), GetJsContent(jsName));
        }

        /// <summary>
        /// 执行JS
        /// </summary>
        /// <param name="expression">参数体</param>
        /// <param name="sCode">JavaScript代码的字符串</param>
        /// <returns></returns>
        private object ExecuteScript(string expression, string sCode) {
            MSScriptControl.ScriptControl scriptControl = new MSScriptControl.ScriptControl();
            scriptControl.UseSafeSubset = true;
            scriptControl.Language = "JScript";
            scriptControl.AddCode(sCode);
            try {
                return scriptControl.Eval(expression);
            } catch (Exception) {

            }
            return null;
        }

        private string GetExpression(string funcName, params string[] arguments) {
            var argumentFormat = string.Empty;
            foreach (var argument in arguments) {
                argumentFormat += "\'" + argument + "\',";
            }
            argumentFormat = argumentFormat.TrimEnd(',');
            return string.Format("{0}({1})", funcName, argumentFormat);
        }

        private string GetJsContent(string jsName) {
            var fileName = jsName + ".js";
            return _Resource.Get(fileName);
        }
    }
}
