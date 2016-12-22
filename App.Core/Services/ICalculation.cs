using System;
using System.Collections;
using System.Linq;

namespace App.Core.Services
{
    public interface ICalculation
    {
        double CalculateTip(double subtotal, int generosity);
    }
}