using CRY.Core.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRY.Core.Extensions
{
    public static class HttpClientExtension {
        public static IHttpClient GET(this IHttpClient client, string url = "") {
            if (!string.IsNullOrEmpty(url)) {
                client.Url = url;
            }
            client.Verb = HttpVerb.GET;
            return client;
        }

        public static IHttpClient POST(this IHttpClient client, string url = "") {
            if (!string.IsNullOrEmpty(url)) {
                client.Url = url;
            }
            client.Verb = HttpVerb.POST;
            return client;
        }
    }
}
