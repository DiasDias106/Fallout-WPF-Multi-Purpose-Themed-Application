using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Programacao2_final.Controller
{
    internal class Controlo3 :UIElement
    {
        public Cmd cmdnum { get; set; }
        public Cmd cmdopera { get; set; }
        
        public Cmd cmdlimpar { get; set; }

        public bool mudado;

        public Byte operacoes;

        float numeros, ans;
        float r = 0;

        public Controlo3()
        {
            cmdnum = new Cmd(Exenum, canExenum);
            cmdopera = new Cmd(Exeopera, canExeopera);
            cmdlimpar = new Cmd(Limpar, Canlimpar);
        }

        MainWindow main = (MainWindow)App.Current.MainWindow;


        public void Exeopera(Object parameter)
        {
            Calculadora c = (Calculadora)main.frame.Content;
            string destino = parameter.ToString();
            switch (destino)
            {
                case "+":
                    if (mudado == true)
                    {
                        operacoes = 1;
                    }
                    else
                    {
                        if (c.txtconta.Text != "")
                        {
                            operacao(operacoes);
                        }
                        numeros = float.Parse(c.txtconta.Text);
                        c.txtmostra.Text = c.txtconta.Text + "+";
                        c.txtconta.Clear();
                        c.txtconta.Focus();
                        mudado = true;
                        operacoes = 1;
                    }
                    break;
                case "-":
                    if (mudado == true)
                    {
                        operacoes = 2;
                        Sinais(operacoes);
                    }
                    else
                    {
                        if (c.txtconta.Text != "")
                        {
                            operacao(operacoes);
                        }

                        c.txtmostra.Text = c.txtconta.Text + "-";
                        if (c.txtconta.Text != "")
                        {
                            numeros = float.Parse(c.txtconta.Text);
                            c.txtconta.Clear();
                            c.txtconta.Focus();
                            operacoes = 2;
                            mudado = true;
                        }
                    }
                    break;
                case "x":
                    if (mudado == true)
                    {
                        operacoes = 3;
                        Sinais(operacoes);
                    }
                    else
                    {
                        if (c.txtconta.Text != "")
                        {
                            operacao(operacoes);
                        }
                        c.txtmostra.Text = c.txtconta.Text + "*";
                        numeros = float.Parse(c.txtconta.Text);
                        c.txtconta.Clear();
                        c.txtconta.Focus();
                        mudado = true;
                        operacoes = 3;

                    }
                    break;
                case "/":
                    if (mudado == true)
                    {
                        operacoes = 4;
                        Sinais(operacoes);
                    }
                    else
                    {
                        if (c.txtconta.Text != "")
                        {
                            operacao(operacoes);
                        }
                        c.txtmostra.Text = c.txtconta.Text + "/";
                        numeros= float.Parse(c.txtconta.Text);
                        c.txtconta.Clear();
                        c.txtconta.Focus();
                        mudado = true;
                        operacoes = 4;

                    }
                    break;
                case "%":
                    if (mudado == true)
                    {
                        operacoes = 5;
                        Sinais(operacoes);
                    }
                    else
                    {
                        if (c.txtconta.Text != "")
                        {
                            operacao(operacoes);
                        }
                        c.txtmostra.Text = c.txtconta.Text + "%";
                        numeros = float.Parse(c.txtconta.Text);
                        c.txtconta.Clear();
                        c.txtconta.Focus();
                        mudado = true;
                        operacoes = 5;
                    }
                    break;
                case "=":
                    operacao(operacoes);
                    break;
            }
        }

        private void Sinais(byte operaçoes)
        {
            Calculadora c = (Calculadora)main.frame.Content;

            int espacos = c.txtmostra.SelectionLength - 1;
            string texto = c.txtmostra.Text;
            c.txtmostra.Clear();
            for (int pos = 0; pos < espacos; pos++)
            {
                c.txtmostra.Text = c.txtmostra.Text + texto[pos];
            }
            switch (operaçoes)
            {
                case 1:
                    c.txtmostra.Text = c.txtmostra.Text + "+";
                    break;
                case 2:
                    c.txtmostra.Text = c.txtmostra.Text + "-";
                    break;
                case 3:
                    c.txtmostra.Text = c.txtmostra.Text + "*";
                    break;
                case 4:
                    c.txtmostra.Text = c.txtmostra.Text + "/";
                    break;
                case 5:
                    c.txtmostra.Text = c.txtmostra.Text + "%";
                    break;
                case 6:
                    c.txtmostra.Text = c.txtmostra.Text + ",";
                    break;

            }

        }


        public void operacao(byte operaçoes)
        {
            Calculadora c = (Calculadora)main.frame.Content;
            switch (operaçoes)
            {

                case 1:
                    ans = numeros + float.Parse(c.txtconta.Text);
                    c.txtmostra.Clear();
                    c.txtmostra.Text = numeros.ToString() + "+" + float.Parse(c.txtconta.Text);
                    c.txtconta.Text = ans.ToString();
                    break;
                case 2:
                    ans = numeros - float.Parse(c.txtconta.Text);
                    c.txtmostra.Clear();
                    c.txtmostra.Text = numeros.ToString() + "-" + float.Parse(c.txtconta.Text);
                    c.txtconta.Text = ans.ToString();
                    break;
                case 3:
                    ans = numeros * float.Parse(c.txtconta.Text);
                    c.txtmostra.Clear();
                    c.txtmostra.Text = numeros.ToString() + "*" + float.Parse(c.txtconta.Text);
                    c.txtconta.Text = ans.ToString();
                    break;
                case 4:
                    ans = numeros / float.Parse(c.txtconta.Text);
                    c.txtmostra.Clear();
                    c.txtmostra.Text = numeros.ToString() + "/" + float.Parse(c.txtconta.Text);
                    c.txtconta.Text = ans.ToString();
                    break;
                case 5:
                    ans = numeros % float.Parse(c.txtconta.Text);
                    c.txtmostra.Clear();
                    c.txtmostra.Text = numeros.ToString() + "%" + float.Parse(c.txtconta.Text);
                    c.txtconta.Text = ans.ToString();
                    break;
            }
        }

        public bool canExeopera(object obj)
        {
            return true;
        }


        public void Exenum(Object parameter)
        {
            Calculadora c = (Calculadora)main.frame.Content;
            string destino = parameter.ToString();
            mudado = false;
            switch (destino)
            {
                case "1":
                    c.txtconta.Text = c.txtconta.Text.ToString() + "1";
                    break;
                case "2":
                    c.txtconta.Text = c.txtconta.Text.ToString() + "2";
                    break;
                case "3":
                    c.txtconta.Text = c.txtconta.Text.ToString() + "3";
                    break;
                case "4":
                    c.txtconta.Text = c.txtconta.Text.ToString() + "4";
                    break;
                case "5":
                    c.txtconta.Text = c.txtconta.Text.ToString() + "5";
                    break;
                case "6":
                    c.txtconta.Text = c.txtconta.Text.ToString() + "6";
                    break;
                case "7":
                    c.txtconta.Text = c.txtconta.Text.ToString() + "7";
                    break;
                case "8":
                    c.txtconta.Text = c.txtconta.Text.ToString() + "8";
                    break;
                case "9":
                    c.txtconta.Text = c.txtconta.Text.ToString() + "9";
                    break;
                case "0":
                    c.txtconta.Text = c.txtconta.Text.ToString() + "0";
                    break;
                case ",":
                    c.txtconta.Text = c.txtconta.Text.ToString() + ",";
                    break;
                case "raiz":
                    try
                    {
                        double number = double.Parse(c.txtconta.Text);
                        double result = Math.Sqrt(number);
                        c.txtconta.Text = result.ToString();
                    }
                    catch (Exception)
                    {
                        c.txtconta.Text = "Erro";
                    }
                    break;
                case "x2":
                    try
                    {
                        double number = double.Parse(c.txtconta.Text);
                        double result = Math.Pow(number, 2);
                        c.txtconta.Text = result.ToString();
                    }
                    catch (Exception)
                    {
                        c.txtconta.Text = "Erro";
                    }
                    break;

                default:
                    break;
            }
        }



        public bool canExenum(object obj)
        {
            return true;
        }
        public bool Canlimpar(object parameter)
        {
            return true;
        }
        public void Limpar(object parameter)
        {
            Calculadora c =(Calculadora) main.frame.Content;
            c.txtconta.Clear();
            c.txtmostra.Clear();
            numeros = 0;
            ans = 0;
            operacoes = 0;
        }
    }
}
