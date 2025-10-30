using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Programacao2_final.Controller
{
    internal class Controlo2 : UIElement
    {
        public Cmd cmdadivinha { get; set; }
        public Cmd cmdlimpar { get; set; }

        public Cmd cmddobro { get; set; }
        public Cmd cmdnumero { get; set; }
        public Cmd cmdlimpaselos { get; set; }

        int? numa;
        int temp = 0;

        public Controlo2()
        {
            cmdadivinha = new Cmd(Adivinha, Canadivinha);
            cmdlimpar = new Cmd(Limpa, Canlimpa);
            cmddobro = new Cmd(Dobro1, Candobro);
            cmdnumero = new Cmd(Numero, Cannumero);
            cmdlimpaselos = new Cmd(Limpaselos, Canlimpaselos);
        }
        MainWindow main = (MainWindow)App.Current.MainWindow;

        public bool Canadivinha(object parameter)
        {
            return true;
        }
        public void Adivinha(object parameter)
        {
            Adivinha_num n = (Adivinha_num)main.frame.Content;
            Random random = new Random();
            string parametro = parameter.ToString();
            int f = Convert.ToInt32(n.txtmostra.Text);
            int numero = Convert.ToInt32(parametro.ToString());
            if (numa == null)
            {
                numa = random.Next(1, 50);
            }
            string num = Convert.ToString(numa);
            
            if(numa < f)
            {
                n.txtresult.Text = "Errado,o numero e mais pequeno";
                temp = temp + 1;
                string path = AppDomain.CurrentDomain.BaseDirectory;
                int inx = path.LastIndexOf("bin");
                path = path.Substring(0, inx) + @"Sons_e_video\falha.wav";
                SoundPlayer player = new SoundPlayer(path);
                player.Load();
                player.Play();
            }else if (numa > f) {
                n.txtresult.Text = "Errado,o numero e maior";
                temp = temp + 1;
                string path = AppDomain.CurrentDomain.BaseDirectory;
                int inx = path.LastIndexOf("bin");
                path = path.Substring(0, inx) + @"Sons_e_video\falha.wav";
                SoundPlayer player = new SoundPlayer(path);
                player.Load();
                player.Play();
            }else
                {
                    n.txtresult.Text = $"Acertou, parabéns! O número era {num}, usou {temp} Tentativas";
                string path = AppDomain.CurrentDomain.BaseDirectory;
                int inx = path.LastIndexOf("bin");
                path = path.Substring(0, inx) + @"Sons_e_video\vitoria.wav";
                SoundPlayer player = new SoundPlayer(path);
                player.Load();
                player.Play();
            }
            }
        public bool Canlimpa(object parameter)
        {
            return true;
        }
        public void Limpa(object parameter)
        {
            Adivinha_num n = (Adivinha_num)main.frame.Content;
            n.txtmostra.Text="1";
            n.txtresult.Clear();
            numa = null;
            temp = 0;
        }
        public bool Cannumero(object parameter)
        {
            return true;
        }
        public void Numero(object parameter)
        {
            Dobro d = (Dobro)main.frame.Content;
            string destino = parameter.ToString();
            switch (destino)
            {
                case "0":
                d.textnum.Text = d.textnum.Text + "0";
                break;
                case "1":
                    d.textnum.Text = d.textnum.Text + "1";
                    break;
                case "2":
                    d.textnum.Text = d.textnum.Text + "2";
                    break;
                case "3":
                    d.textnum.Text = d.textnum.Text + "3";
                    break;
                case "4":
                    d.textnum.Text = d.textnum.Text + "4";
                    break;
                case "5":
                    d.textnum.Text = d.textnum.Text + "5";
                    break;
                case "6":
                    d.textnum.Text = d.textnum.Text + "6";
                    break;
                case "7":
                    d.textnum.Text = d.textnum.Text + "7";
                    break;
                case "8":
                    d.textnum.Text = d.textnum.Text + "8";
                    break;
                case "9":
                    d.textnum.Text = d.textnum.Text + "9";
                    break;
            }
        }
        public bool Candobro(object parameter)
        {
            
            if (string.IsNullOrEmpty(parameter.ToString())) return false;
            if (int.TryParse(parameter.ToString(), out int result)) return true;
            else return false;
        }
        public void Dobro1(object parameter)
        {
            Dobro d = (Dobro)main.frame.Content;
            int i = int.Parse(parameter.ToString());
            d.textnum.Text = (2 * i).ToString();
        }
        public bool Canlimpaselos(object parameter)
        {
            return true;
        }
        public void Limpaselos(object parameter)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            int idx = path.IndexOf("bin");
            path = path.Substring(0, idx) + "Sons_e_video\\nuclear_explosion.wav";
            SoundPlayer player = new SoundPlayer(path);
            player.Load();
            player.Play();
            Selos s = (Selos)main.frame.Content;
            s.textnum.Text = "";
            s.resultado.Content = "";
        }
    }
}
