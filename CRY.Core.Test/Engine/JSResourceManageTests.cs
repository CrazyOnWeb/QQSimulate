using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CRY.Core.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CRY.Core.Test.Engine {
    [TestClass]
    public class JSResourceManageTests {
        private JSResourceManage _JSResourceManage;
        private List<string> resourcesFile = new List<string> { "test.js", "test-2.js" };
        public JSResourceManageTests() {
            _JSResourceManage = new JSResourceManage(Assembly.GetExecutingAssembly());
        }

        [TestMethod]
        public void Should_get_from_cache() {
            LoadResources();
            var jsResourceManage = new JSResourceManage(Assembly.GetExecutingAssembly());
            Assert.IsTrue(jsResourceManage.Get("test.js") == JSResourceManage.JsContentManage["test.js"]);
            Assert.IsTrue(jsResourceManage.Get("test-2.js") == JSResourceManage.JsContentManage["test-2.js"]);
            Assert.IsTrue(JSResourceManage.JsContentManage.Count == 2);
        }

        [TestMethod]
        public void Should_get_from_files() {
            LoadResources();
            Assert.IsTrue(JSResourceManage.JsContentManage.Count == 2);
            Assert.IsTrue(JSResourceManage.JsContentManage.ContainsKey("test.js"));
            Assert.IsTrue(JSResourceManage.JsContentManage.ContainsKey("test-2.js"));
            Assert.IsTrue(JSResourceManage.JsContentManage["test.js"].Length > 0);
            Assert.IsTrue(JSResourceManage.JsContentManage["test-2.js"].Length > 0);
        }

        private void LoadResources() {
            resourcesFile.ForEach((filename) => {
                _JSResourceManage.Get(filename);
            });
        }
    }
}
