using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRY.QQ.Simulate.Helper
{
    public class FileHelper {
        public static IEnumerable<string> GetQQText() {
            return File.ReadLines(AppDomain.CurrentDomain.BaseDirectory + "qq.txt");
        }
        public static string GetCookie()
        {
            var filepath = AppDomain.CurrentDomain.BaseDirectory + "cookie.txt";
            if (File.Exists(filepath))
            {
                return File.ReadAllText(filepath);
            }
            return "";
        }

        public static bool CookieExists()
        {
            var filepath = AppDomain.CurrentDomain.BaseDirectory + "cookie.txt";
            if (File.Exists(filepath))
            {
                return true;
            }
            return false;
        }

        public static void SaveFile(string content)
        {
            var filepath = AppDomain.CurrentDomain.BaseDirectory + "cookie.txt";
  
            if (!File.Exists(filepath)) { 
                using (FileStream fs = new FileStream(filepath, FileMode.CreateNew))
                {
                    StreamWriter sr = new StreamWriter(fs);
                    sr.Write(content);
                    sr.Flush();
                }
            }
        }

        internal static void ClearCookie() {
            var filepath = AppDomain.CurrentDomain.BaseDirectory + "cookie.txt";
            if (File.Exists(filepath)) {
                File.Delete(filepath);
            }
        }
    }
}
