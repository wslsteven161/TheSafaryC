namespace TheSafaryC
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtgiliran = new System.Windows.Forms.Label();
            this.txtstatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbfalse = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(400, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "GILIRAN :";
            // 
            // txtgiliran
            // 
            this.txtgiliran.AutoSize = true;
            this.txtgiliran.Location = new System.Drawing.Point(462, 41);
            this.txtgiliran.Name = "txtgiliran";
            this.txtgiliran.Size = new System.Drawing.Size(35, 13);
            this.txtgiliran.TabIndex = 1;
            this.txtgiliran.Text = "label2";
            // 
            // txtstatus
            // 
            this.txtstatus.AutoSize = true;
            this.txtstatus.Location = new System.Drawing.Point(462, 73);
            this.txtstatus.Name = "txtstatus";
            this.txtstatus.Size = new System.Drawing.Size(35, 13);
            this.txtstatus.TabIndex = 3;
            this.txtstatus.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(400, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "STATUS :";
            // 
            // lbfalse
            // 
            this.lbfalse.AutoSize = true;
            this.lbfalse.Location = new System.Drawing.Point(400, 101);
            this.lbfalse.Name = "lbfalse";
            this.lbfalse.Size = new System.Drawing.Size(0, 13);
            this.lbfalse.TabIndex = 4;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(599, 609);
            this.Controls.Add(this.lbfalse);
            this.Controls.Add(this.txtstatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtgiliran);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form2_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtgiliran;
        private System.Windows.Forms.Label txtstatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbfalse;
    }
}