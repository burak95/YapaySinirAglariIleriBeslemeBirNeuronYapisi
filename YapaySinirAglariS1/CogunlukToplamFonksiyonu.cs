using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YapaySinirAglariS1
{
    class CogunlukToplamFonksiyonu : IFonksiyonlar
    {
        XVektoru x;
        double[] dizi = new double[5];

        public CogunlukToplamFonksiyonu(XVektoru x)
        {
            this.x = x;
        }
        public double hesapla()
        {

            dizi[0] = x.A1 * x.X1;
            dizi[1] = x.A2 * x.X2;
            dizi[2] = x.A3 * x.X3;
            dizi[3] = x.A4 * x.X4;
            dizi[4] = x.A5 * x.X5;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (dizi[i] < dizi[j])
                    {
                        double temp = dizi[i];
                        dizi[i] = dizi[j];
                        dizi[j] = temp;
                    }
                }
            }

            return dizi[0];
        }
    }
}
