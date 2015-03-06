using System;

namespace HammingAlgorythm
{
    /// <summary>
    /// Нейрон подсети Хэмминга
    /// </summary>
    public class ZNeuron
    {
        /// <summary>
        /// Вектор весов
        /// </summary>
        private double[] w;
        static double b;

        /// <summary>
        /// Создаёт нейрон с заданным количеством входов
        /// </summary>
        /// <param name="m">Количество входов</param>
        public ZNeuron(int m)
        {
            w = new double[m];
        }

        /// <summary>
        /// Инициализирует веовые к-ты Z-нейронов
        /// </summary>
        /// <param name="v"></param>
        public void initWeights(int[] v)
        {
            for (int i = 0; i < w.Length; i++)
                w[i] = v[i] / 2.0;
            b = w.Length / 2.0;
        }

        /// <summary>
        /// Вычисляет значение выхода нейрона подсети Хемминга
        /// </summary>
        /// <param name="s">Образ для распознавания</param>
        /// <returns>Выход Z-нейрона</returns>
        public double Uout(int[] s)
        {
            double NET = b / 2;
            for (int i = 0; i < w.Length; i++)
            {
                NET += w[i] * s[i];
            }
            return Activation(NET);
        }

        /// <summary>
        /// Функция активации нейрона подсети Хемминга 
        /// </summary>
        /// <param name="NET">Сумма синапсов</param>
        /// <returns>Выход нейрона</returns>
        static double Activation(double NET)
        {
            if (NET <= 0) return 0;
            else if (NET >= 0 && NET <= 10) return 0.1 * NET;
            else return NET;
        }        
    }

    /// <summary>
    /// Нейрон подсети Maxnet
    /// </summary>
    public static class ANeuron
    {
        /// <summary>
        /// веса отрицательных связей в подсети Maxnet
        /// </summary>
        public static double Epsilon;

        public static double Activation(double NET)
        {
            return (NET > 0) ? NET : 0;
        }
    }

    /// <summary>
    /// Выходные нейроны сети
    /// </summary>
    public static class YNeuron
    {
        /// <summary>
        /// Функция активации Y-нейрона
        /// </summary>
        /// <param name="NET"></param>
        /// <returns></returns>
        public static int Activation(double NET)
        {
            return NET > 0 ? 1 : 0;
        }
    }

    /// <summary>
    /// Реализация алгоритма Хэмминга
    /// </summary>
    public class Hamming
    {
        ZNeuron[] HammingLayer; //layer 1
        int n, m;
        int iter;

        double[] MaxnetInput; //layer 1 outputs / layer 2 inputs
        int[] YlayerOut;

        /// <summary>
        /// Создаёт слой Z-нейронов
        /// </summary>
        /// <param name="n">Количество нейронов в сети</param>
        /// <param name="m">Количество входов нейрона</param>
        /// <param name="v">Матрица эталонных изображенийа</param>
        public Hamming(int n, int m, int[][] v)
        {
            this.n = n;
            this.m = m;
            HammingLayer = new ZNeuron[n]; // Z-layer
            for (int j = 0; j < n; j++)
            {
                HammingLayer[j] = new ZNeuron(m);
            }
            ANeuron.Epsilon = 1.0 / n;
            InitFirstLayerWeights(v);
        }
       
        /// <summary>
        /// Инициализация весовых к-тов подсети Хэмминга
        /// </summary>
        /// <param name="v">Матрица эталонных изображений</param>
        void InitFirstLayerWeights(int[][] v)
        {
            for (int j = 0; j < HammingLayer.Length; j++)
            {
                HammingLayer[j].initWeights(v[j]);
            }            
        }

        /// <summary>
        /// Распознавание образа
        /// </summary>
        /// <param name="s">Входной образ</param>
        public int[] Recognize(int[] s)
        {
            MaxnetInput=new double[HammingLayer.Length];
            YlayerOut = new int[MaxnetInput.Length];
            for (int i = 0; i < HammingLayer.Length; i++)
                MaxnetInput[i] = HammingLayer[i].Uout(s);
            return MaxnetIterations(); // необходимое кол-во итераций второго слоя
        }
        
        /// <summary>
        /// Выделение максимального выходного сигнала 
        /// </summary>
        /// <returns>Вектор с единственной единицей, соответствующей распознанному символу</returns>
        int[] MaxnetIterations()
        {            
            double NET;
            double[] MaxnetInputNextIter=new double[MaxnetInput.Length];
            for (int i = 0; i < HammingLayer.Length; i++) //for each neuron
            {
                NET = 0;
                for (int j = 0; j < MaxnetInput.Length; j++) //for each input
                {
                    if (i != j)
                        NET += MaxnetInput[j];
                }
                MaxnetInputNextIter[i] = ANeuron.Activation(MaxnetInput[i] - ANeuron.Epsilon * NET);
            }
            if (!equal(MaxnetInput, MaxnetInputNextIter))
            {
                MaxnetInput = MaxnetInputNextIter;
                MaxnetIterations();
                iter++;
            }
            else
            {
                for (int i = 0; i < YlayerOut.Length; i++)
                    YlayerOut[i] = YNeuron.Activation(MaxnetInput[i]);
                return YlayerOut;
            }
            return YlayerOut;
        }        

        /// <summary>
        /// Сравнение массивов на эквивалентность
        /// </summary>
        /// <param name="A">Массив A</param>
        /// <param name="B">Массив B</param>
        /// <returns>true - если эквивалентны, иначе false</returns>
        bool equal(double[] A, double[] B)
        {
            if (A.Length != B.Length) return false;
            for (int i = 0; i < A.Length; i++)
                if (A[i] != B[i]) return false;
            return true;
        }
    }
}
