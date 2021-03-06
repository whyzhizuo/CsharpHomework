﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homewor8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Graphics graphics;
        double th1 = 30 * Math.PI / 180;
        double th2 = 30 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        int height = 10;

        bool isDrawed = false;

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            isDrawed = true;
            Console.WriteLine(this.Location.X + " " + this.Location.Y);
            drawTree(height, 200, 310, 100, -Math.PI/2);
        }

         void drawTree(int n, double x0, double y0, double length, double th)
        {
            if (n == 0) return;
            double x1 = x0 + length * Math.Cos(th);
            double y1 = y0 + length * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            drawTree(n - 1, x1, y1, per1 * length, th + th1);
            drawTree(n - 1, x1, y1, per2 * length, th - th2);
        }

        void drawLine(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(Pens.Black,
                (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!isDrawed) return;
            graphics.Clear(Color.White);
            drawTree(height, 200, 310, 100, -Math.PI / 2);
        }

        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            th2 = e.NewValue >= 30 ? (e.NewValue <= 60 ? e.NewValue : 60) : 30;
            th2 = th1 * Math.PI / 180;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            height = e.NewValue / 10 + 5;
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            th1 = e.NewValue >= 30 ? (e.NewValue <= 60 ? e.NewValue : 60) : 30;
            th1 = th1 * Math.PI / 180;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void hScrollBar4_Scroll(object sender, ScrollEventArgs e)
        {
            per1 = e.NewValue / 100 + 0.1;
        }

        private void hScrollBar5_Scroll(object sender, ScrollEventArgs e)
        {
            per2 = e.NewValue / 100 + 0.1;
        }
    }
}
