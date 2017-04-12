using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CRY.Core.Extensions {
    public static class CookieExtensions {
        public static CookieCollection ToCookieCollection(this string cookiecontext) {
            CookieCollection cookiesConllection = null;
            if (!string.IsNullOrEmpty(cookiecontext)) {
                try {
                    var cookies = cookiecontext.DeserializeObject<List<Cookie>>();
                    cookiesConllection = new CookieCollection();
                    cookies.ForEach(item => {
                        cookiesConllection.Add(item);
                    });
                } catch (Exception) {
                    throw new ArgumentException("cookiecontext is not a cookie");
                }
            }
            return cookiesConllection;
        }

        public static CookieCollection ToCookieCollection(this IEnumerable<Cookie> cookiecontext) {
            CookieCollection cookiesConllection = new CookieCollection();
            if (cookiecontext != null && cookiecontext.Count() > 0) {
                cookiecontext.ToList().ForEach(item => {
                    cookiesConllection.Add(item);
                });
            }
            return cookiesConllection;
        }

        public static string GetValueOf(this CookieCollection collection, string name) {
            var result = string.Empty;
            if (!string.IsNullOrEmpty(name)) {
                for (int i = 0; i < collection.Count; i++) {
                    var item = collection[i];
                    if (item.Name.ToLower() == name.ToLower()) {
                        result = item.Value;
                        break;
                    }
                }
            }
            return result;
        }

        public static IList<Cookie> ToCookieList(this CookieCollection collection) {
            var cookieList = new List<Cookie>();
            for (int i = 0; i < collection.Count; i++) {
                cookieList.Add(collection[i]);
            }
            return cookieList;
        }
    }
}
