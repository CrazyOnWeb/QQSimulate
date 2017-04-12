using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CRY.Core.Net {
    public abstract class HttpClientBase : IHttpClient {
        public string Url { get; set; }
        public HttpVerb Verb { get; set; }
        public WebHeaderCollection ResponseHeaders { get; protected set; }
        public Encoding DefaultEncoding { get; set; }
        public abstract HttpWebResponse GetResponse();
        public event EventHandler<StatusUpdateEventArgs> StatusUpdate;

        private void OnStatusUpdate(StatusUpdateEventArgs e) {
            EventHandler<StatusUpdateEventArgs> temp = StatusUpdate;

            if (temp != null)
                temp(this, e);
        }
        public Stream GetStream() {
            return GetResponse().GetResponseStream();
        }

        public byte[] GetBytes() {
            HttpWebResponse res = GetResponse();
            int length = (int)res.ContentLength;

            MemoryStream memoryStream = new MemoryStream();
            byte[] buffer = new byte[0x100];
            Stream rs = res.GetResponseStream();
            for (int i = rs.Read(buffer, 0, buffer.Length); i > 0; i = rs.Read(buffer, 0, buffer.Length)) {
                memoryStream.Write(buffer, 0, i);
                OnStatusUpdate(new StatusUpdateEventArgs((int)memoryStream.Length, length));
            }
            rs.Close();

            return memoryStream.ToArray();
        }

        public string GetString() {
            byte[] data = GetBytes();
            string encodingName = GetEncodingFromHeaders();

            if (encodingName == null)
                encodingName = GetEncodingFromBody(data);

            Encoding encoding;
            if (encodingName == null)
                encoding = DefaultEncoding;
            else {
                try {
                    encoding = Encoding.GetEncoding(encodingName);
                } catch (ArgumentException) {
                    encoding = DefaultEncoding;
                }
            }
            return encoding.GetString(data);
        }

        public string GetString(Encoding encoding) {
            byte[] data = GetBytes();
            return encoding.GetString(data);
        }

        private string GetEncodingFromBody(byte[] data) {
            string encodingName = null;
            string dataAsAscii = Encoding.UTF8.GetString(data);
            if (dataAsAscii != null) {
                int i = dataAsAscii.IndexOf("charset=");
                if (i != -1) {
                    int j = dataAsAscii.IndexOf("\"", i);
                    if (j != -1) {
                        int k = i + 8;
                        encodingName = dataAsAscii.Substring(k, (j - k) + 1);
                        char[] chArray = new char[2] { '>', '"' };
                        encodingName = encodingName.TrimEnd(chArray);
                    }
                }
            }
            return encodingName;
        }

        private string GetEncodingFromHeaders() {
            string encoding = null;
            string contentType = ResponseHeaders["Content-Type"];
            if (contentType != null) {
                int i = contentType.IndexOf("charset=");
                if (i != -1) {
                    encoding = contentType.Substring(i + 8);
                }
            }
            return encoding;
        }



    }
}
