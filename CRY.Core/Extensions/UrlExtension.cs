using CRY.Core.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRY.Core.Extensions
{
    public static class UrlExtension
    {
        public static string CombineParam(this string url, RequestParamCollection param)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("?");
            foreach (RequestParam item in param)
            {
                sb.Append(item.Key+"="+item.Value+"&");
            }
            return string.Concat(url,sb.ToString().TrimEnd('&'));
        }
    }
}
