using System;
using System.Collections.Generic;
using System.Text;

namespace Mandelbroth_Set
{
    public class Complex
    {
        public double a; //real part
        public double b; //imaginary part

        //constructor
        public Complex(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        //function for squaring a complex number : (a+bi)^2 = a^2 + bi^2 + 2abi -- bi^2 = -b^2
        public void Square()
        {
            double temp = (a * a) - (b * b);
            b = 2 *a*b;
            a = temp;
        }

        //function to return the magnitude of the complex number
        public double Magnitude()
        {
            return Math.Sqrt((a * a) + (b * b));
        }

        //function to add two complex numbers
        public void Add(Complex c)
        {
            a += c.a;
            b += c.b;
        }
    }
}
