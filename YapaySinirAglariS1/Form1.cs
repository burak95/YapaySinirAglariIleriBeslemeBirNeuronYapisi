using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YapaySinirAglariS1
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        List<XVektoru> xVektorListesi = new List<XVektoru>();
        int k = -1;
        public Form1()
        {
            InitializeComponent();
            dgwCikti.ColumnCount = 8;
            dgwCikti.Columns[0].Name = "X1";
            dgwCikti.Columns[1].Name = "X2";
            dgwCikti.Columns[2].Name = "X3";
            dgwCikti.Columns[3].Name = "X4";
            dgwCikti.Columns[4].Name = "X5";
            dgwCikti.Columns[5].Name = "Toplam Fonksiyonu";
            dgwCikti.Columns[6].Name = "Aktivasyon Fonksiyonu";
            dgwCikti.Columns[7].Name = "Normalizasyon";

        }

        private void btnİslem_Click(object sender, EventArgs e)
        {
            if (cmbAktivasyonFonksiyonu.Text == "Aktivasyon Fonksiyonu Seç" || cmbToplamFonksiyonu.Text == "Toplam Fonksiyonu Seç" || cmbToplamFonksiyonu.Text=="" || cmbAktivasyonFonksiyonu.Text=="")
            {
                MessageBox.Show("Aktivasyon ve toplam fonksiyonu seçin");
            }
            else
            {
                xVektorListesi.Clear();


                for (int i = 0; i < Convert.ToInt16(txtVektorSayisi.Text); i++)
                {
                    double x1 = rnd.NextDouble() * (Convert.ToDouble(txtX1BuyukAralik.Text) - Convert.ToDouble(txtX1KucukAralik.Text)) + Convert.ToDouble(txtX1KucukAralik.Text);
                    double x2 = rnd.NextDouble() * (Convert.ToDouble(txtX2BuyukAralik.Text) - Convert.ToDouble(txtX2KucukAralik.Text)) + Convert.ToDouble(txtX2KucukAralik.Text);
                    double x3 = rnd.NextDouble() * (Convert.ToDouble(txtX3BuyukAralik.Text) - Convert.ToDouble(txtX3KucukAralik.Text)) + Convert.ToDouble(txtX3KucukAralik.Text);
                    double x4 = rnd.NextDouble() * (Convert.ToDouble(txtX4BuyukAralik.Text) - Convert.ToDouble(txtX4KucukAralik.Text)) + Convert.ToDouble(txtX4KucukAralik.Text);
                    double x5 = rnd.NextDouble() * (Convert.ToDouble(txtX5BuyukAralik.Text) - Convert.ToDouble(txtX5KucukAralik.Text)) + Convert.ToDouble(txtX5KucukAralik.Text);
                    if (ckbNormalizasyon.Checked)
                    {
                        x1 = normalizasyon(x1, Convert.ToDouble(txtX1BuyukAralik.Text), Convert.ToDouble(txtX1KucukAralik.Text));
                        x2 = normalizasyon(x2, Convert.ToDouble(txtX2BuyukAralik.Text), Convert.ToDouble(txtX2KucukAralik.Text));
                        x3 = normalizasyon(x3, Convert.ToDouble(txtX3BuyukAralik.Text), Convert.ToDouble(txtX3KucukAralik.Text));
                        x4 = normalizasyon(x4, Convert.ToDouble(txtX4BuyukAralik.Text), Convert.ToDouble(txtX4KucukAralik.Text));
                        x5 = normalizasyon(x5, Convert.ToDouble(txtX5BuyukAralik.Text), Convert.ToDouble(txtX5KucukAralik.Text));
                    }
                    double a1 = rnd.NextDouble();
                    double a2 = rnd.NextDouble();
                    double a3 = rnd.NextDouble();
                    double a4 = rnd.NextDouble();
                    double a5 = rnd.NextDouble();
                    XVektoru vi = new XVektoru(x1, x2, x3, x4, x5, a1, a2, a3, a4, a5);
                    xVektorListesi.Add(vi);

                }

                for (int i = 0; i < Convert.ToInt16(txtVektorSayisi.Text); i++)
                {
                    k++;
                    k = dgwCikti.Rows.Add();
                    if (cmbToplamFonksiyonu.Text == "Çarpım")
                    {
                        if (cmbAktivasyonFonksiyonu.Text == "Doğrusal")
                        {
                            IFonksiyonlar t = new CarpimToplamFonksiyonu(xVektorListesi[i]);
                            IFonksiyonlar a = new DoğrusalAktivasyonFonksiyonu(t.hesapla());
                            yazdir(k, i, t, a);

                        }
                        else if (cmbAktivasyonFonksiyonu.Text == "Step")
                        {
                            IFonksiyonlar t = new CarpimToplamFonksiyonu(xVektorListesi[i]);
                            IFonksiyonlar a = new DoğrusalAktivasyonFonksiyonu(t.hesapla());
                        }
                        else
                        {
                            IFonksiyonlar t = new CarpimToplamFonksiyonu(xVektorListesi[i]);
                            IFonksiyonlar a = new DoğrusalAktivasyonFonksiyonu(t.hesapla());
                        }

                    }
                    else if (cmbToplamFonksiyonu.Text == "Maksimum")
                    {
                        if (cmbAktivasyonFonksiyonu.Text == "Doğrusal")
                        {
                            IFonksiyonlar t = new MaksimumToplamFonksiyonu(xVektorListesi[i]);
                            IFonksiyonlar a = new DoğrusalAktivasyonFonksiyonu(t.hesapla());
                            yazdir(k, i, t, a);
                        }
                        else if (cmbAktivasyonFonksiyonu.Text == "Step")
                        {
                            IFonksiyonlar t = new MaksimumToplamFonksiyonu(xVektorListesi[i]);
                            IFonksiyonlar a = new DoğrusalAktivasyonFonksiyonu(t.hesapla());
                        }
                        else
                        {
                            IFonksiyonlar t = new MaksimumToplamFonksiyonu(xVektorListesi[i]);
                            IFonksiyonlar a = new DoğrusalAktivasyonFonksiyonu(t.hesapla());
                        }
                    }
                    else if (cmbToplamFonksiyonu.Text == "Minimum")
                    {
                        if (cmbAktivasyonFonksiyonu.Text == "Doğrusal")
                        {
                            IFonksiyonlar t = new MinimumToplamFonksiyonu(xVektorListesi[i]);
                            IFonksiyonlar a = new DoğrusalAktivasyonFonksiyonu(t.hesapla());
                            yazdir(k, i, t, a);
                        }
                        else if (cmbAktivasyonFonksiyonu.Text == "Step")
                        {
                            IFonksiyonlar t = new MinimumToplamFonksiyonu(xVektorListesi[i]);
                            IFonksiyonlar a = new DoğrusalAktivasyonFonksiyonu(t.hesapla());
                        }
                        else
                        {
                            IFonksiyonlar t = new MinimumToplamFonksiyonu(xVektorListesi[i]);
                            IFonksiyonlar a = new DoğrusalAktivasyonFonksiyonu(t.hesapla());
                        }
                    }
                    else if (cmbToplamFonksiyonu.Text == "Çoğunluk")
                    {
                        if (cmbAktivasyonFonksiyonu.Text == "Doğrusal")
                        {
                            IFonksiyonlar t = new CarpimToplamFonksiyonu(xVektorListesi[i]);
                            IFonksiyonlar a = new DoğrusalAktivasyonFonksiyonu(t.hesapla());
                        }
                        else if (cmbAktivasyonFonksiyonu.Text == "Step")
                        {
                            IFonksiyonlar t = new CarpimToplamFonksiyonu(xVektorListesi[i]);
                            IFonksiyonlar a = new DoğrusalAktivasyonFonksiyonu(t.hesapla());
                        }
                        else
                        {
                            IFonksiyonlar t = new CarpimToplamFonksiyonu(xVektorListesi[i]);
                            IFonksiyonlar a = new DoğrusalAktivasyonFonksiyonu(t.hesapla());
                        }
                    }
                    else
                    {
                        if (cmbAktivasyonFonksiyonu.Text == "Doğrusal")
                        {
                            IFonksiyonlar t = new CarpimToplamFonksiyonu(xVektorListesi[i]);
                            IFonksiyonlar a = new DoğrusalAktivasyonFonksiyonu(t.hesapla());
                        }
                        else if (cmbAktivasyonFonksiyonu.Text == "Step")
                        {
                            IFonksiyonlar t = new CarpimToplamFonksiyonu(xVektorListesi[i]);
                            IFonksiyonlar a = new DoğrusalAktivasyonFonksiyonu(t.hesapla());
                        }
                        else
                        {
                            IFonksiyonlar t = new CarpimToplamFonksiyonu(xVektorListesi[i]);
                            IFonksiyonlar a = new DoğrusalAktivasyonFonksiyonu(t.hesapla());
                        }
                    }
                }

            }
        }
        void yazdir (int k,int i,IFonksiyonlar t,IFonksiyonlar a)
        {
            
            dgwCikti.Rows[k].Cells[0].Value = xVektorListesi[i].X1;
            dgwCikti.Rows[k].Cells[1].Value = xVektorListesi[i].X2;
            dgwCikti.Rows[k].Cells[2].Value = xVektorListesi[i].X3;
            dgwCikti.Rows[k].Cells[3].Value = xVektorListesi[i].X4;
            dgwCikti.Rows[k].Cells[4].Value = xVektorListesi[i].X5;
            dgwCikti.Rows[k].Cells[5].Value = t.hesapla();
            dgwCikti.Rows[k].Cells[6].Value = a.hesapla();
            if (ckbNormalizasyon.Checked==false)
            {
                dgwCikti.Rows[k].Cells[7].Value = "SEÇİLİ DEĞİL";
            }
            else
            {
                dgwCikti.Rows[k].Cells[7].Value = "SEÇİLİ";
            }

        }
        double normalizasyon(double gercek,double enbuyuk,double enkucuk)
        {
            return (gercek-enkucuk)/(enbuyuk-enkucuk);
        }
    }
}
