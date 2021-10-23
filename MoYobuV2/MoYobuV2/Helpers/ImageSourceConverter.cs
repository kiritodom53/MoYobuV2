using System;
using System.Globalization;
using System.IO;
using System.Net;
using Xamarin.Forms;

namespace MoYobuV2.Helpers
{
    public class ImageSourceConverter : IValueConverter
    {
        static readonly WebClient client = new WebClient();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            var byteArray = client.DownloadData(value.ToString());
            return ImageSource.FromStream(() => new MemoryStream(byteArray));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}