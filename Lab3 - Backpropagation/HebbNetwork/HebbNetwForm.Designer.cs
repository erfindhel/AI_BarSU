namespace HammingAlgorythm
{
    partial class HebbNetwForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RecognizeButton = new System.Windows.Forms.Button();
            this.RateTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RecognizeButton
            // 
            this.RecognizeButton.Location = new System.Drawing.Point(135, 167);
            this.RecognizeButton.Name = "RecognizeButton";
            this.RecognizeButton.Size = new System.Drawing.Size(118, 23);
            this.RecognizeButton.TabIndex = 1;
            this.RecognizeButton.Text = "Recognize";
            this.RecognizeButton.UseVisualStyleBackColor = true;
            this.RecognizeButton.Click += new System.EventHandler(this.RecognizeButton_Click);
            // 
            // RateTextBox
            // 
            this.RateTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RateTextBox.Location = new System.Drawing.Point(59, 167);
            this.RateTextBox.Name = "RateTextBox";
            this.RateTextBox.Size = new System.Drawing.Size(70, 22);
            this.RateTextBox.TabIndex = 7;
            this.RateTextBox.Text = "0,8";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Rate";
            // 
            // HebbNetwForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 208);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RateTextBox);
            this.Controls.Add(this.RecognizeButton);
            this.Name = "HebbNetwForm";
            this.Text = "Hamming Algorythm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HebbNetwForm_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RecognizeButton;
        private System.Windows.Forms.TextBox RateTextBox;
        private System.Windows.Forms.Label label1;
    }
}

