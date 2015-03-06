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
            this.ReultTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // RecognizeButton
            // 
            this.RecognizeButton.Location = new System.Drawing.Point(12, 168);
            this.RecognizeButton.Name = "RecognizeButton";
            this.RecognizeButton.Size = new System.Drawing.Size(118, 23);
            this.RecognizeButton.TabIndex = 1;
            this.RecognizeButton.Text = "Recognize";
            this.RecognizeButton.UseVisualStyleBackColor = true;
            this.RecognizeButton.Click += new System.EventHandler(this.RecognizeButton_Click);
            // 
            // ReultTextBox
            // 
            this.ReultTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReultTextBox.Location = new System.Drawing.Point(136, 168);
            this.ReultTextBox.Name = "ReultTextBox";
            this.ReultTextBox.Size = new System.Drawing.Size(200, 22);
            this.ReultTextBox.TabIndex = 7;
            // 
            // HebbNetwForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 208);
            this.Controls.Add(this.ReultTextBox);
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
        private System.Windows.Forms.TextBox ReultTextBox;
    }
}

