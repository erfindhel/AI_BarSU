//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace HebbNetwork
//{
//    public class Hebbian
//    {
//        int NeuronsCount = 0;
//        int NumberOfInputs = 0;
//        Neuron[] Neurons; // массив нейронов
//        // Эталонные образы (4 строки по 25 символов) - A L E X
//        double[][] Etalon = { 
//                new double[] {0,1,1,1,0,0,1,0,1,0,0,1,1,1,0,0,1,0,1,0,0,1,0,1,0}, //A
//                new double[] {0,1,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1,0,1,0,0,1,1,1,0}, //L
//                new double[] {0,1,1,1,0,0,1,0,0,0,0,1,1,0,0,0,1,0,0,0,0,1,1,1,0}, //E
//                new double[] {1,0,0,0,1,0,1,0,1,0,0,0,1,0,0,0,1,0,1,0,1,0,0,0,1}  //X
//                };

//        // Эталонные значения выходов нейронов
//        double[][] outputs = { 
//                new double[] { 1, 0, 0, 0 }, //A
//                new double[] { 0, 1, 0, 0 }, //L
//                new double[] { 0, 0, 1, 0 }, //E
//                new double[] { 0, 0, 0, 1 }  //X
//            };

//        //конструктор
//        public Hebbian(int NeuronsCount, int NumberOfInputs)
//        {
//            this.NeuronsCount = NeuronsCount;
//            this.NumberOfInputs = NumberOfInputs;

//            Neurons = new Neuron[NeuronsCount];
//            for (int i = 0; i < NeuronsCount; ++i)
//                Neurons[i] = new Neuron(NumberOfInputs); //init each neuron
//        }

//        //обучаетение сети
//        public void Train()
//        {
//            double[] OutputVector = new double[NeuronsCount]; //
//            for (int image = 0; image < this.Etalon.GetLength(0); image++) // подаём входые образы (image - номер образа)
//            {
//                while (true)
//                {
//                    OutputVector = CalculateOutput(Etalon[image]);
//                    if (!Equal(OutputVector, this.outputs[image]))
//                        ChangeWeights(OutputVector);
//                    else break;
//                }
//            }
//        }

//        void ChangeWeights(double[] OutputVector)
//        {
//            for (int i = 0; i < NeuronsCount; i++) // each neuron
//            {
//                for (int j = 0; j < NumberOfInputs; j++)
//                {
//                    Neurons[i].w[j] += Etalon[i][j] * OutputVector[i];
//                }
//            }
//        }

//        // Считает и возвращает значения на выходах всех нейронов сети
//        double[] CalculateOutput(double[] input)
//        {
//            double[] OutputVector = new double[NeuronsCount];
//            double s;
//            for (int i = 0; i < NeuronsCount; i++) // each neuron
//            {
//                s = 0;
//                for (int j = 0; j < NumberOfInputs; j++)
//                {
//                    s += Neurons[i].w[j] * input[j];
//                }
//                OutputVector[i] = F(s, 50);
//            }
//            return OutputVector;
//        }

//        /// <summary>
//        /// Пороговая активационная функция
//        /// </summary>
//        /// <param name="s">Входное значение</param>
//        /// <param name="T">Порог (0 по умолчанию)</param>
//        /// <returns></returns>
//        public static double F(double s, double T)
//        {
//            return s < T ? -1 : 1;
//        }

//        bool Equal(double[] A, double[] B)
//        {
//            if (A.Length != B.Length) return false;
//            for (int i = 0; i < A.Length; i++)
//                if (A[i] != B[i]) return false;
//            return true;
//        }
//    }
//}
