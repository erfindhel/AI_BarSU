using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HammingAlgorythm
{
    public partial class HebbNetwForm : Form
    {
        public const int GRID_X = 5;
        public const int GRID_Y = 5;
        public const int CELL_WIDTH = 25;
        public const int CELL_HEIGHT = 25;
        Hamming Network;
        private int[] grid; // значения входов сети - -1 / 1
        private int margin;

        public HebbNetwForm()
        {
            InitializeComponent();
            grid = new int[HebbNetwForm.GRID_X * HebbNetwForm.GRID_Y];
            for (int i = 0; i < grid.Length; i++)
                grid[i] = -1;
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
                this.grid[index] = (-1 == this.grid[index]) ? 1 : -1;
            }
            this.Invalidate();
        } 
        #endregion

        // распознавание введённого образа
        private void RecognizeButton_Click(object sender, EventArgs e)
        {
            Network = new Hamming(OCR.Etalon.GetLength(0), grid.Length, OCR.Etalon);
            string recognized = OCR.OutputToLetter(Network.Recognize(grid));
            ReultTextBox.Text = ("Can't recognize" == recognized) ? recognized : "This letter seems to be: " + recognized;
        }
    }
}
