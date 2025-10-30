using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Programacao2_final.Controller
{
    internal class Controlo
    {
        public Cmd cmdnavegar { get; set; }
        public Cmd cmdsair { get; set; }
        public Cmd cmdadivinha { get; set; }
        public Cmd cmdlimpar { get; set; }


        public Controlo()
        {
            cmdnavegar = new Cmd(Navegar, Cannavegar);
            cmdsair = new Cmd(Sair, Cansair);
            cmdadivinha = new Cmd(Adivinha, Canadivinha);
            cmdlimpar = new Cmd(Limpar, Canlimpar);
        }

        MainWindow main = (MainWindow)App.Current.MainWindow;

        public bool Cansair(object parameter)
        {
            return true;
        }
        public void Sair(object parameter)
        {
            App.Current.Shutdown();
        }
        public bool Cannavegar(object parameter)
        {
            if (string.IsNullOrEmpty(main.frame.Source.ToString())) return true;
            if (String.IsNullOrEmpty(parameter.ToString())) return false;
            string corrente = main.frame.Source.ToString();
            string destino = parameter.ToString();
            if (corrente.Contains(destino)) return false;
            return true;
        }
        public void Navegar(object parameter)
        {
            string destino = parameter.ToString();
            switch (destino)
            {
                case "inicio":
                    main.frame.Source = new Uri("Inicio.xaml", UriKind.Relative);
                    break;
                case "Dobro":
                    main.frame.Source = new Uri("Dobro.xaml", UriKind.Relative);
                    break;
                case "Selos":
                    main.frame.Source = new Uri("Selos.xaml", UriKind.Relative);
                    break;
                case "jogodados":
                    main.frame.Source = new Uri("Jogodados.xaml", UriKind.Relative);
                    break;
                case "adivinha":
                    main.frame.Source = new Uri("Adivinha_num.xaml",UriKind.Relative);
                    break;
                case "frase":
                    main.frame.Source = new Uri("Frases.xaml", UriKind.Relative);
                    break;
                case "calculadora":
                    main.frame.Source = new Uri("Calculadora.xaml", UriKind.Relative);
                    break;
                case "musc2":
                    main.frame.Source = new Uri("M2.xaml", UriKind.Relative);
                    break;
                case "card":
                    main.frame.Source = new Uri("Jogodascartas.xaml", UriKind.Relative);
                    break;
                case "r1":
                    main.frame.Source = new Uri("Regras1.xaml", UriKind.Relative);
                    break;
                case "r2":
                    main.frame.Source = new Uri("Regras2.xaml", UriKind.Relative);
                    break;
                case "r3":
                    main.frame.Source = new Uri("Regras3.xaml", UriKind.Relative);
                    break;
                case "r4":
                    main.frame.Source = new Uri("Regras4.xaml", UriKind.Relative);
                    break;
                case "r5":
                    main.frame.Source = new Uri("Regras5.xaml", UriKind.Relative);
                    break;
                case "r6":
                    main.frame.Source = new Uri("Regras6.xaml", UriKind.Relative);
                    break;
                case "r7":
                    main.frame.Source = new Uri("Regras7.xaml", UriKind.Relative);
                    break;
                case "r8":
                    main.frame.Source = new Uri("Regras8.xaml", UriKind.Relative);
                    break;
                case "r9":
                    main.frame.Source = new Uri("Regras9.xaml", UriKind.Relative);
                    break;
                case "ct1":
                    main.frame.Source = new Uri("Mercenarios_Hub.xaml", UriKind.Relative);
                    break;
                case "Sp":
                    main.frame.Source = new Uri("TesteAtributo.xaml", UriKind.Relative);
                    break;
                case "ppt":
                    main.frame.Source = new Uri("PedraPapelTesoura.xaml", UriKind.Relative);
                    break;
                case "GS":
                    main.frame.Source = new Uri("Show_game.xaml", UriKind.Relative);
                    break;
                default:
                    main.frame.Source = new Uri("Inicio.xaml", UriKind.Relative);
                    break;

            }
        }
        public bool Canadivinha(object parameter)
        {
            if (string.IsNullOrEmpty(parameter.ToString())) return false;
            if (int.TryParse(parameter.ToString(), out int result)) return true;
            else return false;
        }
        public void Adivinha(object parameter)
        {
            Adivinha_num ad = (Adivinha_num)main.frame.Content;
            Random random = new Random();
            string parametro = parameter.ToString();
            int numa = random.Next(0, 1001);
            int numero = Convert.ToInt32(parametro);
            int temp = 10;
            while (temp != 0)
            {
                if (numero != numa)
                {
                    ad.txtresult.Text = "Errado";
                    temp = temp - 1;
                }
                else
                {
                    ad.txtresult.Text = "acertou" + "," + "parabens\t" + numa;
                }
            }
        }
        public bool Canlimpar(object parameter)
        {
            return true;
        }
        public void Limpar(object parameter)
        {
            Adivinha_num ad = (Adivinha_num)main.frame.Content;
            ad.txtmostra.Clear();
            ad.txtresult.Clear();
        }
    }
}
