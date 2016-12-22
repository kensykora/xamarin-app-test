using System;
using System.Collections.Generic;
using System.Linq;
using App.Core.Services;
using MvvmCross.Core.ViewModels;

namespace App.Core.ViewModels
{
    public class TipViewModel : MvxViewModel
    {
        private readonly ICalculation _calculator;
        private int _generosity;
        private double _subtotal;
        private double _tip;

        public TipViewModel(ICalculation calculator)
        {
            _calculator = calculator;
        }


        public int Generosity
        {
            get { return _generosity; }
            set
            {
                _generosity = value;
                RaisePropertyChanged(() => Generosity);
                Recalculate();
            }
        }

        public double Subtotal
        {
            get { return _subtotal; }
            set
            {
                _subtotal = value;
                RaisePropertyChanged(() => Subtotal);
                Recalculate();
            }
        }

        public double Tip
        {
            get { return _tip; }
            set
            {
                _tip = value;
                RaisePropertyChanged(() => Tip);
            }
        }

        private void Recalculate()
        {
            Tip = _calculator.CalculateTip(Subtotal, Generosity);
        }
    }
}