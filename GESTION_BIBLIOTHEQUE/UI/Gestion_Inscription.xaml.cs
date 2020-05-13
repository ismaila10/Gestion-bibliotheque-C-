
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
    /// Logique d'interaction pour Gestion_Inscription.xaml
    /// </summary>
    public partial class Gestion_Inscription : UserControl
    {
        private bibliothequeEntities db = new bibliothequeEntities();
        public Gestion_Inscription()
        {
            InitializeComponent();
            dataInscriptionencours.SelectedItem= null;
            //dataInscriptionencours.ItemsSource = db.inscription.ToList();
            mat_txt.Text = matricule();
            dateinsc_dtp.Text = DateTime.UtcNow.ToShortDateString();
            dateech_dtp.Text = DateTime.UtcNow.AddYears(1).ToShortDateString();
            montant_txt.Text = "500";

            charge();
        }

        private void charge()
        {
            ModifStatutList();
           
            var resul = from ins in db.inscription
                        join cl in db.client
                        on ins.client_id equals cl.id
                        where ins.delet == 1
                        select new Organisation
                        {
                            Matricule = ins.matricule,
                            Nom = cl.nom_client,
                            Prenom = cl.prenom_client,
                            Tel = cl.tel_client,
                            Date_Inscription = (DateTime)ins.date_inscription,
                            Date_Echeance = (DateTime)ins.date_echeance,
                            Montant = ins.montant_ins.ToString(),
                            Statut = "supprimé",
                        };
            
         
            dataInscription_supprime.ItemsSource = resul.ToList();
            nombre_txt.Text = "   "+resul.Count().ToString();
          
            var resultat = from ins in db.inscription
                        join cl in db.client
                        on ins.client_id equals cl.id
                        where ins.statut == 1 && ins.delet == 0
                           select new Organisation
                        {
                            Matricule = ins.matricule,
                            Nom = cl.nom_client,
                            Prenom = cl.prenom_client,
                            Tel = cl.tel_client,
                            Date_Inscription = (DateTime)ins.date_inscription,
                            Date_Echeance = (DateTime)ins.date_echeance,
                            Montant = ins.montant_ins.ToString(),
                            Statut = "activé",
                        };
            dataInscriptionencours.ItemsSource = resultat.ToList();
            nombre_encours_txt.Text = "   " + resultat.Count().ToString();

            var resu = from ins in db.inscription
                       join cl in db.client
                       on ins.client_id equals cl.id
                       where ins.statut == 0 && ins.delet == 0
                       select new Organisation
                       {
                           Matricule = ins.matricule,
                           Nom = cl.nom_client,
                           Prenom = cl.prenom_client,
                           Tel = cl.tel_client,
                           Date_Inscription = (DateTime)ins.date_inscription,
                           Date_Echeance = (DateTime)ins.date_echeance,
                           Montant = ins.montant_ins.ToString(),
                           Statut = "invalide",
                       };
            dataInvalide.ItemsSource = resu.ToList();
            nombreinvalide_txt.Text = "   " + resu.Count().ToString();
            
        }
       
        private void reset()
        {
            nom_txt.Text = "";
            prenom_txt.Text = "";
            adresse_txt.Text = "";
            tel_txt.Text = "";
            email_txt.Text = "";
            datenaiss_dtp.Text = "";
        }
        
        private void Valider_click(object sender, RoutedEventArgs e)
        {
            if (nom_txt.Text.Equals("")|| prenom_txt.Text.Equals("") || tel_txt.Text.Equals("") || montant_txt.Text.Equals("") || datenaiss_dtp.Text.Equals("") || datenaiss_dtp.Text.Equals("") || dateech_dtp.Text.Equals("") )
            {
                MessageBox.Show("Veuillez remplir tous les champs obligatoires");
            }
            else
            {
                int mt;
                if (!int.TryParse(montant_txt.Text, out mt))
                {
                    MessageBox.Show("Le montant doit etre de type entier");
                }
                else
                {
                    try
                    {
                        client cl = new client();
                        IClient icl = new ClientImpl();
                        inscription ins = new inscription();
                        IInscription iins = new InscriptionImpl();
                        var m = 0;
                        if (icl.ListClient().Count == 0)
                        {
                            m = 0;
                        }
                        else
                        {
                            m = icl.ListClient().LastOrDefault().id;
                        }

                        cl.id = m + 1;
                        cl.nom_client = nom_txt.Text;
                        cl.prenom_client = prenom_txt.Text;
                        cl.adresse_client = adresse_txt.Text;
                        cl.tel_client = tel_txt.Text;
                        cl.email_client = email_txt.Text;
                        cl.date_naissance = DateTime.Parse(datenaiss_dtp.SelectedDate.ToString());
                        icl.AddClient(cl);

                        var u = 0;
                        if (iins.ListInscription().Count == 0)
                        {
                            u = 0;
                        }
                        else
                        {
                            u = iins.ListInscription().LastOrDefault().id;
                        }
                        ins.id = u + 1;
                        ins.matricule = matricule();
                        ins.montant_ins = int.Parse(montant_txt.Text);
                        ins.date_echeance = DateTime.Parse(dateech_dtp.SelectedDate.ToString());
                        ins.date_inscription = DateTime.Parse(dateinsc_dtp.SelectedDate.ToString());
                        ins.statut = 1;
                        ins.delet = 0;
                        ins.client_id = cl.id;

                        IHistorique his = new HistoriqueImpl();
                        int n = his.ListHistorique().LastOrDefault().admins.id;

                        ins.admin_id = n;
                        int o = iins.AddInscription(ins);
                        if (o != 0)
                        {
                            MessageBox.Show("Inscription " + ins.matricule + " Ajoutée");
                            reset();
                            charge();
                            mat_txt.Text = matricule();
                        }
                        else
                            MessageBox.Show("Données non enregistrées");
                        charge();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex + "Erreur");
                    }
                }
            }
        }


        private void Annuler_click(object sender, RoutedEventArgs e)
        {
            reset();
        }

        public String matricule()
        {
            inscription ins = new inscription();
            IInscription iins = new InscriptionImpl();
            List<inscription> lmvt = new List<inscription>();
            Fonction f = new Fonction();
            string s;
            if (iins.ListInscription().Count == 0)
            {
                s = "B0001";
            }
            else
            {
                lmvt = iins.ListInscription();
                ins = lmvt.LastOrDefault();
                s = f.GetNextCode(ins.matricule);
            }
            return s;
        }

        private void datainscription_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Organisation org = dataInscriptionencours.SelectedValue as Organisation;
            if (org != null)
                iso_txt.Text = org.Matricule;
            
        }

        private void ListRechercheInscrit(string matricule)
        {
            List<Object> lis = new List<object>();
            var resul = from ins in db.inscription
                        join cl in db.client
                        on ins.client_id equals cl.id
                        where ins.delet == 1 && (ins.matricule.Contains(matricule))
                        select new Organisation
                        {
                            Matricule = ins.matricule,
                            Nom = cl.nom_client,
                            Prenom = cl.prenom_client,
                            Tel = cl.tel_client,
                            Date_Inscription = (DateTime)ins.date_inscription,
                            Date_Echeance = (DateTime)ins.date_echeance,
                            Montant = ins.montant_ins.ToString(),
                            Statut = "supprimé",
                        };
            dataInscription_supprime.ItemsSource = resul.ToList();
            nombre_txt.Text = "   " + resul.Count().ToString();
        }

        private void ListRechercheInscritencours(string matricule)
        {
            List<Object> lis = new List<object>();
            var resul = from ins in db.inscription
                        join cl in db.client
                        on ins.client_id equals cl.id
                        where ins.statut == 1 && ins.delet == 0 && (ins.matricule.Contains(matricule))
                        select new Organisation
                        {
                            Matricule = ins.matricule,
                            Nom = cl.nom_client,
                            Prenom = cl.prenom_client,
                            Tel = cl.tel_client,
                            Date_Inscription = (DateTime)ins.date_inscription,
                            Date_Echeance = (DateTime)ins.date_echeance,
                            Montant = ins.montant_ins.ToString(),
                            Statut = "activé",
                        };
            dataInscriptionencours.ItemsSource = resul.ToList();
            nombre_encours_txt.Text = "   " + resul.Count().ToString();
        }

        private void ListRechercheInvalide(string matricule)
        {
            List<Object> lis = new List<object>();
            var resul = from ins in db.inscription
                        join cl in db.client
                        on ins.client_id equals cl.id
                        where ins.statut == 0 && ins.delet == 0 && (ins.matricule.Contains(matricule))
                        select new Organisation
                        {
                            Matricule = ins.matricule,
                            Nom = cl.nom_client,
                            Prenom = cl.prenom_client,
                            Tel = cl.tel_client,
                            Date_Inscription = (DateTime)ins.date_inscription,
                            Date_Echeance = (DateTime)ins.date_echeance,
                            Montant = ins.montant_ins.ToString(),
                            Statut = "Invalide",
                        };
            dataInvalide.ItemsSource = resul.ToList();
            nombreinvalide_txt.Text = "   " + resul.Count().ToString();
        }

        private void recherche_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListRechercheInscritencours(recherche_en_cours_txt.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error is " + ex.ToString());
            }
        }

        private void modifier_btn_Click(object sender, RoutedEventArgs e)
        {
            if (!iso_txt.Text.Equals(""))
            {
               
                ModifierInscription ges = new ModifierInscription(iso_txt.Text);
                ges.ShowDialog();
                if(ges.IsActive==false)
                    charge();
            }
            else
            {
                MessageBox.Show("Veuillez Séléctionner une ligne");
            }

        }

        private void supprimer_btn_Click(object sender, RoutedEventArgs e)
        {
            IInscription iins = new InscriptionImpl();
            inscription ins = new inscription();

            ins = iins.FindInscriptionByMat(iso_txt.Text);
            int o = iins.ModifDelete(ins);
            if (o != 0)
                MessageBox.Show("Données Supprimées");
            else
                MessageBox.Show("Non Supprimées");
            charge();
        }

        private void rech_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListRechercheInvalide(rech_invalide_txt.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error is " + ex.ToString());
            }
        }

        private void recherche_en_cours_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListRechercheInscrit(recherche_txt.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error is " + ex.ToString());
            }

        }

        private void rech_invalide_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListRechercheInvalide(rech_invalide_txt.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error is " + ex.ToString());
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
                var res = from ins in db.inscription
                          join cl in db.client
                          on ins.client_id equals cl.id
                          where (ins.date_inscription >= datedebutp_dtp.SelectedDate && ins.date_inscription <= datefinp_dtp.SelectedDate && ins.delet == 0)
                          select new Organisation
                          {
                              Matricule = ins.matricule,
                              Nom = cl.nom_client,
                              Prenom = cl.prenom_client,
                              Tel = cl.tel_client,
                              Date_Inscription = (DateTime)ins.date_inscription,
                              Date_Echeance = (DateTime)ins.date_echeance,
                              Montant = ins.montant_ins.ToString(),
                              Statut = "existant",
                          };
                datarecherchedate.ItemsSource = res.ToList();
                int o = res.Count();
                nbreinsc_txt.Text = o.ToString();
                montantTotal_txt.Text = (o * 1500).ToString();
            }
        }

        private void ModifStatutList()
        {
            IInscription iins = new InscriptionImpl();
            List<inscription> li = db.inscription.ToList();
            foreach (inscription ins in li)
            {   if(ins.date_echeance<DateTime.Now)
                     iins.ModifStatut(ins);
            }
        }

        /*private void Bloquer_Click(object sender, RoutedEventArgs e)
        {
            IInscription ii = new InscriptionImpl();
            inscription ins = new inscription();

            if (!iso_txt.Text.Equals(""))
            {
                ins = ii.FindInscriptionByMat(iso_txt.Text);
                if (ins.statut != 0)
                {
                    var quer = db.inscription.Where(g => g.id == ins.id).FirstOrDefault();
                    quer.statut = 0;
                    int o = db.SaveChanges();
                    if (o != 0)
                    {
                        charge();
                        MessageBox.Show("Données Modifiées");
                    }
                    else
                        MessageBox.Show("Non Modifiées");
                }
                else
                    MessageBox.Show("ce client est déja bloqué");
                
            }
            else
            {
                MessageBox.Show("Veuillez Séléctionner une ligne");
            }
        }*/



        private void sortdata(object sender, MouseEventArgs e)
        {
            dataInscriptionencours.SelectedValue = null;
            dataInscriptionencours.SelectedValue = null;
            dataInvalide.SelectedValue = null;
        }

        private void dataInscription_supprime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
