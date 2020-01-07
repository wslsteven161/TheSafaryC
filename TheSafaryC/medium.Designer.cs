namespace TheSafaryC
{
    partial class medium
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
            this.lbfalse = new System.Windows.Forms.Label();
            this.txtstatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtgiliran = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbfalse
            // 
            this.lbfalse.AutoSize = true;
            this.lbfalse.Location = new System.Drawing.Point(535, 122);
            this.lbfalse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbfalse.Name = "lbfalse";
            this.lbfalse.Size = new System.Drawing.Size(0, 17);
            this.lbfalse.TabIndex = 9;
            // 
            // txtstatus
            // 
            this.txtstatus.AutoSize = true;
            this.txtstatus.Location = new System.Drawing.Point(618, 88);
            this.txtstatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtstatus.Name = "txtstatus";
            this.txtstatus.Size = new System.Drawing.Size(46, 17);
            this.txtstatus.TabIndex = 8;
            this.txtstatus.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(535, 88);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "STATUS :";
            // 
            // txtgiliran
            // 
            this.txtgiliran.AutoSize = true;
            this.txtgiliran.Location = new System.Drawing.Point(618, 48);
            this.txtgiliran.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtgiliran.Name = "txtgiliran";
            this.txtgiliran.Size = new System.Drawing.Size(46, 17);
            this.txtgiliran.TabIndex = 6;
            this.txtgiliran.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(535, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "GILIRAN :";
            // 
            // medium
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 750);
            this.Controls.Add(this.lbfalse);
            this.Controls.Add(this.txtstatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtgiliran);
            this.Controls.Add(this.label1);
            this.Name = "medium";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "medium";
            this.Load += new System.EventHandler(this.medium_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.medium_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.medium_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbfalse;
        private System.Windows.Forms.Label txtstatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtgiliran;
        private System.Windows.Forms.Label label1;
    }
}