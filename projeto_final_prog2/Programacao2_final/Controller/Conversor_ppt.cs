using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Programacao2_final.Controller
{
    internal class Conversor_ppt : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
                if (int.TryParse(value.ToString(), out int carta))
                {
                    BitmapImage bmp = new BitmapImage(new Uri("/PPT/" + carta.ToString() + ".png", UriKind.Relative));
                    return bmp;
                }
                return null;
            }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
