using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YapaySinirAglariS1
{
    class DoğrusalAktivasyonFonksiyonu : IFonksiyonlar
    {
        double fnet;
        public DoğrusalAktivasyonFonksiyonu(double fnet)
        {
            this.fnet=fnet;
        }

        public double hesapla()
        {
            return fnet;
        }
    }
}
