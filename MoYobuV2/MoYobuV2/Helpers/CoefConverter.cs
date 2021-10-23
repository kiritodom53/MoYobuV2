using System;
using System.Globalization;
using Xamarin.Forms;

namespace MoYobuV2.Helpers
{
    public class CoefConverter : IValueConverter
    {
        // WidthRequest="{Binding Source={x:Reference Grd}, Path=Width, Converter={StaticResource cc}, ConverterParameter=0.25}"
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double coef = 1.0;

            if (parameter is string)
                coef = double.Parse(parameter as string);

            return (double)value * coef;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}