//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace HebbNetwork
//{
//    public class Neuron
//    {
//        /// <summary>
//        /// Вектор весовых коэффициентовтов нейрона
//        /// </summary>
//        public double[] w;
 
//        /// <summary>
//        /// Выход нейрона (-1 либо 1)
//        /// </summary>
//        public double y;

//        /// <summary>
//        /// Создаёт нейрон с заданным количеством входов и инициализирует его вектор 
//        /// весовых коэффициентов случайными величинами (0-1)
//        /// </summary>
//        /// <param name="NumberOfInputs">Количество входов нейрона</param>
//        public Neuron(int NumberOfInputs){
//            w = new double[NumberOfInputs];
//            InitWeights(ref w);
//        }

//        /// <summary>
//        /// Инициализирует вектор весовых коэффициентов нейрона случайными величинами (0-1)
//        /// </summary>
//        /// <param name="w">Ссылка на вектор весовых коэффициентов нейрона</param>
//        void InitWeights(ref double[] w)
//        {
//            Random r = new Random();
//            for (int i = 0; i < w.GetLength(0); i++)
//                w[i] = r.NextDouble();
//        }
//    }
//}
