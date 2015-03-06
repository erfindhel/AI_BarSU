using System;

namespace OneLayerNeuralnetwork
{
    /// <summary>
    /// Нейрон
    /// </summary>
    public class Neuron
    {
        /// <summary>
        /// Вектор весов
        /// </summary>
        private double[] w;

        /// <summary>
        /// Создаёт нейрон с заданным количеством входов
        /// </summary>
        /// <param name="m">Количество входов</param>
        public Neuron(int m)
        {
            w = new double[m];
            initWeights(ref w);
        }

        /// <summary>
        /// Инициализация весовых к-тов нейрона
        /// </summary>
        /// <param name="w">ссылка на вектор весовых коэфф-тов</param>
        static void initWeights(ref double[] w)
        {
            Random rand = new Random();
            for (int i = 0; i < w.Length; i++)
                w[i] = rand.NextDouble();
        }

        /// <summary>
        /// Модификация весов
        /// </summary>
        /// <param name="v">Скорость обучения</param>
        /// <param name="d">Ошибка</param>
        /// <param name="x">Входной вектор</param>
        public void changeWeights(double a, double e, int[] x)
        {
            for (int i = 0; i < w.Length; i++)
                w[i] += a * x[i] * e;
        }

        /// <summary>
        /// Суммирует сигналы синапсов
        /// </summary>
        /// <param name="x">сигналы синапсов</param>
        /// <returns>Сумма сигналов</returns>
        public double Summ(int[] x)
        {
            double NET = 0;
            for (int i = 0; i < x.Length; i++)
                NET += x[i] * w[i];
            return NET;
        }
    }

    /// <summary>
    /// Перцептрон Розенблатта
    /// </summary>
    public class Perceptron
    {
        Neuron[] neurons;
        int n, m;

        /// <summary>
        /// Создаёт перцептрон Розенблатта
        /// </summary>
        /// <param name="n">Количество нейронов в сети</param>
        /// <param name="m">Количество входов нейрона</param>
        public Perceptron(int n, int m)
        {
            this.n = n;
            this.m = m;
            neurons = new Neuron[n];
            for (int j = 0; j < n; j++)
                neurons[j] = new Neuron(m);
        }
       
        /// <summary>
        /// Распознавание образа
        /// </summary>
        /// <param name="x">Входной вектор</param>
        /// <returns>Выход сети</returns>
        public int[] recognize(int[] x)
        {
            int[] y = new int[neurons.Length];
            for (int j = 0; j < neurons.Length; j++)
                y[j] = SteepFunction(neurons[j].Summ(x));
            return y;
        }

        /// <summary>
        /// Пороговая активационная функция
        /// </summary>
        /// <param name="NET">Сумма сигналов</param>
        /// <returns>Выход нейрона</returns>
        public static int SteepFunction(double NET)
        {
            if (NET >= 0) return 1;
            else return 0;
        }

        /// <summary>
        /// Обучение
        /// </summary>
        /// <param name="x">Эталонный входной вектор</param>
        /// <param name="y">Эталонный выходной вектор</param>
        /// <param name="a">скорость обучения</param>
        /// <param name="e">Ошибка обучения</param>       
        public void teach(int[] x, int[] y, double a, double error)
        {
            int[] t = recognize(x);
            double e = 0;
            while (!equal(t, y))
            //while(e!=error)
            {
                for (int j = 0; j < neurons.Length; j++)
                {
                    e = y[j] - t[j];
                    neurons[j].changeWeights(a, e, x);
                }
                t = recognize(x);
            }
        }

        /// <summary>
        /// Сравнение массивов на эквивалентность
        /// </summary>
        /// <param name="A">Массив A</param>
        /// <param name="B">Массив B</param>
        /// <returns>true - если эквивалентны, иначе false</returns>
        private bool equal(int[] A, int[] B)
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
