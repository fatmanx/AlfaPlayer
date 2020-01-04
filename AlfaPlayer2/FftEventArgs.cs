using NAudio.Dsp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AlfaPlayer2
{
    public class FftEventArgs : EventArgs
    {
        [DebuggerStepThrough]
        public FftEventArgs(Complex[] result, float[] wav)
        {
            Result = result;
            Signal = wav;
        }

        [DebuggerStepThrough]
        public FftEventArgs(Complex[] result)
        {
            Result = result;
        }

        public Complex[] Result { get; private set; }
        public float[] Signal { get; private set; }
    }
}
