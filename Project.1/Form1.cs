using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            const double PI = Math.PI;
            int m = int.Parse(textBox6.Text);
            double Angle1=double.Parse(textBox5.Text);
            double Angle2;
            switch (m)
            {
                case 0:
                    textBox4.Text = Convertion1(Angle1).ToString();
                    break;
                case 1:
                    textBox4.Text = Convertion2(Angle1).ToString();
                    break;
                case 2:
                    textBox4.Text = Convertion3(Angle1).ToString();
                    break;
                case 3:
                    textBox4.Text = Convertion4(Angle1).ToString();
                    break;
                case 4:
                    Angle2=Convertion4(Angle1);
                    textBox4.Text = Convertion2(Angle2).ToString();
                    break;
                case 5:
                    Angle2 = Convertion1(Angle1);
                    textBox4.Text = Convertion3(Angle2).ToString();
                    break;
            }
        }
        public double Convertion1(double A1)//弧度转十进制度；
        {
            const double PI = Math.PI;
            double A2 = A1 / PI * 180;
            return A2 ;
        }
        public double Convertion2 (double A1)//十进制转弧度；
        {
            const double PI = Math.PI;
            double A2 = A1 * PI / 180;
            return A2;
        }
        public double Convertion3(double A1)//十进制转度分秒；
        {
            double Du = Math.Truncate(A1);
            double Fen = Math.Truncate((A1 - Du) * 60);
            double Miao = ((A1 - Du) * 60 - Fen) * 60;
            double A2 = Du + Fen / 100 + Miao / 10000;
            return A2;
        }
        public double Convertion4(double A1)//度分秒转十进制度；
        {
            double Du = Math.Truncate(A1);
            double Fen = Math.Truncate((A1 - Du) * 100);
            double Miao = ((A1 - Du) * 100 - Fen) * 100;
            double A2 = Du + Fen / 60 + Miao / 3600;
            return A2;
        }
        public double Caculate1(double dx,double dy)//坐标反算；
        {
            const double PI = Math.PI;
            double a = Math.Atan(dy / dx);
            double b = a;
            if (dx == 0 && dy == 0) textBox11.Text = "坐标错误，请重新输入。";
            else if (dx == 0)
                if (dy > 0)
                    b = 0;
                else
                    b = 180;
            else if (dx < 0)
                b = (a + PI) / PI * 180;
            else
                if (dy > 0)
                    b = a / PI * 180;
                else
                    b = 0;
            return b;
        }
        public double Caculate2(double x1,double y1,double A,double S)
        {
            const double PI = Math.PI;
            double x2 = x1 + S * Math.Cos(A / 180 * PI);
            return x2;
        }
        public double Caculate3(double x1, double y1, double A, double S)
        {
            const double PI = Math.PI;
            double y2 = y1 + S * Math.Sin(A / 180 * PI);
            return y2;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double X1 = double.Parse(textBox3.Text);
            double Y1 = double.Parse(textBox7.Text);
            double A = double.Parse(textBox2.Text);
            double S = double.Parse(textBox14.Text);
            textBox1.Text = Caculate2(X1, Y1, A, S).ToString();
            textBox8.Text = Caculate3(X1, Y1, A, S).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double x1 = double.Parse(textBox13.Text);
            double y1 = double.Parse(textBox10.Text);
            double x2 = double.Parse(textBox12.Text);
            double y2 = double.Parse(textBox15.Text);
            double dx = x2 - x1;
            double dy = y2 - y1;
            textBox11.Text = Caculate1(dx,dy).ToString();
            textBox9.Text= Math.Sqrt(dx * dx + dy * dy).ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)//前方交会；
        {
            double Xa = double.Parse(textBox16.Text);
            double Ya = double.Parse(textBox17.Text);
            double Xb = double.Parse(textBox18.Text);
            double Yb = double.Parse(textBox19.Text);
            double Aa = double.Parse(textBox21.Text);
            double Ab = double.Parse(textBox22.Text);
            double Xp = (Xa / Math.Tan(Ab) + Xb / Math.Tan(Aa) - Ya + Yb) / (1 / Math.Tan(Aa) + 1 / Math.Tan(Ab));
            double Yp = (Ya / Math.Tan(Ab) + Yb / Math.Tan(Aa) + Xa - Xb) / (1 / Math.Tan(Aa) + 1 / Math.Tan(Ab));
            textBox20.Text = Xp.ToString();
            textBox23.Text = Yp.ToString();
        }

        private void button9_Click(object sender, EventArgs e)//距离交会；
        {
            double Xa = double.Parse(textBox16.Text);
            double Ya = double.Parse(textBox17.Text);
            double Xb = double.Parse(textBox18.Text);
            double Yb = double.Parse(textBox19.Text);
            double Dap = double.Parse(textBox34.Text);
            double Dbp = double.Parse(textBox33.Text);
            double Aab = Caculate1(Xb - Xa, Yb - Ya);
            double Dab = Math.Sqrt((Xb - Xa) * (Xb - Xa) + (Yb - Ya) * (Yb - Ya));
            double BAP = Rendezvous1(Dap, Dbp, Dab);
            double ABP = Rendezvous2(Dap, Dbp, Dab);
            double Aap = Aab - BAP;
            double Abp = Aap + ABP;
            textBox35.Text =( Rendezvous3(Xa, Dap, Aap)).ToString();
            textBox32.Text =( Rendezvous4(Ya, Dap, Aap)).ToString();
        }
        public double Rendezvous1(double dap,double dbp,double dab)//计算角BAP;
        {
            double Jbap=Math.Acos((dab*dab+dap*dap-dbp)/2*dab*dap);
            return Jbap;
        }
        public double Rendezvous2(double dap,double dbp,double dab)//计算角ABP;
        {
            double Jabp=Math.Acos((dab*dab+dbp*dbp-dap*dap)/2*dab*dap);
            return Jabp;
        }
        public double Rendezvous3(double x,double d,double a)//计算XP;
        {
            double X = x + d * Math.Cos(a);
            return X;
        }
        public double Rendezvous4(double y,double d,double a)//计算YP;
        {
            double Y = y + d * Math.Sin(a);
            return Y;
        }
        private void button7_Click(object sender, EventArgs e)//后方交会；
        {
            double Xa = double.Parse(textBox16.Text);
            double Ya = double.Parse(textBox17.Text);
            double Xb = double.Parse(textBox18.Text);
            double Yb = double.Parse(textBox19.Text);
            double Xc = double.Parse(textBox28.Text);
            double Yc = double.Parse(textBox26.Text);
            double a1 = double.Parse(textBox31.Text);
            double a2 = double.Parse(textBox30.Text);
            double a3 = double.Parse(textBox29.Text);
            double cota = ((Xb - Xa) * (Xc - Xa) + (Yb - Ya) * (Yc - Ya)) / ((Xb - Xa) * (Yc - Ya) - (Yb - Ya) * (Xc - Xa));
            double cotb = ((Xc - Xb) * (Xa - Xb) + (Yc - Yb) * (Ya - Yb)) / ((Xc - Xb) * (Ya - Yb) - (Yc - Yb) * (Xa - Xb));
            double cotc = ((Xa - Xc) * (Xb - Xc) + (Ya - Yc) * (Yb - Yc)) / ((Xa - Xc) * (Yb - Yc) - (Ya - Yc) * (Xb - Xc));
            double Pa = 1 / (cota - 1 / Math.Tan(a1));
            double Pb = 1 / (cotb - 1 / Math.Tan(a2));
            double Pc = 1 / (cotc - 1 / Math.Tan(a3));
            textBox27.Text = ((Pa * Xa + Pb * Xb + Pc * Xc) / (Pa + Pb + Pc)).ToString();
            textBox24.Text = ((Pa * Ya + Pb * Yb + Pc * Yc) / (Pa + Pb + Pc)).ToString();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
