using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using MvvmCross.Platform.Converters;

namespace App.Core.ValueConverters
{
    public class DoubleToStringValueConverter : MvxValueConverter<double, string>
    {
        protected override string Convert(double value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }

        protected override double ConvertBack(string value, Type targetType, object parameter, CultureInfo culture)
        {
            return double.Parse(value);
        }
    }
}