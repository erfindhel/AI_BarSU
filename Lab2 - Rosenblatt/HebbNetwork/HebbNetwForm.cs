using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OneLayerNeuralnetwork;

namespace RosenblattLearning
{
    public partial class HebbNetwForm : Form
    {
        public const int GRID_X = 5;
        public const int GRID_Y = 5;
        public const int CELL_WIDTH = 25;
        public const int CELL_HEIGHT = 25;
        Perceptron Network; //сеть Розенблатта
        private int[] grid; // значения входов сети - 0 / 1
        private int margin;

        public HebbNetwForm()
        {
            InitializeComponent();
            grid = new int[HebbNetwForm.GRID_X * HebbNetwForm.GRID_Y];
        }

        #region FormDrawing
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            this.margin = (this.Width - (HebbNetwForm.CELL_WIDTH * HebbNetwForm.GRID_X)) / 2;
            int index = 0;

            SolidBrush brush = new SolidBrush(Color.Blue);
            Pen pen = new Pen(Color.Black);

            for (int y = 0; y < HebbNetwForm.GRID_Y; y++)
            {
                for (int x = 0; x < HebbNetwForm.GRID_X; x++)
                {
                    if (1 == this.grid[index++])
                    {
                        g.FillRectangle(brush, this.margin + (x * HebbNetwForm.CELL_WIDTH), y
                                * HebbNetwForm.CELL_HEIGHT, HebbNetwForm.CELL_WIDTH,
                                HebbNetwForm.CELL_HEIGHT);
                    }
                    else
                    {
                        g.DrawRectangle(pen, this.margin + (x * HebbNetwForm.CELL_WIDTH), y
                                * HebbNetwForm.CELL_HEIGHT, HebbNetwForm.CELL_WIDTH,
                                HebbNetwForm.CELL_HEIGHT);
                    }
                }
            }
        }

        private void HebbNetwForm_MouseDown(object sender, MouseEventArgs e)
        {
            int x = ((e.X - this.margin) / HebbNetwForm.CELL_WIDTH);
            int y = e.Y / HebbNetwForm.CELL_HEIGHT;
            if (((x >= 0) && (x < HebbNetwForm.GRID_X)) && ((y >= 0) && (y < HebbNetwForm.GRID_Y)))
            {
                int index = (y * HebbNetwForm.GRID_X) + x;
                this.grid[index] = (0 == this.grid[index]) ? 1 : 0;
            }
            this.Invalidate();
        } 
        #endregion

        // обучение сети
        private void TrainButton_Click(object sender, EventArgs e)
        {
            Network = new Perceptron((int)numericUpDown2.Value, (int)numericUpDown3.Value);
            //Network.initWeights();
            int n=Network.getN();
            for (int j = 0; j < n; j++)
                for (int i = 0; i < n; i++)
                    Network.teach(OCR.Etalon[i], OCR.outputs[i], (double)numericUpDown1.Value, int.Parse(textBox2.Text));      
        }

        // распознавание введённого образа
        private void RecognizeButton_Click(object sender, EventArgs e)
        {
            textBox3.Text = OCR.OutputToLetter(Network.recognize(grid));
        }
    }
}
