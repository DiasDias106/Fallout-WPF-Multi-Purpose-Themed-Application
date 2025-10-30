using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Programacao2_final.Controller
{
    internal class ClsAtributos :UIElement
    {


        public int Atributo
        {
            get { return (int)GetValue(AtributoProperty); }
            set { SetValue(AtributoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Atributo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AtributoProperty =
            DependencyProperty.Register("Atributo", typeof(int), typeof(ClsAtributos), new PropertyMetadata(0));

        public void atribiur()
        {
            Random r = new Random();
            Atributo = r.Next(1, 8);

        }
    }
}
