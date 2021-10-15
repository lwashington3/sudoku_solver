using System.Windows.Forms;

namespace Sudoku
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.OverallBox = new System.Windows.Forms.GroupBox();
            this.Submit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OverallBox
            // 
            this.OverallBox.Location = new System.Drawing.Point(32, 28);
            this.OverallBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OverallBox.Name = "OverallBox";
            this.OverallBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OverallBox.Size = new System.Drawing.Size(OverallSize, OverallSize);
            this.OverallBox.TabIndex = 2;
            this.OverallBox.TabStop = false;
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(558, 93);
            this.Submit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(86, 31);
            this.Submit.TabIndex = 81;
            this.Submit.Text = "Solve Me!";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 424);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.OverallBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Sudoku Solver";
            this.ResumeLayout(false);

        }

        #endregion

        private CustomGroupBox[][] Squares;
        private GroupBox OverallBox;
        private Button Submit;
    }
}

