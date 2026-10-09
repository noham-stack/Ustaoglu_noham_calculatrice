
using System;
using System.Globalization;
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

            // Bouton virgule décimale
            BTN_Virgule.Click += Virgule_Click;
        }

        private void Nombre_Click(object sender, RoutedEventArgs e)
        {
            Button bouton = sender as Button;

            if (bouton != null)
            {
                if (TB_Display.Text == "Erreur" ||
                    TB_Display.Text == "Dépassement")
                {
                    TB_Display.Text = "";
                }

                TB_Display.Text += bouton.Content.ToString();
            }
        }

        private void Virgule_Click(object sender, RoutedEventArgs e)
        {
            if (TB_Display.Text == "Erreur" ||
                TB_Display.Text == "Dépassement")
            {
                TB_Display.Text = "";
            }

            // Autoriser une seule virgule
            if (!TB_Display.Text.Contains(",") &&
                !TB_Display.Text.Contains("."))
            {
                if (TB_Display.Text == "")
                    TB_Display.Text = "0,";
                else
                    TB_Display.Text += ",";
            }
        }

        private bool LireNombre(string texte, out double nombre)
        {
            return double.TryParse(
                texte,
                NumberStyles.Float,
                CultureInfo.GetCultureInfo("fr-FR"),
                out nombre
            ) && !double.IsInfinity(nombre)
              && !double.IsNaN(nombre);
        }

        private void ChoisirOperation(string operation)
        {
            double nombre;

            if (!LireNombre(TB_Display.Text, out nombre))
            {
                TB_Display.Text = "Erreur";
                return;
            }

            premierNombre = nombre;
            signe = operation;
            TB_Display.Text = "";
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
            double deuxiemeNombre;

            if (signe == null || signe == "")
                return;

            if (!LireNombre(TB_Display.Text, out deuxiemeNombre))
            {
                TB_Display.Text = "Erreur";
                signe = "";
                return;
            }

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
                    TB_Display.Text = "Erreur : division par 0";
                    signe = "";
                    return;
                }

                resultat = premierNombre / deuxiemeNombre;
            }

            // Vérifier le dépassement numérique
            if (double.IsInfinity(resultat) || double.IsNaN(resultat))
            {
                TB_Display.Text = "Dépassement";
                signe = "";
                return;
            }

            // Afficher le résultat avec la virgule française
            TB_Display.Text = resultat.ToString(
                CultureInfo.GetCultureInfo("fr-FR"));

            signe = "";
        }

        private void Effacer_Click(object sender, RoutedEventArgs e)
        {
            TB_Display.Text = "";
            premierNombre = 0;
            signe = "";
        }
    }
}