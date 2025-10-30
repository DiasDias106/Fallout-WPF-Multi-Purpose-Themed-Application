using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Programacao2_final.Controller
{
    internal class ClsPPT :UIElement
    {


        public int Jogador1
        {
            get { return (int)GetValue(Jogador1Property); }
            set { SetValue(Jogador1Property, value); }
        }

        // Using a DependencyProperty as the backing store for Jogador1.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Jogador1Property =
            DependencyProperty.Register("Jogador1", typeof(int), typeof(ClsPPT), new PropertyMetadata(0));



        public int Jogador2
        {
            get { return (int)GetValue(Jogador2Property); }
            set { SetValue(Jogador2Property, value); }
        }

        // Using a DependencyProperty as the backing store for Jogador2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Jogador2Property =
            DependencyProperty.Register("Jogador2", typeof(int), typeof(ClsPPT), new PropertyMetadata(0));

        MainWindow main = (MainWindow)App.Current.MainWindow;
        public void Jogar()
        {
            PedraPapelTesoura p = (PedraPapelTesoura)main.frame.Content;
            Random r = new Random();
            Jogador1 = r.Next(1, 4);
            string valor = p.txtescolhe.Text;
            Jogador2 = Convert.ToInt32(valor);
            
        }
    }
}
