using System;

namespace IoCProofOfConcept
{
    public abstract class BaseLogger : ILogger
    {
        internal abstract void DoLog(string textToLog);
        public ILogger BackupLogger { get; set; }

        public bool IsBusy { get; set; }
        void ILogger.Log(string textToLog)
        {
            try
            {
                this.DoLog(textToLog);
            }
            catch (Exception)
            {
                BackupLogger.Log(textToLog);
            }
        }

        public abstract int Priority { get; }
    }
}