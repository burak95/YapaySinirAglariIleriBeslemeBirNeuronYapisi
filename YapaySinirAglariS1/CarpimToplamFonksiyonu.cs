using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YapaySinirAglariS1
{
    class CarpimToplamFonksiyonu : IFonksiyonlar
    {
        XVektoru x;
       
        public CarpimToplamFonksiyonu(XVektoru x)
        {
            this.x = x;
        }

        public double hesapla()
        {
            return (x.A1 * x.X1) * (x.A2 * x.X2) * (x.A3 * x.X3) * (x.A4 * x.X4) * (x.A5 * x.X5);
        }
    }
}
