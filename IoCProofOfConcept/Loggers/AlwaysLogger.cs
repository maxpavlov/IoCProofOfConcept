using System;
using System.Diagnostics;

namespace IoCProofOfConcept
{
    public class AlwaysLogger : BaseLogger
    {
        ILoggerDatabase _db;

        public AlwaysLogger(ILoggerDatabase dbDatabase)
        {
            _db = dbDatabase;
        }

        public override int Priority => 2;
        internal override void DoLog(string textToLog)
        {
            if (!this.IsBusy)
            {
                Debug.Write(textToLog);
                this.IsBusy = true;
            }
            else
                throw new Exception("Busy!");
        }
    }
}