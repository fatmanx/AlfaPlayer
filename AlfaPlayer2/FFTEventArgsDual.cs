using NAudio.Dsp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AlfaPlayer2
{
    public class FFTEventArgsDual : EventArgs
    {
        [DebuggerStepThrough]
        public FFTEventArgsDual(Complex[] result0, Complex[] result1)
        {
            Result0 = result0;
            Result1 = result1;
        }

        public Complex[] Result0 { get; private set; }
        public Complex[] Result1 { get; private set; }
    }
}
