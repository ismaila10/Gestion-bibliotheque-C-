using GESTION_BIBLIOTHEQUE.Model;
using GESTION_BIBLIOTHEQUE.Services;
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
using System.Windows.Shapes;

namespace GESTION_BIBLIOTHEQUE.UI
{
    /// <summary>
    /// Logique d'interaction pour ModifierInscription.xaml
    /// </summary>
    public partial class ModifierUser : Window
    {
        private bibliothequeEntities db = new bibliothequeEntities();
        int idi;
        string loginn;
        public ModifierUser(string id)
        {
            InitializeComponent();
            LoadCombo();
            idi = int.Parse(id);
            charge();
        }


        private void LoadCombo()
        {
            type_cbx.Items.Add("Simple");
            type_cbx.Items.Add("Administrateur");
        }

        private void charge()
        {
           
            IAdmin IA = new AdminsImpl();
            admins ad = new admins();
            
           
            ad = IA.FindAdminById(idi);
            int u;
            u = (int)(ad.type);
            type_cbx.SelectedIndex = u;
            id_txt.Text = ad.id.ToString();
            nom_txt.Text = ad.nom_admin;
            prenom_txt.Text = ad.prenom_admin;
            login_txt.Text = ad.login;
            email_txt.Text = ad.email_admin;
            tel_txt.Text = ad.tel_admin;
            adresse_txt.Text = ad.adresse_admin;
            password1_txt.Password = ad.password;
            password2_txt.Password = ad.password;
            loginn = ad.login;
        }

        private void Annuler_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Valider_click(object sender, RoutedEventArgs e)
        {
            IAdmin IA = new AdminsImpl();
            if (nom_txt.Text.Equals("") || prenom_txt.Text.Equals("") || login_txt.Text.Equals("") || password1_txt.Password.Equals("") || password2_txt.Password.Equals("") || tel_txt.Text.Equals("") || type_cbx.SelectedValue == null)
            {
                MessageBox.Show("Veuillez remplir tous les champs obligatoires");
            }
            else
            {
                if (!password1_txt.Password.ToString().Equals(password2_txt.Password.ToString()))
                {
                    MessageBox.Show("Les mots de passes ne sont pas identiques !!!");
                }
                else
                {
                    try
                    {
                       
                        if (IA.FindAdminByLogin(login_txt.Text) == null || login_txt.Text.Equals(loginn))
                        {
                            try
                            {
                                var quer = db.admins.Where(g => g.id == idi).FirstOrDefault();

                                quer.nom_admin = nom_txt.Text;
                                quer.prenom_admin = prenom_txt.Text;
                                quer.login = login_txt.Text;
                                quer.adresse_admin = adresse_txt.Text;
                                quer.tel_admin = tel_txt.Text;
                               quer.email_admin = email_txt.Text;
                                quer.type = type_cbx.SelectedIndex;
                                quer.password = password1_txt.Password;
                                int sauv = db.SaveChanges();
                                if (sauv != 0)
                                {
                                    MessageBox.Show("Données Modifiées !!!");
                                    this.Hide();
                                }
                                else
                                    MessageBox.Show("Non Modifiées !!!");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex + "Erreur");
                            }
                        }
                        else
                            MessageBox.Show("Ce login est déjà utilisé");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex + "Erreur");
                    }
                }
            }
        }
        
    }
}
