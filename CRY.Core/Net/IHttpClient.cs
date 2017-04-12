using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CRY.Core.Net {
    public interface IHttpClient {
        string Url { get; set; }
        HttpVerb Verb { get; set; }
        WebHeaderCollection ResponseHeaders { get; }
        Encoding DefaultEncoding { get; set; }
        HttpWebResponse GetResponse();
        Stream GetStream();
        byte[] GetBytes();
        string GetString();
        string GetString(Encoding encoding);
    }
}
