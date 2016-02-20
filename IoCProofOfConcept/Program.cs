using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace IoCProofOfConcept
{
    class Program
    {
        static void Main(string[] args)
        {
            var iocContainer = new StandardKernel();

            iocContainer.Load(Assembly.GetExecutingAssembly());

            var availableLoggers = iocContainer.GetAll<ILogger>().OrderBy(l => l.Priority).ToList();

            for (int i = 0; i < availableLoggers.Count()-1; i++)
            {
                availableLoggers[i].BackupLogger = availableLoggers[i + 1];
            }

            //First Logging.

            var messageToLog = "First message";
            InternalLog(availableLoggers, messageToLog);

            //Second Logging.

            availableLoggers = iocContainer.GetAll<ILogger>().ToList();

            messageToLog = "Second message";
            InternalLog(availableLoggers, messageToLog);
        }


        private static void InternalLog(List<ILogger> availableLoggers, string messageToLog)
        {
            var mainLogger = availableLoggers.FirstOrDefault(l => l.Priority == 1);

            try
            { 
                mainLogger?.Log(messageToLog);
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
        }
    }
}
