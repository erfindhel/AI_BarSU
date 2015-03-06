using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HammingAlgorythm
{
    /// <summary>
    /// Набор распознаваемых символов
    /// </summary>
    class OCR
    {
        /// <summary>
        /// Эталонные образы (4 строки по 25 символов) - A L E X
        /// </summary>
        public static double[][] Etalon = { 
                            new double[] {0,1,1,1,0,0,1,0,1,0,0,1,1,1,0,0,1,0,1,0,0,1,0,1,0}, //A
                            new double[] {0,1,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1,1,1,0}, //L
                            new double[] {0,1,1,1,0,0,1,0,0,0,0,1,1,0,0,0,1,0,0,0,0,1,1,1,0}, //E
                            new double[] {1,0,0,0,1,0,1,0,1,0,0,0,1,0,0,0,1,0,1,0,1,0,0,0,1}  //X
                                       };

        /// <summary>
        /// Возвращает символ, соответствующий значениям выходов сети
        /// </summary>
        /// <param name="y">Результат распознавания</param>
        /// <returns>Символ либо сообщение о невозможности распознавания</returns>
        public static string OutputToLetter(int[] y)
        {
            int LetterNum=-1;
            for (int i = 0; i < outputs.GetLength(0); ++i)
            {
                if (1 == y[i])
                {
                    LetterNum = i;
                    break;
                }
            }
            switch (LetterNum)
            {
                case 0: return "A";
                case 1: return "L";
                case 2: return "E";
                case 3: return "X";
                case 4: return "T";
                case 5: return "I";
                case 6: return "U";
                case 7: return "H";
                default: return "Can't recognize";
            }
        }

        /// <summary>
        /// Эталонные значения выходов нейронов
        /// </summary>
        public static double[][] outputs = { 
                new double[] { 1, 0, 0, 0 }, //A
                new double[] { 0, 1, 0, 0 }, //L
                new double[] { 0, 0, 1, 0 }, //E
                new double[] { 0, 0, 0, 1 }  //X
                        };
    }
}
