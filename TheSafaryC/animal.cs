using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSafaryC
{
    class animal
    {
        public int x;
        public int y;
        public int power;
        public String pemilik;
        public bool dalamair;
        public bool dalamtrap;
        public animal(int x,int y,int power,String pemilik)
        {
            this.x = x;
            this.y = y;
            this.power = power;
            this.pemilik = pemilik;
            dalamtrap = false;
            dalamair = false;
        }
    }
}
