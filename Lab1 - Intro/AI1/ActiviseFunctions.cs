using System;
namespace AI1
{
    class ActiviseFunctions
    {
        //Линейная активационная функция
        public static double Lineral(double s)
        {
            return s;
        }

        //полулинейная функция
        public static double HalfLineral(double k, double s)
        {
            return s <= 0 ? 0 : s * k;
            //if (s <= 0) return 0;
            //else return s * k;
        }

        //линейная с насыщением 
        public static double FillLineral(double s)
        {
            if (s < -1) return -1;
            else if (s >= 1) return 1;
            else return s;
        }
        //пороговая
        public static double Steep(double s)
        {
            //if (s < 0) return -1; else return 1;
            return s < 0 ? -1 : 1;
        }

        //Логистическая (сигмоидальная)
        public static double Sigmaidal(double a, double s)
        {
            return 1 / (1 + Math.Pow(Math.E, -a * s));
        }
                 

        //Гиперболический тангенс
        public static double Th(double s)
        {
            return Math.Tanh(s);
        }
    }
}