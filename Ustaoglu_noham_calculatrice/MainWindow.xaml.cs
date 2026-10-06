using System;
using System.Windows;
using System.Windows.Controls;

namespace NohamCalculette
{
    public partial class MainWindow : Window
    {
        double premierNombre;
        string signe;

        public MainWindow()
        {
            InitializeComponent();


            BTN_0.Click += Nombre_Click;
            BTN_1.Click += Nombre_Click;
            BTN_2.Click += Nombre_Click;
            BTN_3.Click += Nombre_Click;
            BTN_4.Click += Nombre_Click;
            BTN_5.Click += Nombre_Click;
            BTN_6.Click += Nombre_Click;
            BTN_7.Click += Nombre_Click;
            BTN_8.Click += Nombre_Click;
            BTN_9.Click += Nombre_Click;


            BTN_Plus.Click += Addition_Click;
            BTN_Moins.Click += Soustraction_Click;
            BTN_Fois.Click += Multiplication_Click;
            BTN_Divise.Click += Division_Click;


            BTN_egale.Click += Egal_Click;
            BTN_2CLR.Click += Effacer_Click;
        }



        private void Nombre_Click(object sender, RoutedEventArgs e)
        {
            Button bouton = sender as Button;

            if (bouton != null)
            {
                TB_Display.Text += bouton.Content;
            }
        }



        private void ChoisirOperation(string operation)
        {
            if (TB_Display.Text != "")
            {
                premierNombre = double.Parse(TB_Display.Text);
                signe = operation;
                TB_Display.Text = "";
            }
        }



        private void Addition_Click(object sender, RoutedEventArgs e)
        {
            ChoisirOperation("+");
        }



        private void Soustraction_Click(object sender, RoutedEventArgs e)
        {
            ChoisirOperation("-");
        }




        private void Multiplication_Click(object sender, RoutedEventArgs e)
        {
            ChoisirOperation("*");
        }




        private void Division_Click(object sender, RoutedEventArgs e)
        {
            ChoisirOperation("/");
        }



        private void Egal_Click(object sender, RoutedEventArgs e)
        {
            if (TB_Display.Text == "")
                return;

            double deuxiemeNombre = double.Parse(TB_Display.Text);
            double resultat = 0;

            if (signe == "+")
            {
                resultat = premierNombre + deuxiemeNombre;
            }
            else if (signe == "-")
            {
                resultat = premierNombre - deuxiemeNombre;
            }
            else if (signe == "*")
            {
                resultat = premierNombre * deuxiemeNombre;
            }
            else if (signe == "/")
            {
                if (deuxiemeNombre == 0)
                {
                    TB_Display.Text = "Erreur";
                    return;
                }

                resultat = premierNombre / deuxiemeNombre;
            }

            TB_Display.Text = resultat.ToString();
        }

        private void Effacer_Click(object sender, RoutedEventArgs e)
        {
            TB_Display.Text = "";
            premierNombre = 0;
            signe = "";
        }
    }
}
