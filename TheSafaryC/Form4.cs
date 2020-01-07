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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            easy es = new easy();
            this.Hide();
            es.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            medium m = new medium();
            this.Hide();
            m.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hard h = new hard();
            this.Hide();
            h.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.ShowDialog();
        }
    }
}
