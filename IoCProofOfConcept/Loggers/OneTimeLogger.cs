using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace IoCProofOfConcept
{
    public class OneTimeLogger : BaseLogger
    {
        public override int Priority => 1;

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