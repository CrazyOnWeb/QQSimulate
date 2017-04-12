using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CRY.Core.Engine;
using CRY.QQ.Simulate.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CRY.QQ.Simulate.Test {
    [TestClass]
    public class ClientsTest {
        [TestMethod]
        public void VerifycodeClient() {
            CheckRegmasterClient checkRegmasterClient = new CheckRegmasterClient();
            var checkRegmasterRes = checkRegmasterClient.Send(new RegmasterReq { QQ = "515404" });
            VerifycodeClient verifycodeClient = new VerifycodeClient();
            verifycodeClient.GetVerifyCodeImage(new VerifyCodeReq { UID = "515404", Cap_cd = checkRegmasterRes.Verifysession });
            verifycodeClient.Verify(new VerifyCodeReq { UID = "515404", Cap_cd = checkRegmasterRes.Verifysession, VerifyCode = "" });
        }

        [TestMethod]
        public void TestTDCJS() {
            var jsEngine = new JSEngine(Assembly.GetExecutingAssembly());
            var begintime = DateTime.Now.Ticks;
            var endtime = begintime + 4310;
            var json = "{\"mousemove\":[{\"t\":78,\"x\":138,\"y\":148},{\"t\":115,\"x\":91,\"y\":145},{\"t\":116,\"x\":113,\"y\":105},{\"t\":117,\"x\":200,\"y\":81},{\"t\":118,\"x\":200,\"y\":81},{\"t\":119,\"x\":200,\"y\":81},{\"t\":120,\"x\":230,\"y\":121}],\"mouseclick\":[{\"t\":116,\"x\":176,\"y\":83}],\"keyvalue\":[117,117,118,118,118,119],\"user_Agent\":\"chrome/56.0.2924.87\",\"resolutionx\":1280,\"resolutiony\":1024,\"winSize\":[300,152],\"url\":\"http://captcha.qq.com/cap_union_new_show\",\"refer\":\"http://xui.ptlogin2.qq.com/cgi-bin/xlogin\",\"begintime\":" + begintime + ",\"endtime\":" + endtime + ",\"platform\":1,\"os\":\"Win7\",\"keyboards\":6,\"flash\":1,\"pluginNum\":5,\"index\":1,\"ptcz\":\"\",\"tokenid\":262531355,\"btokenid\":null,\"tokents\":1487908779,\"ips\":{\"in\":[\"192.168.119.44\"]},\"colorDepth\":24,\"cookieEnabled\":true,\"timezone\":9,\"wDelta\":0,\"keyUpCnt\":6,\"keyUpValue\":[117,117,118,118,118,119],\"mouseUpValue\":[{\"t\":116,\"x\":176,\"y\":83},{\"t\":120,\"x\":230,\"y\":121}],\"mouseUpCnt\":2,\"mouseDownValue\":[{\"t\":116,\"x\":176,\"y\":83},{\"t\":120,\"x\":230,\"y\":121}],\"mouseDownCnt\":2,\"orientation\":[{\"x\":0,\"y\":0,\"z\":0}],\"bSimutor\":0,\"focusBlur\":{\"in\":[1488243803410],\"out\":[1488243803410],\"t\":[3629]},\"fVersion\":24,\"charSet\":\"UTF-8\",\"resizeCnt\":0,\"errors\":[],\"screenInfo\":\"1280-1024-984-24-*-*-*\",\"elapsed\":37000,\"clientType\":\"2\",\"trycnt\":1,\"refreshcnt\":0}             ";
            var ss = jsEngine.Execute("TDC", "TDC.getData", json);
        }

        [TestMethod]
        public void TestNow() {
            var jsEngine = new JSEngine(Assembly.GetExecutingAssembly());
            var now = jsEngine.Execute("TDC", "TDC.now");
        }
    }
}
