using System;

namespace RosenblattLearning
{
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
            return Activate(NET);
        }

        /// <summary>
        /// Функция активации нейрона подсети Хемминга 
        /// </summary>
        /// <param name="Uin"></param>
        /// <returns></returns>
        static double Activate(double NET)
        {
            if (NET <= 0) return 0;
            else if (NET >= 0 && NET <= 10) return 0.1 * NET;
            else return NET;
        }        
    }

    public class ANeuron
    {
        /// <summary>
        /// веса отрицательных связей в подсети Maxnet
        /// </summary>
        public static double Epsilon; 

        /// <summary>
        /// Создаёт нейрон
        /// </summary>
        public ANeuron()
        {

        }

        public static double Activate(double NET)
        {
            return (NET > 0) ? NET : 0;
        }
    }

    /// <summary>
    /// Выход сети. Только одна 1
    /// </summary>
    public class YNeuron
    {
        /// <summary>
        /// Функция активации Y-нейрона
        /// </summary>
        /// <param name="NET"></param>
        /// <returns></returns>
        public static int Activate(double NET)
        {
            return NET > 0 ? 1 : 0;
        }
    }

    public class Hamming
    {
        ZNeuron[] HopfieldLayer; //layer 1
        ANeuron[] MaxnetLayer; //layer 2
        int n, m;

        double[] MaxnetInput; //layer 1 outputs / layer 2 inputs

        /// <summary>
        /// Создаёт слой Z-нейронов
        /// </summary>
        /// <param name="n">Количество нейронов в сети</param>
        /// <param name="m">Количество входов нейрона</param>
        public Hamming(int n, int m)
        {
            this.n = n;
            this.m = m;
            HopfieldLayer = new ZNeuron[n]; // Z-layer
            MaxnetLayer = new ANeuron[n]; // A-layer
            for (int j = 0; j < n; j++)
            {
                HopfieldLayer[j] = new ZNeuron(m);
                MaxnetLayer[j] = new ANeuron();
            }
            ANeuron.Epsilon = 1.0 / n;          
        }
       
        public void InitFirstLayerWeights(int[][] v)
        {
            for (int j = 0; j < HopfieldLayer.Length; j++)
            {
                HopfieldLayer[j].initWeights(v[j]);
            }            
        }

        public void FirstlayerOut(int[] s)
        {
            MaxnetInput=new double[HopfieldLayer.Length];
            for (int i = 0; i < HopfieldLayer.Length; i++)
                MaxnetInput[i] = HopfieldLayer[i].Uout(s);
            Recognize();
        }

        private void Recognize()
        {
            // выделение максимального выходного сигнала 
            double NET;
            for (int i = 0; i < HopfieldLayer.Length; i++) //for each neuron
            {
                NET = 0;
                for (int j = 0; j < MaxnetInput.Length; j++) //for each input
                {
                    if (i != j) NET += MaxnetInput[j];
                }
                MaxnetInput[i] = ANeuron.Activate(MaxnetInput[i] - ANeuron.Epsilon * NET);
            }
        }        

        /// <summary>
        /// Сравнение массивов на эквивалентность
        /// </summary>
        /// <param name="A">Массив A</param>
        /// <param name="B">Массив B</param>
        /// <returns>true - если эквивалентны, иначе false</returns>
        private bool equal(double[] A, double[] B)
        {
            if (A.Length != B.Length) return false;
            for (int i = 0; i < A.Length; i++)
                if (A[i] != B[i]) return false;
            return true;
        }

        public int getN()
        {
            return n;
        }

        public int getM()
        {
            return m;
        }
    }
}
