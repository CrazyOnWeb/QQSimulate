using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CRY.Core.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRY.Core.Extensions;

namespace CRY.Core.Test.Engine {
    [TestClass]
    public class JSEngineTests {
        private JSEngine _JSEngine;
        public JSEngineTests() {
            _JSEngine = new JSEngine(Assembly.GetExecutingAssembly());
        }

        [TestMethod]
        public void JsResource_excute() {
            Assert.AreEqual(9, _JSEngine.Execute("test", "TetsMethod.method2", "10", "1").ToInt32());
            Assert.AreEqual("this is a string", _JSEngine.Execute("test", "TetsMethod.method1").ToString());
            //var testJsonObject = new TestJsonObject {
            //    Name = "name",
            //    Age = 24
            //};
            //Assert.AreEqual(testJsonObject, _JSEngine.Execute("test", "TetsMethod.method3").ToJsonObject<TestJsonObject>());
        }

        //private class TestJsonObject {
        //    public string Name { get; set; }
        //    public int Age { get; set; }
        //}
    }
}
