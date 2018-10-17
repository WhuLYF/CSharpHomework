using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework5_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTreeSubTree1(10, 200, 310, 100, -Math.PI / 2);
        }
        private Graphics graphics;
        double th1 = 30 * Math.PI / 180;//右边的子树
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        void drawCayleyTreeSubTree1(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0) return;
            if (n == 1)
            {
                double m1 = x0 + leng * Math.Cos(th);
                double n1 = y0 + leng * Math.Sin(th);
                double m2 = x0 + leng * Math.Cos(th) * 1;
                double n2 = y0 + leng * Math.Cos(th) * 1;



                drawLine(x0, y0, m1, n1);


                drawCayleyTreeSubTree1(n - 1, m1, n1, per1 * leng, th + th1);
                drawCayleyTreeSubTree1(n - 1, m2, n2, per2 * leng, th - th2);
            }
                double x1 = x0 + leng * Math.Cos(th);
                double y1 = y0 + leng * Math.Sin(th);
                double x2 = x0 + leng * Math.Cos(th) * 0.8;
                double y2 = y0 + leng * Math.Cos(th) * 0.8;



            drawLine(x0, y0, x1, y1);


            drawCayleyTreeSubTree1(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTreeSubTree1(n - 1, x2, y2, per2 * leng*0.8, th - th2);

        }
        void drawLine(double x0,double y0,double x,double y)
        {
            graphics.DrawLine(
                Pens.Blue, (int)x0, (int)y0, (int)x, (int)y);
        }
       




    }
}
