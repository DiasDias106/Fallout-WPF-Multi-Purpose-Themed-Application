using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Programacao2_final.Controller
{
    internal class Controlo1 :UIElement
    {
        public Cmd cmddobro { get; set; }

        public Cmd cmdjunta { get; set; }

        public Cmd cmdinverte { get; set; }

        public Cmd cmdremove {  get; set; }

        public Controlo1()
        {
            cmdjunta = new Cmd(Junta, Canjunta);
            cmdinverte = new Cmd(Inverte, Caninverte);
            cmdremove = new Cmd(Remove, Canremove);
        }
        MainWindow main = (MainWindow)App.Current.MainWindow;

        public bool Caninverte(object parameter)
        {
            return true;
        }
        public void Inverte(object parameter)
        {
            Frases frase = (Frases)main.frame.Content;

            string fra1 = Convert.ToString(frase.txtnome.Text.Trim());
            string fra2 = Convert.ToString(frase.txtadicionar.Text.Trim());
            frase.txtnome.Text = fra1;
            frase.txtadicionar.Text = fra2;
            frase.txtresult.Text = fra2 + " " + fra1;
        }
        public void Junta(object parameter)
        {
            Frases frase = (Frases)main.frame.Content;

            string fra1 = Convert.ToString(frase.txtnome.Text.Trim());
            string fra2 = Convert.ToString(frase.txtadicionar.Text.Trim());
            frase.txtnome.Text = fra1; 
            frase.txtadicionar.Text = fra2;
            frase.txtresult.Text = fra1 + " " + fra2;
        }
        public bool Canjunta(object parameter)
        {
            return true;
        }
        public bool Canremove(object parameter)
        {
            return true;
        }
        public void Remove(object parameter)
        {
            Frases frase = (Frases)main.frame.Content;
            frase.txtresult.Text = "";
            frase.txtnome.Text = "";
            frase.txtadicionar.Text = "";
        }

    }
}
