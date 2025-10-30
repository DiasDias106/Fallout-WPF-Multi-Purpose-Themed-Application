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
    public class Merc_conversor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string caminho = System.Environment.CurrentDirectory;
            caminho = caminho.Substring(0, caminho.IndexOf("bin")) + @"Fotos\";
            if (value == null || String.IsNullOrEmpty(value.ToString()))
            {
                caminho = caminho + "nofoto.png";
            }
            else caminho = caminho + value.ToString();
            BitmapImage bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.CacheOption = BitmapCacheOption.OnLoad;
            bmp.CreateOptions = BitmapCreateOptions.DelayCreation;
            bmp.UriSource = new Uri(caminho);
            bmp.EndInit();
            return bmp;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
