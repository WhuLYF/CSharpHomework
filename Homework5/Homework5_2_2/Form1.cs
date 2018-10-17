using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework5_2_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTreeSubTree1(10, 200, 310, 100, -Math.PI / 2);
        }
        private Graphics graphics;
        double th1;//右边的子树
        double th2;
        double per1;
        double per2;
       
        
        //获得右子树长度比例
        void getRightPer()
        {
            string s = this.textBox1.Text;
            this.per1 = Double.Parse(s);
        }

        //获得左子树长度比例
        void getLeftPer()
        {
            string s = this.textBox2.Text;
            this.per2 = Double.Parse(s);
        }

        //获得右侧的角度
        void getRightTh()
        {
            string s = this.textBox3.Text;
            double i = Double.Parse(s);
            this.th1 = i * Math.PI / 180;
        }

        //获得左侧的角度
        void getLeftTh()
        {
            string s = this.textBox4.Text;
            double i = Double.Parse(s);
            this.th2 = i * Math.PI / 180;
        }

        //获取颜色
        string getColor()
        {
            string s = this.textBox5.Text;
            return s;
        }

        void drawCayleyTreeSubTree1(int n, double x0, double y0, double leng, double th)
        {
            getLeftPer();
            getRightPer();
            getRightTh();
            getLeftTh();

            if (n == 0)
            {
                return;
            }

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
   
            drawLine(x0, y0, x1, y1);

            drawCayleyTreeSubTree1(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTreeSubTree1(n - 1, x1, y1, per2 * leng, th - th2);

        }
        void drawLine(double x0, double y0, double x, double y)
        {
            getColor();
            graphics.DrawLine(
                Pens.Yellow, (int)x0, (int)y0, (int)x, (int)y);
        }













        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
