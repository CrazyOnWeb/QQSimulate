using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRY.Core.Extensions;
using System.Net;

namespace CRY.Core.Test.Extensions {
    [TestClass]
    public class CookieExtensionsTests {
        private CookieCollection _CookieCollection;
        private IEnumerable<Cookie> _Cookies;
        public CookieExtensionsTests() {
            _CookieCollection = new CookieCollection{
                new Cookie { Name = "cookie1", Value = "value1" },
                new Cookie { Name = "cookie2", Value = "value2" },
                new Cookie { Name = "cookie3", Value = "value3" }
            };
            _Cookies = new List<Cookie>{
                new Cookie { Name = "cookie1", Value = "value1" },
                new Cookie { Name = "cookie2", Value = "value2" },
                new Cookie { Name = "cookie3", Value = "value3" }
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Jsonfile_to_cookieCollection_exception() {
            var json = "{";
            json.ToCookieCollection();
        }

        [TestMethod]
        public void Jsonfile_to_cookieCollection() {
            var json = _CookieCollection.SerializeObject();
            Assert.IsTrue(CookieCollectionEqual(_CookieCollection, json.ToCookieCollection()));
        }

        [TestMethod]
        public void CookieList_to_cookieCollection() {
            Assert.IsTrue(CookieCollectionEqual(_CookieCollection, _Cookies.ToCookieCollection()));
        }

        [TestMethod]
        public void GetValueOfKey_from_cookieCollection() {
            Assert.AreEqual("value1", _CookieCollection.GetValueOf("cookie1"));
            Assert.AreEqual("value2", _CookieCollection.GetValueOf("cookie2"));
            Assert.AreEqual("value3", _CookieCollection.GetValueOf("cookie3"));
        }

        [TestMethod]
        public void CookieCollection_to_cookieList() {
            Assert.IsTrue(CookiesEqual(_Cookies, _CookieCollection.ToCookieList()));
        }

        private bool CookieCollectionEqual(CookieCollection a, CookieCollection b) {
            return a.Count == b.Count &&
                   a.GetValueOf("cookie1") == b.GetValueOf("cookie1") &&
                   a.GetValueOf("cookie2") == b.GetValueOf("cookie2") &&
                   a.GetValueOf("cookie3") == b.GetValueOf("cookie3");
        }

        private bool CookiesEqual(IEnumerable<Cookie> a, IEnumerable<Cookie> b) {
            return a.Count() == b.Count() &&
                   a.Where(_ => _.Name == "cookie1").FirstOrDefault().Value == b.Where(_ => _.Name == "cookie1").FirstOrDefault().Value &&
                   a.Where(_ => _.Name == "cookie2").FirstOrDefault().Value == b.Where(_ => _.Name == "cookie2").FirstOrDefault().Value &&
                   a.Where(_ => _.Name == "cookie3").FirstOrDefault().Value == b.Where(_ => _.Name == "cookie3").FirstOrDefault().Value;
        }
    }
}
