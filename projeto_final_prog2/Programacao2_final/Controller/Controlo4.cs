using Microsoft.Win32;
using Programacao2_final.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;

namespace Programacao2_final.Controller
{
    internal class Controlo4:UIElement
    {
        public MercenariosModel mercenariosmodel { get; set; }

        public Cmd cmdmusica1 { get; set; }
        public Cmd cmdmusica2 { get; set;}

        public Cmd cmdmusica3 { get; set; }

        public Cmd cmdmusica4 { get; set; }

        public Cmd cmdmusica5 { get; set; }

        public Cmd cmdmusica6 { get; set; }

        public Cmd cmdmusica7 { get; set; }
        public Cmd cmdselos { get; set;}

        public ClsJogodados myjogo { get; set; }

        public ClsAtributos myjogo2 { get; set; }

        public ClsPPT myjogo3 { get; set; }

        public Clsgameshow myjogo4 { get; set; }

        public Cmd cmdRolar { get; set; }

        public Cmd cmdparar { get; set; }
        public ClsJogodascartas  myjogo1 { get; set; }
        public Cmd cmdAdivinhar {  get; set; }

        public Cmd cmdspecial { get; set; }

        public Cmd cmdshow {  get; set; }

        public Cmd cmdppt { get; set; }

        public Cmd cmdgravarmerc{ get; set; }

        public Cmd cmdapagarmerc { get; set; }

        public Cmd cmdincerirmerc { get; set; }

        public Cmd cmdgetfoto { get; set; }

        public Controlo4()
        {
            myjogo = new ClsJogodados();
            myjogo.OnPremio += Myjogo_OnPremio;
            myjogo1 = new ClsJogodascartas();
            myjogo1.OnPremio1 += Myjogo1_OnPremio1;
            cmdRolar = new Cmd(Rolar, canRolar);
            cmdmusica1 = new Cmd(Musica1, Canmusica1);
            cmdmusica2 = new Cmd(Musica2, Canmusica2);
            cmdmusica3 = new Cmd(Musica3, Canmusica3);
            cmdmusica4 = new Cmd(Musica4, Canmusica4);
            cmdmusica5 = new Cmd(Musica5, Canmusica5);
            cmdmusica6 = new Cmd(Musica6, Canmusica6);
            cmdmusica7 = new Cmd(Musica7, Canmusica7);
            cmdselos = new Cmd(Selos1, Canselos);
            cmdparar = new Cmd(Parar, Canparar);
            cmdAdivinhar = new Cmd(adivinhar, Canadivinhar);
            mercenariosmodel = new MercenariosModel();
            myjogo2 = new ClsAtributos();
            cmdspecial = new Cmd(Special, Canspecial);
            myjogo4 = new Clsgameshow();
            cmdshow = new Cmd(Show, Canspecial);
            myjogo3 = new ClsPPT();
            cmdppt = new Cmd(Ppt, Canppt);
            cmdgravarmerc = new Cmd(mercenariosmodel.GravaMerc,(x)=>true);
            cmdincerirmerc = new Cmd(mercenariosmodel.inserirMerc,(x)=>true);
            cmdapagarmerc = new Cmd(mercenariosmodel.apagarMerc,(x)=>true);
            cmdgetfoto = new Cmd(GetFoto, (x) => true);
        }
        MainWindow main = (MainWindow)App.Current.MainWindow;

