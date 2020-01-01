namespace WindowsFormsApplication11
{
    partial class Gamme
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
            this.btnaj = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.in_gm = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnaj
            // 
            this.btnaj.Location = new System.Drawing.Point(112, 220);
            this.btnaj.Name = "btnaj";
            this.btnaj.Size = new System.Drawing.Size(75, 34);
            this.btnaj.TabIndex = 20;
            this.btnaj.Text = "Ajouter";
            this.btnaj.UseVisualStyleBackColor = true;
            this.btnaj.Click += new System.EventHandler(this.btnaj_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Intitule Gamme";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Code Gamme";
            // 
            // in_gm
            // 
            this.in_gm.Location = new System.Drawing.Point(139, 72);
            this.in_gm.Name = "in_gm";
            this.in_gm.Size = new System.Drawing.Size(119, 20);
            this.in_gm.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(334, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 21;
            this.button1.Text = "Fermer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(460, 139);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(46, 23);
            this.button4.TabIndex = 22;
            this.button4.Text = ">|";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(306, 139);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(48, 23);
            this.button3.TabIndex = 23;
            this.button3.Text = ">";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(157, 139);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(47, 23);
            this.button5.TabIndex = 24;
            this.button5.Text = "<";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(-153, 276);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(48, 23);
            this.button6.TabIndex = 25;
            this.button6.Text = "|<";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(49, 139);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(47, 23);
            this.button2.TabIndex = 24;
            this.button2.Text = "|<";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(139, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(119, 20);
            this.textBox1.TabIndex = 16;
            // 
            // Gamme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 376);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnaj);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.in_gm);
            this.Name = "Gamme";
            this.Text = "Gamme";
            this.Load += new System.EventHandler(this.Gamme_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnaj;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox in_gm;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
    }
}