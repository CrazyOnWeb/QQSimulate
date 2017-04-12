using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRY.Core.Extensions;
using CRY.QQ.Simulate.Helper;
using CRY.QQ.Simulate.Net;

namespace CRY.QQ.Simulate.Login {
    public class QQLogin {
        private VerifycodeClient _VerifycodeClient;
        private string _QQ;
        private RegmasterRes _RegmasterRes;
        private LoginClient _LoginClient;
        private CheckRegmasterClient _CheckRegmasterClient;
        private bool WaitUserInputVerifyCode;
        public QQLogin() {
            Status = LoginStatus.Logoff;

            if (HasCookieFile()) {
                if (LoginedQQ == null) {
                    Status = ResetLoginedQQFromCookieFile();
                }
            }
        }

        public Action<byte[]> VerifyCodeImageLoad { get; set; }
        public Action<LoginStatus> LoginStatusReset { get; set; }
        public LoginedQQ LoginedQQ { get; private set; }

        private LoginStatus _Status;
        public LoginStatus Status {
            get { return _Status; }
            private set {
                _Status = value;
                if (LoginStatusReset != null)
                    LoginStatusReset(_Status);
            }
        }

        public LoginAck Login(string qq, string pass, string verifyCode = "") {


            if (_CheckRegmasterClient == null)
                _CheckRegmasterClient = new CheckRegmasterClient();

            if (_VerifycodeClient == null)
                _VerifycodeClient = new VerifycodeClient();
            Status = LoginStatus.Logging;
            if (_QQ != qq) {
                WaitUserInputVerifyCode = false;
            }
            if (!WaitUserInputVerifyCode) {
                _QQ = qq;
                _RegmasterRes = _CheckRegmasterClient.Send(new RegmasterReq { QQ = qq });

                if (_RegmasterRes.MustHaveVerifycode) {
                    var image = _VerifycodeClient.GetVerifyCodeImage(new VerifyCodeReq { UID = qq, Cap_cd = _RegmasterRes.Verifysession });
                    if (VerifyCodeImageLoad != null)
                        VerifyCodeImageLoad(image);
                    WaitUserInputVerifyCode = true;
                    Status = LoginStatus.Logoff;
                    return new LoginAck { LoginStatus = Status, ErrorMessage = "please input the verifyCode." };
                }
            }

            if (WaitUserInputVerifyCode) {
                if (string.IsNullOrEmpty(verifyCode)) {
                    Status = LoginStatus.Logoff;
                    return new LoginAck { LoginStatus = Status, ErrorMessage = "please check your verifyCode." };
                }
                var res = _VerifycodeClient.Verify(new VerifyCodeReq { UID = qq, Cap_cd = _RegmasterRes.Verifysession, VerifyCode = verifyCode });
                _RegmasterRes.Verifycode = res.Randstr;
                _RegmasterRes.Verifysession = res.Ticket;
                WaitUserInputVerifyCode = false;
                if (res.Randstr.Length != 4) {
                    VerifyCodeReLoad();
                    WaitUserInputVerifyCode = true;
                    Status = LoginStatus.Logoff;
                    return new LoginAck { LoginStatus = Status, ErrorMessage = "error verifyCode. try again" };
                }
            }

            if (_LoginClient == null)
                _LoginClient = new LoginClient();

            var loginRes = _LoginClient.Send(new LoginReq { QQ = qq, Pass = pass, Regmaster = _RegmasterRes, });
            if (loginRes.IsLogin) {
                LoginedQQ = new LoginedQQ();
                LoginedQQ.QQ = qq;
                LoginedQQ.Cookie = loginRes.SetCookies.ToCookieList();
                FileHelper.SaveFile(LoginedQQ.SerializeObject());
                Status = LoginStatus.Logged;
                return new LoginAck { LoginStatus = Status, ErrorMessage = "" };
            }
            Status = LoginStatus.Logoff;
            return new LoginAck { LoginStatus = Status, ErrorMessage = "check your name or password." };
        }

        private bool HasCookieFile() {
            return FileHelper.CookieExists();
        }

        private LoginStatus ResetLoginedQQFromCookieFile() {
            var cookie = FileHelper.GetCookie();
            LoginedQQ = cookie.DeserializeObject<LoginedQQ>();
            return LoginedQQ != null ? LoginStatus.Logged : LoginStatus.Logoff;
        }

        public void LogOff() {
            Status = LoginStatus.Logoff;
            _RegmasterRes = null;
            FileHelper.ClearCookie();
        }


        public void VerifyCodeReLoad() {
            var bak = Status;
            Status = LoginStatus.Logging;
            if (_RegmasterRes != null) {
                var image = _VerifycodeClient.GetVerifyCodeImage(new VerifyCodeReq { UID = _QQ, Cap_cd = _RegmasterRes.Verifysession });
                VerifyCodeImageLoad(image);
            }
            Status = bak;
        }
    }

    public class LoginAck {
        public LoginStatus LoginStatus { get; set; }
        public string ErrorMessage { get; set; }
    }

    public enum LoginStatus {
        Logging,
        Logged,
        Logoff
    }
}
