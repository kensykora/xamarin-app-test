using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Core.Services
{
    public class TipCalculationService : ICalculation
    {
        public double CalculateTip(double subtotal, int generosity)
        {
            return subtotal * (generosity / 100d);
        }
    }
}