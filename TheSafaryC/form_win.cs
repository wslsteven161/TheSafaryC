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
    public partial class form_win : Form
    {
        String warna;
        String wincause;
        String memakan;
        public form_win(String warna,String wincause,String memakan)
        {
            InitializeComponent();
            this.warna = warna;
            this.wincause = wincause;
            this.memakan = memakan;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtnama.Text != "")
            {
                highscore h = new highscore(txtnama.Text,warna,wincause,memakan);
                h.Visible = true;
                this.Close();
            }
        }
    }
}
