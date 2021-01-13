using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace KonverteringModel
{
    public class Konvertering
    {
        public static double TilSvenskeKroner(double danskeKroner, double rate)
        {
            return danskeKroner * rate;
        }

        public static double TilDanskeKroner(double svenskeKroner, double rate)
        {
            return svenskeKroner * 1/rate;
        }
    }
}
