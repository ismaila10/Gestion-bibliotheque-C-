using GESTION_BIBLIOTHEQUE.Model;
using GESTION_BIBLIOTHEQUE.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour Gestion_Gestion_User.xaml
    /// </summary>
    public partial class Gestion_User : UserControl
    {
        bibliothequeEntities db = new bibliothequeEntities();
        IAdmin IA;
        public Gestion_User()
        {
            InitializeComponent();
            LoadCombo();
            charge();
        }

        private void LoadCombo()
        {
            type_cbx.Items.Add("Simple");
            type_cbx.Items.Add("Administrateur");
        }

        private void charge()
        {


            var resu = from us in db.admins
                       where us.type == 0 && us.delete==0
                       select new Organisation_user
                       {   Numero=us.id.ToString(),
                           Nom = us.nom_admin,
                           Prenom = us.prenom_admin,
                           Telephone = us.tel_admin,
                           Login = us.login,
                           Email = us.email_admin,
                           Adresse = us.adresse_admin,
                           Statut = us.statut.ToString()
                       };


          
            List<Organisation_user> li = new List<Organisation_user>();
            foreach(Organisation_user org in resu.ToList())
            {
                if (int.Parse(org.Statut) == 0)
                     org.Statut = "bloqué";
                else
                    org.Statut = "actif";
                li.Add(org);
            }
            datauser.ItemsSource = li;

            nombre_txt.Text = "   " + resu.Count().ToString();

            var his = from l in db.historique
                      from a in db.admins
                      where l.admin_id == a.id
                      orderby l.id descending
                      select new Organisation_historique
                      {
                          Date_debut = l.date_debut_cnx.ToString(),
                          Date_fin = l.date_fin_cnx.ToString(),

                          Nom = a.nom_admin,
                          Prenom = a.prenom_admin,
                          Login = a.login
                      };

            datahistorique.ItemsSource = his.ToList();
        }


        private void Valider_click(object sender, RoutedEventArgs e)
        {
            if (nom_txt.Text.Equals("")|| prenom_txt.Text.Equals("")|| login_txt.Text.Equals("")|| password1_txt.Password.Equals("")|| password2_txt.Password.Equals("") || tel_txt.Text.Equals("") || type_cbx.SelectedValue==null)
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
                        client cl = new client();
                        IClient icl = new ClientImpl();
                        inscription ins = new inscription();
                        IInscription iins = new InscriptionImpl();

                        IA = new AdminsImpl();
                        //Ajout produit
                        admins a = new admins();
                        a.login = login_txt.Text;
                        a.tel_admin = tel_txt.Text;
                        a.prenom_admin = prenom_txt.Text;
                        a.nom_admin = nom_txt.Text;
                        a.password = password1_txt.Password;
                        a.email_admin = email_txt.Text;
                        a.adresse_admin = adresse_txt.Text;
                        a.statut = 1;
                        a.delete = 0;
                        a.type = type_cbx.SelectedIndex;
                        if (IA.FindAdminByLogin(login_txt.Text)==null)
                        {
                            bool o = IA.AddAdmin(a);
                            if (o)
                            {
                                MessageBox.Show("utilisateur Ajouté");
                                Vider();
                            }
                            else
                                MessageBox.Show("Données non enregistrées");
                            charge();

                        }
                        else
                        {
                             MessageBox.Show("Ce login est déjà utilisé");
                        }


                }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex + "Erreur");
                    }

                }
               
            }
        }



        private void Vider()
        {
            nom_txt.Text = "";
            prenom_txt.Text = "";
            adresse_txt.Text = "";
            login_txt.Text = "";
            tel_txt.Text = "";
            email_txt.Text = "";
            type_cbx.SelectedValue = null;
            password1_txt.Password = "";
            password2_txt.Password = "";
        }

        private void modifier_bt_Click(object sender, RoutedEventArgs e)
        {
            if (!iduser_txt.Text.Equals(""))
            {
                //this.Hide();
                ModifierUser ges = new ModifierUser(iduser_txt.Text);
                ges.ShowDialog();
                iduser_txt.Text = "";
                charge();
            }
            else
                MessageBox.Show("Veuillez Séléctionner une ligne");
        }
        private void supprimer_bt_Click(object sender, RoutedEventArgs e)
        { int n;
            n = int.Parse(iduser_txt.Text);
            if (!iduser_txt.Text.Equals(""))
            {
                var query = db.admins.Where(p => p.id == n).FirstOrDefault();
                query.delete = 1;
                int o = db.SaveChanges();
                if (o != 0)
                {
                    MessageBox.Show("Données Supprimées");
                    iduser_txt.Text = "";
                    charge();
                }
                else
                    MessageBox.Show("Non Supprimées");
                charge();
            }
            else
                MessageBox.Show("Veuillez Séléctionner une ligne");
        }

        private void datauser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   
            IA = new AdminsImpl();
            Organisation_user ad = datauser.SelectedValue as Organisation_user;
            if (ad != null)
            {
                iduser_txt.Text = ad.Numero;
            }
            
        }

        private void Annuler_click(object sender, RoutedEventArgs e)
        {
            Vider();

        }
      
        

        private void ListRecherche(string login)
        {
            
            var resu = from us in db.admins
                       where us.type == 0 && us.delete == 0 && (us.login.Contains(login))
                       select new Organisation_user
                       {
                           Numero = us.id.ToString(),
                           Nom = us.nom_admin,
                           Prenom = us.prenom_admin,
                           Telephone = us.tel_admin,
                           Login = us.login,
                           Email = us.email_admin,
                           Adresse = us.adresse_admin,
                           Statut = us.statut.ToString()
                       };

            List<Organisation_user> li = new List<Organisation_user>();
            foreach (Organisation_user org in resu.ToList())
            {
                if (int.Parse(org.Statut) == 0)
                    org.Statut = "bloqué";
                else
                    org.Statut = "actif";
                li.Add(org);
            }
            datauser.ItemsSource = li;

            nombre_txt.Text = "   " + resu.Count().ToString();
        }
        private void rech_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListRecherche(rech_txt.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error is " + ex.ToString());
            }
        }
        private void ListRechercheHisto(string login)
        {
            var his = from l in db.historique
                      from a in db.admins
                      where l.admin_id == a.id && (a.login.Contains(login))
                      orderby l.id descending
                      select new Organisation_historique
                      {
                          Date_debut = l.date_debut_cnx.ToString(),
                          Date_fin = l.date_fin_cnx.ToString(),

                          Nom = a.nom_admin,
                          Prenom = a.prenom_admin,
                          Login = a.login
                      };

            datahistorique.ItemsSource = his.ToList();
        }
        private void rechhis_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListRechercheHisto(rechhis_txt.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error is " + ex.ToString());
            }
        }

        private void bloquer_bt_Click(object sender, RoutedEventArgs e)
        {
            
            IA = new AdminsImpl();
            admins ad = new admins();
            int idd;
            if (!iduser_txt.Text.Equals(""))
            {
                ad = IA.FindAdminById(int.Parse(iduser_txt.Text));
                if (ad.statut != 0)
                {
                    idd = int.Parse(iduser_txt.Text);
                    var quer = db.admins.Where(g => g.id == idd).FirstOrDefault();
                    quer.statut = 0;
                    int o = db.SaveChanges();

                    if (o != 0)
                    {
                       charge();
                       MessageBox.Show("Données Modifiées");
                        datauser.SelectedValue = null;
                    }
                    else
                        MessageBox.Show("Non Modifiées");
                   iduser_txt.Text = "";
                }
               else
                   MessageBox.Show("utilisateur est déja bloqué");

            }
            else
            {
               MessageBox.Show("Veuillez Séléctionner une ligne");
            }
        }

        private void debloquer_bt_Click(object sender, RoutedEventArgs e)
        {
            IA = new AdminsImpl();
            admins ad = new admins();
            int idd;
            if (!iduser_txt.Text.Equals(""))
            {
                ad = IA.FindAdminById(int.Parse(iduser_txt.Text));
                if (ad.statut != 1)
                {
                    idd = int.Parse(iduser_txt.Text);
                    var quer = db.admins.Where(g => g.id == idd).FirstOrDefault();
                    quer.statut = 1;
                    int o = db.SaveChanges();
                    if (o != 0)
                    {
                        charge();
                        MessageBox.Show("Données Modifiées");
                    }
                    else
                        MessageBox.Show("Non Modifiées");
                   iduser_txt.Text = "";

                }
                else
                    MessageBox.Show("utilisateur est déja actif");

            }
            else
            {
                MessageBox.Show("Veuillez Séléctionner une ligne");
            }

        }

        private void recherchedate_Click(object sender, RoutedEventArgs e)
        {
            if (datedebutp_dtp.SelectedDate > datefinp_dtp.SelectedDate)
            {
                MessageBox.Show("Date début ne peut venir aprés date fin");
                charge();
            }
            else if (datedebutp_dtp.SelectedDate.ToString().Equals("") || datefinp_dtp.SelectedDate.ToString().Equals(""))
            {
                MessageBox.Show("Veuillez choisir une période");
            }
            else
            {
                var his = from h in db.historique
                          from a in db.admins
                          where h.admin_id == a.id && h.date_debut_cnx >= datedebutp_dtp.SelectedDate && h.date_debut_cnx <= datefinp_dtp.SelectedDate
                          orderby h.id descending
                          select new Organisation_historique
                          {
                              Date_debut = h.date_debut_cnx.ToString(),
                              Date_fin = h.date_fin_cnx.ToString(),

                              Nom = a.nom_admin,
                              Prenom = a.prenom_admin,
                              Login = a.login
                          };
                datarecherchedate.ItemsSource = his.ToList();
            }
        }
    }
}