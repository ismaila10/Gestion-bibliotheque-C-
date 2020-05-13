using GESTION_BIBLIOTHEQUE.Model;
using GESTION_BIBLIOTHEQUE.Services;
using GESTION_BIBLIOTHEQUE.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GESTION_BIBLIOTHEQUE
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IAdmin IA;
        private bibliothequeEntities db = new bibliothequeEntities();
        public MainWindow()
        {
            InitializeComponent();
           
        }

        /*private void ShowPasswordCharsCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            MyPasswordBox.Visibility = System.Windows.Visibility.Collapsed;
            MyTextBox.Visibility = System.Windows.Visibility.Visible;

            MyTextBox.Focus();
        }

        private void ShowPasswordCharsCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            MyPasswordBox.Visibility = System.Windows.Visibility.Visible;
            MyTextBox.Visibility = System.Windows.Visibility.Collapsed;

            MyPasswordBox.Focus();
        }*/

        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Connexion(object sender, RoutedEventArgs e)
        {   IA = new AdminsImpl();
            IHistorique IH = new HistoriqueImpl();
            admins us= IA.FindAdminByLoginPassword(login_txt.Text.Trim(), password_txt.Password.Trim());
            if (us != null)
            {
                if (us.statut == 1)
                {
                    historique i = new historique();
                    i.admin_id = us.id;
                    i.date_debut_cnx = DateTime.UtcNow;

                    var m = 0;
                    if (IH.ListHistorique().Count == 0)
                    {
                        m = 0;
                    }
                    else
                    {
                        m = IH.ListHistorique().LastOrDefault().id;
                    }

                    i.id = m + 1;

                    if (IH.AddHistorique(i))
                    {
                        Menu me = new Menu(i.id);
                        me.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Erreur DE CONNEXION SVP !!!");
                    }
                }
                else
                    MessageBox.Show("Votre statut ne vous permet pas de se connecter !!!");
            }
            else
            {
                if (login_txt.Text.Trim().Equals("") || password_txt.Password.ToString().Equals(""))
                {
                    MessageBox.Show("Veuillez saisir tous les champs SVP !!!");
                }
                else
                {
                    MessageBox.Show("Login ou mot de passe incorrect !!!!!");
                }   
            }
        }
        
    }
}