        private void Myjogo_OnPremio(object sender, RoutedEventArgs e)
        {
            Jogodados pag = (Jogodados)main.frame.Content;
            ClsJogodados jogo = (ClsJogodados)sender;
            int premio = jogo.Dado1 * 2 * ((ClsJogodados.OnPremioRoutedEventArgs)e).Aposta;
            jogo.Montante += premio;
            StringBuilder sb = new StringBuilder();
            sb.Append("Parabens ganhou \r\n");
            sb.Append($"{premio} euros");
            pag.lblvisor.Content = "Parabens ganhou "+ premio + "";
            pag.lblvisor.Content = sb.ToString();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            int idx = path.IndexOf("bin");
            path = path.Substring(0, idx) + "Sons_e_video\\chuva_dinheiro.wav";
            SoundPlayer soundPlayer = new SoundPlayer(path);
            soundPlayer.Load();
            soundPlayer.Play();

        }
        private void Myjogo1_OnPremio1(object sender, RoutedEventArgs e)
        {
            Jogodascartas cart = (Jogodascartas)main.frame.Content;
            ClsJogodascartas jogo1 = (ClsJogodascartas)sender;
            int premio = 2 * ((ClsJogodascartas.OnPremio1RoutedEventArgs)e).Aposta;
            jogo1.Montante += premio;
            StringBuilder sb = new StringBuilder();
            sb.Append("parabens ganhou \r\n");
            sb.Append($"{premio} euros");
            //cart.txtresultado.Text = "Melhor sorte para a proxima, perdeu: " + premio + "";
            cart.txtresultado.Text = sb.ToString();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            int idx = path.IndexOf("bin");
            path = path.Substring(0, idx) + "Sons_e_video\\chuva_dinheiro.wav";
            SoundPlayer soundPlayer = new SoundPlayer(path);
            soundPlayer.Load();
            soundPlayer.Play();

        }
        public bool canRolar(Object parameter)
        {
            if (parameter == null) return false;
            if (int.TryParse(parameter.ToString(), out int aposta))
            {
                if (aposta > 0) return true;
            }
            return false;
        }
        public void Rolar(Object parameter)
        {
            Jogodados pag = (Jogodados)main.frame.Content;
            pag.lblvisor.Content = "";

            if (int.TryParse(parameter.ToString(), out int aposta))
            {
                if (aposta == 0) pag.lblvisor.Content = "Não há aposta";
                myjogo.rolar(aposta);
                if (myjogo.Montante == 0)
                {

                    pag.slider.Value = 0;
                    pag.lblvisor.Content = "Acabou o guito !!!";
                }
            }
            else
            {
                pag.lblvisor.Content = "Não há aposta";
            }
        }
        public bool Canadivinhar(Object parameter)
        {
            if (parameter == null) return false;
            if (int.TryParse(parameter.ToString(), out int aposta))
            {
                if (aposta > 0) return true;
            }
            return false;
        }
        public void adivinhar(Object parameter)
        {
            Jogodascartas cart = (Jogodascartas)main.frame.Content;
            cart.txtresultado.Text = "";


            if (int.TryParse(parameter.ToString(), out int aposta))
            {
                if (aposta == 0) cart.txtresultado.Text = "Não há aposta";
                myjogo1.Adivinhar(aposta);
                if (myjogo1.Montante == 0)
                {


                    cart.txtresultado.Text = "Acabou o guito !!!";
                }
            }
            else
            {
                cart.txtresultado.Text = "Não há aposta";
            }
        }

