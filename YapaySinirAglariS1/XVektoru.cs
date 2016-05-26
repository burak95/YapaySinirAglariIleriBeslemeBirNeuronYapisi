using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YapaySinirAglariS1
{
    class XVektoru
    {
        private double x1, x2, x3, x4, x5;
        private double a1, a2, a3, a4, a5;
      
        public XVektoru (double x1, double x2, double x3, double x4, double x5, double a1, double a2, double a3, double a4, double a5)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
            this.x4 = x4;
            this.x5 = x5;
            this.a1 = a1;
            this.a2 = a2;
            this.a3 = a3;
            this.a4 = a4;
            this.a5 = a5;
        }

        public double X1
        {
            get
            {
                return x1;
            }

            set
            {
                x1 = value;
            }
        }

        public double X2
        {
            get
            {
                return x2;
            }

            set
            {
                x2 = value;
            }
        }

        public double X3
        {
            get
            {
                return x3;
            }

            set
            {
                x3 = value;
            }
        }

        public double X4
        {
            get
            {
                return x4;
            }

            set
            {
                x4 = value;
            }
        }

        public double X5
        {
            get
            {
                return x5;
            }

            set
            {
                x5 = value;
            }
        }

        public double A1
        {
            get
            {
                return a1;
            }

            set
            {
                a1 = value;
            }
        }

        public double A2
        {
            get
            {
                return a2;
            }

            set
            {
                a2 = value;
            }
        }

        public double A3
        {
            get
            {
                return a3;
            }

            set
            {
                a3 = value;
            }
        }

        public double A4
        {
            get
            {
                return a4;
            }

            set
            {
                a4 = value;
            }
        }

        public double A5
        {
            get
            {
                return a5;
            }

            set
            {
                a5 = value;
            }
        }
    }
}
