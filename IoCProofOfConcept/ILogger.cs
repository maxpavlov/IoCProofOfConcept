using System;

namespace IoCProofOfConcept
{
    public interface ILogger: IPrioritable
    {
        bool IsBusy { get; set; }
        void Log(string textToLog);
        ILogger BackupLogger { get; set; }
    }
}