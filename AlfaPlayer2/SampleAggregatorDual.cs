using NAudio.Dsp;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AlfaPlayer2
{
    public class SampleAggregatorDual : ISampleProvider
    {

        // FFT
        public event EventHandler<FFTEventArgsDual> FftCalculated;
        public bool PerformFFT { get; set; }
        private readonly Complex[] fftBuffer0;
        private readonly Complex[] fftBuffer1;

        private FFTEventArgsDual fftArgs;
        private int fftPos;
        private readonly int fftLength;
        private readonly int m;
        private readonly ISampleProvider source;

        private readonly int channels;

        public SampleAggregatorDual(ISampleProvider source, int fftLength = 1024)
        {
            channels = source.WaveFormat.Channels;
            if (!IsPowerOfTwo(fftLength))
            {
                throw new ArgumentException("FFT Length must be a power of two");
            }
            this.m = (int)Math.Log(fftLength, 2.0);
            this.fftLength = fftLength;
            this.fftBuffer0 = new Complex[fftLength];
            this.fftBuffer1 = new Complex[fftLength];
            this.fftArgs = new FFTEventArgsDual(fftBuffer0, fftBuffer1);
            this.source = source;
        }

        static bool IsPowerOfTwo(int x)
        {
            return (x & (x - 1)) == 0;
        }

        private void Add(float value0, float value1)
        {
            if (PerformFFT && FftCalculated != null)
            {
                fftBuffer0[fftPos].X = (float)(value0 * FastFourierTransform.BlackmannHarrisWindow(fftPos, fftLength));
                fftBuffer0[fftPos].Y = 0;
                fftBuffer1[fftPos].X = (float)(value1 * FastFourierTransform.BlackmannHarrisWindow(fftPos, fftLength));
                fftBuffer1[fftPos].Y = 0;
                fftPos++;
                if (fftPos >= fftBuffer0.Length)
                {
                    fftPos = 0;
                    // 1024 = 2^10
                    FastFourierTransform.FFT(true, m, fftBuffer0);
                    FastFourierTransform.FFT(true, m, fftBuffer1);
                    FftCalculated(this, fftArgs);
                }
            }
        }

        public WaveFormat WaveFormat => source.WaveFormat;

        public int Read(float[] buffer, int offset, int count)
        {
            var samplesRead = source.Read(buffer, offset, count);

            for (int n = 0; n < samplesRead; n += channels)
            {
                if (channels > 1)
                {
                    Add(buffer[n + offset], buffer[n + offset + 1]);
                }
                else
                {
                    Add(buffer[n + offset], buffer[n + offset]);
                }

            }
            return samplesRead;
        }
    }



}
