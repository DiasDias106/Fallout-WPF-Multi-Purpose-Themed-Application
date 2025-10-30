using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Programacao2_final.Controller
{
    internal class Clsgameshow:UIElement
    {
        MainWindow main = (MainWindow)App.Current.MainWindow;

        public int Jogo
        {
            get { return (int)GetValue(JogoProperty); }
            set { SetValue(JogoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Jogo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty JogoProperty =
            DependencyProperty.Register("Jogo", typeof(int), typeof(Clsgameshow), new PropertyMetadata(0));


        public void Jshow()
        {
            Show_game m = (Show_game)main.frame.Content;
            Random r = new Random();
            Jogo = r.Next(1, 9);
            if (Jogo == 1)
            {
                m.lblconteudo.Content = "Fallout 4 personagem principal";
            }
            else if (Jogo == 2)
            {
                m.lblconteudo.Content = "Armas do jogo";
            }
            else if (Jogo == 3)
            {
                m.lblconteudo.Content = "Power Armor";
            }
            else if (Jogo == 4)
            {
                m.lblconteudo.Content = "Brotherhood of steel";
            }
            else if (Jogo == 5)
            {
                m.lblconteudo.Content = "Minute Man";
            }
            else if (Jogo == 6)
            {
                m.lblconteudo.Content = "Institute";
            }
            else if(Jogo == 7)
            {
                m.lblconteudo.Content = "Todas as fações";
            }
            else {
                m.lblconteudo.Content = "Railroad";
            }

          


        }
    }
}