        public bool Canselos(object parameter)
        {
            if (string.IsNullOrEmpty(parameter.ToString())) return false;
            if (int.TryParse(parameter.ToString(), out int result)) return true;
            else return false;
        }
        public void Selos1(object parameter)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            int idx = path.IndexOf("bin");
            path = path.Substring(0, idx) + "Sons_e_video\\coletar.wav";
            SoundPlayer player = new SoundPlayer(path);
            player.Load();
            player.Play();
            Selos selar = (Selos)main.frame.Content;
            int i = int.Parse(parameter.ToString());
            int quoc, r;
            int[] resposta = new int[2] { 0, 0 };
            if (i > 8)
            {
                quoc = i / 8;
                r = i % 8;
                switch (r)
                {
                    case 0:
                        resposta[0] = quoc; resposta[1] = quoc;
                        selar.resultado.Content = "selos de 3:" + resposta[0].ToString() + "\t" + "selos de 5:" + resposta[1].ToString();
                        break;
                    case 1:
                        resposta[0] = quoc + 2; resposta[1] = quoc - 1;
                        selar.resultado.Content = "selos de 3:" + resposta[0].ToString() + "\t" + "selos de 5:" + resposta[1].ToString();
                        break;
                    case 2:
                        resposta[0] = quoc - 1; resposta[1] = quoc + 1;
                        selar.resultado.Content = "selos de 3:" + resposta[0].ToString() + "\t" + "selos de 5:" + resposta[1].ToString();
                        break;
                    case 3:
                        resposta[0] = quoc + 1; resposta[1] = quoc;
                        selar.resultado.Content = "selos de 3:" + resposta[0].ToString() + "\t" + "selos de 5:" + resposta[1].ToString();
                        break;
                    case 4:
                        resposta[0] = quoc + 3; resposta[1] = quoc - 1;
                        selar.resultado.Content = "selos de 3:" + resposta[0].ToString() + "\t" + "selos de 5:" + resposta[1].ToString();
                        break;
                    case 5:
                        resposta[0] = quoc; resposta[1] = quoc + 1;
                        selar.resultado.Content = "selos de 3:" + resposta[0].ToString() + "\t" + "selos de 5:" + resposta[1].ToString();
                        break;
                    case 6:
                        resposta[0] = quoc + 2; resposta[1] = quoc;
                        selar.resultado.Content = "selos de 3:" + resposta[0].ToString() + "\t" + "selos de 5:" + resposta[1].ToString();
                        break;
                    case 7:
                        resposta[0] = quoc - 1; resposta[1] = quoc + 2;
                        selar.resultado.Content = "selos de 3:" + resposta[0].ToString() + "\t" + "selos de 5:" + resposta[1].ToString();
                        break;
                }
            }
            else
            {
                if (i == 3) { resposta[0] = 1; resposta[1] = 0; selar.resultado.Content = resposta[0].ToString() + "\t" + resposta[1].ToString(); }
                else if (i == 5) { resposta[0] = 0; resposta[1] = 1; selar.resultado.Content = resposta[0].ToString() + "\t" + resposta[1].ToString(); }
                else if (i == 6) { resposta[0] = 2; resposta[1] = 0; selar.resultado.Content = resposta[0].ToString() + "\t" + resposta[1].ToString(); }
                else { selar.resultado.Content = "devolução de quantia:" + i; }
            }
}
        public bool Canmusica2(object parameter)
        {
            return true;
        }
        public void Musica2(object parameter)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            int inx = path.LastIndexOf("bin");
            path = path.Substring(0, inx) + @"Sons_e_video\rocket_69.wav";
            SoundPlayer player = new SoundPlayer(path);
            player.Load();
            player.Play();

        }

        public bool Canmusica3(object parameter)
        {
            return true;
        }
        public void Musica3(object parameter)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            int inx = path.LastIndexOf("bin");
            path = path.Substring(0, inx) + @"Sons_e_video\new_vegas.wav";
            SoundPlayer player = new SoundPlayer(path);
            player.Load();
            player.Play();

        }

        public bool Canmusica1(object parameter)
        {
            return true;
        }
        public void Musica1(object parameter)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            int inx = path.LastIndexOf("bin");
            path = path.Substring(0, inx) + @"Sons_e_video\five_stars.wav";
            SoundPlayer player = new SoundPlayer(path);
            player.Load();
            player.Play();

        }

        public bool Canmusica4(object parameter)
        {
            return true;
        }
        public void Musica4(object parameter)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            int inx = path.LastIndexOf("bin");
            path = path.Substring(0, inx) + @"Sons_e_video\o_explorador.wav";
            SoundPlayer player = new SoundPlayer(path);
            player.Load();
            player.Play();

        }

        public bool Canmusica5(object parameter)
        {
            return true;
        }
        public void Musica5(object parameter)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            int inx = path.LastIndexOf("bin");
            path = path.Substring(0, inx) + @"Sons_e_video\civilizacao.wav";
            SoundPlayer player = new SoundPlayer(path);
            player.Load();
            player.Play();

        }
        public bool Canmusica7(object parameter)
        {
            return true;
        }
        public void Musica7(object parameter)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            int inx = path.LastIndexOf("bin");
            path = path.Substring(0, inx) + @"Sons_e_video\lua_azul.wav";
            SoundPlayer player = new SoundPlayer(path);
            player.Load();
            player.Play();

        }
        public bool Canmusica6(object parameter)
        {
            return true;
        }
        public void Musica6(object parameter)
        {
            Random r = new Random();
            int esco = r.Next(1, 7);
            string path = AppDomain.CurrentDomain.BaseDirectory;
            int inx = path.LastIndexOf("bin");
            path = path.Substring(0, inx);
            switch (esco)
            {
                case 1:
                    path += @"Sons_e_video\civilizacao.wav";
                    break;
                case 2:
                    path += @"Sons_e_video\o_explorador.wav";
                    break;
                case 3:
                    path += @"Sons_e_video\new_vegas.wav";
                    break;
                case 4:
                    path += @"Sons_e_video\five_stars.wav";
                    break;
                case 5:
                    path += @"Sons_e_video\rocket_69.wav";
                    break;
                case 6:
                    path += @"Sons_e_video\lua_azul.wav";
                    break;
            }
            SoundPlayer player = new SoundPlayer(path);
            player.Load();
            player.Play();
            
        }

        public bool Canparar(object parameter)
        { 
            return true; 
        }
        public void Parar(object parameter)
        {
            SoundPlayer player = new SoundPlayer();
            player.Stop();
        }
        public bool Canspecial(object parameter)
        {
            return true;
        }

        public void Special(object parameter)
        {
            TesteAtributo m = (TesteAtributo)main.frame.Content;
            myjogo2.atribiur();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            int inx = path.LastIndexOf("bin");
            path = path.Substring(0, inx) + @"Sons_e_video\carta_especial.wav";
            SoundPlayer player = new SoundPlayer(path);
            player.Load();
            player.Play();
        }
        public bool Canshow(object parameter)
        {
            return true;
        }

        public void Show(object parameter)
        {
            Show_game m = (Show_game)main.frame.Content;
            myjogo4.Jshow();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            int inx = path.LastIndexOf("bin");
            path = path.Substring(0, inx) + @"Sons_e_video\carta_especial.wav";
            SoundPlayer player = new SoundPlayer(path);
            player.Load();
            player.Play();
        }

        public bool Canppt(object parameter)
        {
            if (string.IsNullOrEmpty(parameter.ToString())) return false;
            if (int.TryParse(parameter.ToString(), out int result)) return true;
            else return false;
        }

        public void Ppt(object parameter)
        {
            PedraPapelTesoura p = (PedraPapelTesoura)main.frame.Content;
            myjogo3.Jogar();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            int inx = path.LastIndexOf("bin");
            path = path.Substring(0, inx) + @"Sons_e_video\completa.wav";
            SoundPlayer player = new SoundPlayer(path);
            player.Load();
            player.Play();
        }
        public void GetFoto(object parameter)
        {
            string path = System.Environment.CurrentDirectory;
            path = path.Substring(0, path.IndexOf("bin")) + @"Fotos\";
            string fich = "";
            System.Windows.Controls.Image img = parameter as System.Windows.Controls.Image;
            OpenFileDialog dlg = new OpenFileDialog();
            string[] fichs = Directory.GetFiles(path);
            foreach (string f in fichs)
            {
                Regex r = new Regex(mercenariosmodel.MercenariosCorrente.Idmerc.ToString() + @"\.\w*");
                if (r.IsMatch(f)) File.Delete(f);
            }
            dlg.Filter = "Todos|*.*|bmp|*.bmp|png|*.png|JPG|*.jpg|JPEG|*.jpeg";
            if (dlg.ShowDialog() == true)
            {
                fich = mercenariosmodel.MercenariosCorrente.Idmerc.ToString() +
                     System.IO.Path.GetExtension(dlg.FileName);
                mercenariosmodel.MercenariosCorrente.fotopath = fich;
                path += fich;
                System.IO.File.Copy(dlg.FileName, path, true);
                mercenariosmodel.GravaMerc(null);
            }
            img.GetBindingExpression(System.Windows.Controls.Image.SourceProperty).UpdateSource();
            img.GetBindingExpression(System.Windows.Controls.Image.SourceProperty).UpdateTarget();


        }
    }
}
