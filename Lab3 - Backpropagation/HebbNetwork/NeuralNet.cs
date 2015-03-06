using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace nnet
{
    public class Backpropagation
    {
        public Backpropagation(int nrInput, int nrHidden, int nrOutput, double learnRate)
        {
            this.learnRate = learnRate;
            this.input = new double[nrInput];
            this.hidden = new double[nrHidden];
            this.output = new double[nrOutput];
            this.expOutput = new double[nrOutput];
            this.win = new double[nrInput, nrHidden];
            this.wout = new double[nrHidden, nrOutput];
            this.dwin = new double[nrInput, nrHidden];
            this.dwout = new double[nrHidden, nrOutput];
            Init();
        }

        public void Init()
        {
            Random rnd = new Random();
            for (int i = 0; i < input.Length; i++)
                for (int j = 0; j < hidden.Length; j++)
                    win[i, j] = (rnd.NextDouble() - 0.5);

            for (int i = 0; i < hidden.Length; i++)
                for (int j = 0; j < output.Length; j++)
                    wout[i, j] = (rnd.NextDouble() - 0.5);
            ClearMatrixDelta();
        }

        public double[] Run(params double[] input)
        {
            SetInput(input);
            FeedForward();
            return GetOutput();
        }

        public void Train(double[][] input, double[][] expOutput)
        {
            ClearMatrixDelta();
            for (int i = 0; i < input.Length; i++)
            {
                SetInput(input[i]);
                SetExpOutput(expOutput[i]);
                FeedForward();
                BackPropagateError();
            }
            Learn();
        }

        void ClearMatrixDelta()
        {
            for (int i = 0; i < input.Length; i++)
                for (int j = 0; j < hidden.Length; j++)
                    dwin[i, j] = 0;
            for (int i = 0; i < hidden.Length; i++)
                for (int j = 0; j < output.Length; j++)
                    dwout[i, j] = 0;
        }

        void SetInput(params double[] input)
        {
            Debug.Assert(input.Length == input.Length);
            for (int i = 0; i < input.Length; i++)
                this.input[i] = input[i];
        }

        void FeedForward()
        {
            for (int i = 0; i < hidden.Length; i++)
            {
                double sumh = 0;
                for (int j = 0; j < input.Length; j++)
                    sumh += input[j] * win[j, i];
                hidden[i] = 1.0 / (1.0 + Math.Exp(-sumh));
            }

            for (int i = 0; i < output.Length; i++)
            {
                double sumh = 0;
                for (int j = 0; j < hidden.Length; j++)
                    sumh += hidden[j] * wout[j, i];
                output[i] = 1.0 / (1.0 + Math.Exp(-sumh));
            }
        }

        double[] GetOutput()
        {
            return (double[])output.Clone();
        }

        void SetExpOutput(params double[] expOutput)
        {
            Debug.Assert(expOutput.Length == expOutput.Length);
            for (int i = 0; i < expOutput.Length; i++)
                this.expOutput[i] = expOutput[i];
        }

        void BackPropagateError()
        {
            double[] erro = new double[output.Length], errh = new double[hidden.Length];
            for (int i = 0; i < output.Length; i++)
                erro[i] = output[i] * (1.0 - output[i]) * (expOutput[i] - output[i]);
            for (int i = 0; i < hidden.Length; i++)
            {
                double sumerr = 0;
                for (int j = 0; j < output.Length; j++)
                    sumerr += wout[i, j] * erro[j];
                errh[i] = hidden[i] * (1.0 - hidden[i]) * sumerr;
            }
            for (int i = 0; i < hidden.Length; i++)
                for (int j = 0; j < output.Length; j++)
                    dwout[i, j] +=  erro[j] * hidden[i];
            for (int i = 0; i < input.Length; i++)
                for (int j = 0; j < hidden.Length; j++)
                    dwin[i, j] += errh[j] * input[i];            
        }

        void Learn()
        {
            for (int i = 0; i < hidden.Length; i++)
                for (int j = 0; j < output.Length; j++)
                    wout[i, j] += learnRate * dwout[i, j];
            for (int i = 0; i < input.Length; i++)
                for (int j = 0; j < hidden.Length; j++)
                    win[i, j] += learnRate * dwin[i, j]; 
        }

        private double learnRate;
        private double[] input, hidden, output, expOutput;
        private double[,] win, wout, dwin, dwout;
    }
}
