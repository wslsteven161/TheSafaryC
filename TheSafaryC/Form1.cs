using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheSafaryC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pbBack.Image = Image.FromFile("startback.PNG");
            pbStart.Image = Image.FromFile("start.PNG");
            pbExit.Image = Image.FromFile("exit.PNG");
        }

        private void pbStart_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.ShowDialog();
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
