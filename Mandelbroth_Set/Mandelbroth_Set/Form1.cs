using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mandelbroth_Set
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //getting the width and height of picture box
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;

            //setting max number of iteration
            int itMax = 100;

            //the given intervals
            double x0 = -2.0, xn = 0.8, y0 = -1.0, yn = 1.0;

            //normalizing x & y to the complex plane
            double xStep = (xn - x0) / width, yStep = (yn - y0) / height;

            //image to put into the form element
            Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            //looping through every pixel in the bitmap
            for (double x = x0; x < xn; x += xStep)
            {
                for (double y = y0; y < yn; y += yStep)
                {
                    //creating our complex numbers
                    Complex c = new Complex(x, y);
                    Complex z = new Complex(0, 0);

                    int it = 0;
                    do
                    {
                        it++;
                        z.Square();
                        z.Add(c);
                        if (z.Magnitude() > 2.0)
                        {
                            break;
                        }
                    }
                    while (it < itMax);

                    //calulating and casting x and y using our variables
                    int picCalcX = (int)Math.Floor((x + (-x0)) / xStep), picCalcY = (int)Math.Floor((y + (-y0))/yStep);

                    //if iteration is outside the plane color it with a specific color else color it white;
                    //Note that if it < itMax it's outside
                    if(it<itMax)
                    {
                        bm.SetPixel(picCalcX, picCalcY,Color.DarkSalmon);
                    }
                    else
                    {
                        bm.SetPixel(picCalcX, picCalcY, Color.White);
                    }    
                }
            
            }
            pictureBox1.Image = bm;
        }
    }
}
