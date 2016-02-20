using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCProofOfConcept
{
    public class MainNinjectBindings : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<ILogger>().To<OneTimeLogger>().InSingletonScope();
            Bind<ILogger>().To<AlwaysLogger>().InSingletonScope();

            Bind<ILoggerDatabase>().To<LoggerDatabase>().InSingletonScope();
        }
    }
}
