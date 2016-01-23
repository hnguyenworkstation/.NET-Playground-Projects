using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_SINCOS
{
    public class FuntionLib
    {
        // Calculate Cos(X);
        // Cos (X) = x^0/0! - x^2/2! + x^4/4! - ...
        // Use it for epsilon = 10^-06 == 1e-06

        public static double calCosX(double x)
        {
            const double epsilon = 1e-06;
            double cosX = 1;
            int i = 0;
            double P = (-x * x) / ((i + 1)*(i + 2));

            while(Math.Abs(P) >= epsilon)
            {
                cosX += P;
                i += 2;
                P *= (-x * x) / ((i + 1) * (i + 2));
            }

            return cosX + P;
        }

        // Calculate sin(X);
        // sin (X) = x^1/1 - x^3/3! + x^5/5! - ...
        // Use it for epsilon = 10^-07 == 1e-07

        public static double calSinX(double x)
        {
            const double epsilon = 1e-07;
            double sinX = 0;
            int i = -1;
            double P = x;

            while (Math.Abs(P) >= epsilon)
            {
                sinX += P;
                i += 2;
                P *= (-x * x) / ((i + 1) * (i + 2));
            }

            return sinX + P;
        }
    }
}
