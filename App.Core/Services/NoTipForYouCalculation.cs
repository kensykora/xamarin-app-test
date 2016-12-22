using System;
using System.Collections;
using System.Linq;

namespace App.Core.Services
{
    public class NoTipForYouCalculation : ICalculation
    {
        public double CalculateTip(double subtotal, int generosity)
        {
            return 0;
        }
    }
}