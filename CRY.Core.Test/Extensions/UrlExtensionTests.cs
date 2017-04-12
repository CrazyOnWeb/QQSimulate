using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRY.Core.Net;
using CRY.Core.Extensions;

namespace CRY.Core.Test.Extensions
{
    [TestClass]
    public class UrlExtensionTests
    {
        [TestMethod]
        public void UrlExtension_CombineParam()
        {
            string expect = "http://www.test.com/login?key1=value1&key2=value2&key3=value3&key4=value4&key5=value5";
            string url = "http://www.test.com/login";
            RequestParamCollection rp = new RequestParamCollection
            {
                new RequestParam { Key="key1",Value="value1"},
                new RequestParam { Key="key2",Value="value2"},
                new RequestParam { Key="key3",Value="value3"},
                new RequestParam { Key="key4",Value="value4"},
                new RequestParam { Key="key5",Value="value5"},
            };
            Assert.AreEqual(expect,url.CombineParam(rp));
        }
    }
}
