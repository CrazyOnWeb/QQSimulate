using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRY.Core.Net;
using CRY.Core.Extensions;

namespace CRY.Core.Test.Extensions {
    [TestClass]
    public class HttpClientExtensionTests {

        [TestMethod]
        public void Shouldbe_GET_Request() {
            IHttpClient client = new DefaultHttpClient();
            client.GET();
            Assert.AreEqual(HttpVerb.GET, client.Verb);
        }

        [TestMethod]
        public void Shouldbe_POST_Request() {
            IHttpClient client = new DefaultHttpClient();
            client.POST();
            Assert.AreEqual(HttpVerb.POST, client.Verb);
        }

        [TestMethod]
        public void Shouldbe_URL_GET_Request() {
            var url = "http://test.com";
            IHttpClient client = new DefaultHttpClient();
            client.GET(url);
            Assert.AreEqual(HttpVerb.GET, client.Verb);
            Assert.AreEqual(url, client.Url);
        }

        [TestMethod]
        public void Shouldbe_URL_POST_Request() {
            var url = "http://test.com";
            IHttpClient client = new DefaultHttpClient();
            client.POST(url);
            Assert.AreEqual(HttpVerb.POST, client.Verb);
            Assert.AreEqual(url, client.Url);
        }
    }
}
