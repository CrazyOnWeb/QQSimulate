using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Facilities.Logging;
using Castle.Windsor;

namespace CRY.Core.Ioc {
    public static class IocContainerExtensions {
        public static void UserLog4Net(this IWindsorContainer windsorContainer) {
            windsorContainer.AddFacility<LoggingFacility>(f => f.UseLog4Net().WithConfig("log4net.config"));
        }
    }
}
