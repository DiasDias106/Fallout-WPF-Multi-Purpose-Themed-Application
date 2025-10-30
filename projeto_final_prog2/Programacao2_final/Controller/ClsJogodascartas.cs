using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Programacao2_final.Controller
{
    public class ClsJogodascartas:UIElement
    {

        MainWindow main = (MainWindow)App.Current.MainWindow;
        public int Montante
        {
            get { return (int)GetValue(MontanteProperty); }
            set { SetValue(MontanteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Montante.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MontanteProperty =
            DependencyProperty.Register("Montante", typeof(int), typeof(ClsJogodascartas), new PropertyMetadata(1000));



        public int Carta1
        {
            get { return (int)GetValue(Carta1Property); }
            set { SetValue(Carta1Property, value); }
        }

        // Using a DependencyProperty as the backing store for Dado1.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Carta1Property =
            DependencyProperty.Register("Carta1", typeof(int), typeof(ClsJogodascartas), new PropertyMetadata(0));

        public void Adivinhar(int aposta)
        {
            Jogodascartas cart = (Jogodascartas)main.frame.Content;
            int num = Convert.ToInt32(cart.txtdito.Text);
            if (Montante >= aposta) { Montante -= aposta; }
            else if (Montante > 0) { aposta = Montante; Montante = 0; }
            else { aposta = 0; }

            if (aposta > 0)
            {
                Random r = new Random();
                Carta1 = r.Next(1, 14);

                if (Carta1 == num) DisparaOnPremio1(aposta);
            }
        }


        private static readonly RoutedEvent OnPremio1Event = EventManager.RegisterRoutedEvent(
            "OnPremio1",
            RoutingStrategy.Direct,
            typeof(RoutedEventHandler),
            typeof(ClsJogodascartas)
            );
        public event RoutedEventHandler OnPremio1
        {
            add { AddHandler(OnPremio1Event, value); }
            remove { RemoveHandler(OnPremio1Event, value); }
        }
        public class OnPremio1RoutedEventArgs : RoutedEventArgs
        {
            public int Aposta;

            public OnPremio1RoutedEventArgs(int aposta) : base(OnPremio1Event)
            {
                Aposta = aposta;
            }
        }

        public void DisparaOnPremio1(int aposta)
        {
            OnPremio1RoutedEventArgs args = new OnPremio1RoutedEventArgs(aposta);
            RaiseEvent(args);
        }
    }
}
