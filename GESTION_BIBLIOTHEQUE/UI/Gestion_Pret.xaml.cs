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
    /// Logique d'interaction pour Gestion_Pret.xaml
    /// </summary>
    public partial class Gestion_Pret : UserControl
    {
        private bibliothequeEntities db = new bibliothequeEntities();
        public Gestion_Pret()
        {
            InitializeComponent();
            datedebut_dtp.Text = DateTime.UtcNow.ToShortDateString();
            LoadCombo();
            charge();
        }

        private void LoadCombo()
        {
            foreach (livre liv in db.livre.ToList())
            {
                titre_cbx.Items.Add(liv);
            }
        }

        private void charge()
        {  //chargement pret 
            var req = from p in db.pret
                        join liv in db.livre
                        on p.livre_id equals liv.id
                        join inss in db.inscription
                        on p.inscription_id equals inss.id
                        join cli in db.client
                        on inss.client_id equals cli.id
                        join au in db.auteur
                        on liv.auteur_id equals au.id
                        select new OrganisationPret
                        {
                            Numero = p.id.ToString(),
                            Matricule = inss.matricule,
                            Nom = cli.nom_client,
                            Prenom = cli.prenom_client,
                            Niveau_etude = liv.niveau_etude.libelle_niveau_etude,
                            Titre = liv.libelle_livre,
                            Auteur = au.prenom_auteur + " " + au.nom_auteur,
                            Date_Debut = (DateTime)p.date_debut,
                            Date_Fin = (DateTime)p.date_fin,

                        };
            dataPrets.ItemsSource = req.ToList();
            nombre_txt.Text = "   " + req.Count().ToString();
            //chargement pret en cours
            var resul = from p in db.pret
                        join liv in db.livre
                        on p.livre_id equals liv.id
                        join inss in db.inscription
                        on p.inscription_id equals inss.id
                        join cli in db.client
                        on inss.client_id equals cli.id
                        join au in db.auteur
                        on liv.auteur_id equals au.id
                        where p.statut_pret == 1 && p.date_fin > DateTime.Today 
                        select new OrganisationPret
                        {
                            Numero = p.id.ToString(),
                            Matricule = inss.matricule,
                            Nom = cli.nom_client,
                            Prenom = cli.prenom_client,
                            Niveau_etude = liv.niveau_etude.libelle_niveau_etude,
                            Titre = liv.libelle_livre,
                            Auteur = au.prenom_auteur + " " + au.nom_auteur,
                            Date_Debut = (DateTime)p.date_debut,
                            Date_Fin = (DateTime)p.date_fin,

                        };
            dataPretCours.ItemsSource = resul.ToList();
            nombre_encours_txt.Text = "   " + resul.Count().ToString();
            //chargement pret non rendu
            var resu = from p in db.pret
                       join liv in db.livre
                       on p.livre_id equals liv.id
                       join inss in db.inscription
                       on p.inscription_id equals inss.id
                       join cli in db.client
                       on inss.client_id equals cli.id
                       join au in db.auteur
                       on liv.auteur_id equals au.id
                       where p.statut_pret == 1 && p.date_fin < DateTime.Today
                       select new OrganisationPret
                       {
                           Numero = p.id.ToString(),
                           Matricule = inss.matricule,
                           Nom = cli.nom_client,
                           Prenom = cli.prenom_client,
                           Niveau_etude = liv.niveau_etude.libelle_niveau_etude,
                           Titre = liv.libelle_livre,
                           Auteur = au.prenom_auteur + " " + au.nom_auteur,
                           Date_Debut = (DateTime)p.date_debut,
                           Date_Fin = (DateTime)p.date_fin,

                       };
            dataPretnonrendu.ItemsSource = resu.ToList();
            nombre_nonrendu_txt.Text = "   " + resu.Count().ToString();
            //chargement pret rendu
            var res= from p in db.pret
                        join liv in db.livre
                        on p.livre_id equals liv.id
                        join inss in db.inscription
                        on p.inscription_id equals inss.id
                        join cli in db.client
                        on inss.client_id equals cli.id
                        join au in db.auteur
                        on liv.auteur_id equals au.id
                        where p.statut_pret == 0
                        select new OrganisationPret
                        {
                            Numero = p.id.ToString(),
                            Matricule = inss.matricule,
                            Nom = cli.nom_client,
                            Prenom = cli.prenom_client,
                            Niveau_etude = liv.niveau_etude.libelle_niveau_etude,
                            Titre = liv.libelle_livre,
                            Auteur = au.prenom_auteur + " " + au.nom_auteur,
                            Date_Debut = (DateTime)p.date_debut,
                            Date_Fin = (DateTime)p.date_fin,

                        };
            dataPretRendu.ItemsSource = res.ToList();
            nombre_rendu_txt.Text = "   " + res.Count().ToString();
        }

        private void reset()
        {
            mat_txt.Text = "";
            nom_txt.Text = "";
            prenom_txt.Text = "";
            datedebut_dtp.Text = DateTime.UtcNow.ToShortDateString();
            datefin_dtp.Text = "";
            adresse_txt.Text = "";
            tel_txt.Text = "";
            titre_cbx.SelectedValue = null;
            maison_txt.Text = "";
            qte_txt.Text = "";

        }

       
        //Action valider dans ajout pret
        private void Valider_click(object sender, RoutedEventArgs e)
        {
            if (mat_txt.Text.Equals("")||titre_cbx.SelectedValue == null|| datedebut_dtp.Text.Equals("") || datefin_dtp.Text.Equals(""))
            {
                MessageBox.Show("Veuillez remplir tous les champs obligatoires");
            }
            else
            {
                try
                {
                    IInscription iins = new InscriptionImpl();
                    inscription ins = new inscription();

                    ins = iins.FindInscriptionByMat(mat_txt.Text);
                    livre liv = new livre();

                    liv = titre_cbx.SelectedValue as livre;
                    IPret ip = new PretImpl();
                    pret p = new pret();

                    var m = 0;
                    if (ip.ListPret().Count == 0)
                    {
                        m = 0;
                    }
                    else
                    {
                        m = ip.ListPret().LastOrDefault().id;
                    }

                    p.id = m + 1;
                    if (datedebut_dtp.SelectedDate > datefin_dtp.SelectedDate)
                    {
                        MessageBox.Show("Date début ne peut venir aprés date fin");
                        datefin_dtp.Text = "";
                    }
                    else
                    {
                        p.date_debut = DateTime.Parse(datedebut_dtp.ToString());
                        p.date_fin = DateTime.Parse(datefin_dtp.ToString());
                        p.nbre_liv_emprunte = 1;
                        p.statut_pret = 1;
                        p.livre_id = liv.id;
                        p.inscription_id = ins.id;
                        if (int.Parse(qte_txt.Text) != 0)
                        {
                            IHistorique IH = new HistoriqueImpl();
                            var n = 0;
                            if (IH.ListHistorique().Count != 0)
                            {
                                n = IH.ListHistorique().LastOrDefault().id;
                            }
                            int o = ip.AddPret(p);
                            if (o != 0)
                            {
                                ILivre iliv = new LivreImpl();
                                iliv.AjoutPret(liv, 1);
                                MessageBox.Show("Pret Ajouté");
                                reset();
                                charge();
                                Menu me = new Menu(n);
                                me.Show();
                            }
                            else
                                MessageBox.Show("Données non enregistrées");
                            charge();
                        }
                        else
                        {
                            MessageBox.Show("Livre Indisponible ");
                        }
                    }
                    
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex + "Erreur");
                }
            }

        }

       
        private void Annuler_click(object sender, RoutedEventArgs e)
        {
            reset();
        }
        
        //Action combo titre livre dans ajout pret
        private void titre_cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            livre liv = new livre();
            ILivre iliv = new LivreImpl();
            IAuteur ia = new AuteurImpl();
            auteur a = new auteur();

            liv = titre_cbx.SelectedValue as livre;
            if (liv != null)
            {
                /*int o = (int)liv.auteur_id;
                a = ia.FindAuteurById(o);
                auteur_txt.Text = a.nom_auteur;*/
                maison_txt.Text = liv.maison_edition;
                int r = (int)(liv.qte_stock - liv.qte_pret);
                qte_txt.Text = r.ToString();
            }
            else
            {
                //LoadCombo();
                maison_txt.Text = "";
            }
        }
        //Action matricule client dans ajout pret
        private void matMouseLeave(object sender, MouseEventArgs e)
        {
            IInscription iins = new InscriptionImpl();
            inscription ins = new inscription();
            IClient icl = new ClientImpl();
            client cl = new client();
            if (!mat_txt.Text.Equals(""))
            {
                ins = iins.FindInscriptionByMat(mat_txt.Text);
                if (ins != null && ins.delet != 1)
                {
                    int o = (int)ins.client_id;
                    cl = icl.FindClientById(o);
                    nom_txt.Text = cl.nom_client;
                    prenom_txt.Text = cl.prenom_client;
                    adresse_txt.Text = cl.adresse_client;
                    tel_txt.Text = cl.tel_client;
                }
                else
                {
                     MessageBox.Show("Matricule Inexistante");
                }
            }

        }

        //Chargement datagrid pret en cours apres recherche
        private void ListRecherchePret(String matricule)
        {
            var res = from p in db.pret
                      join liv in db.livre
                      on p.livre_id equals liv.id
                      join inss in db.inscription
                      on p.inscription_id equals inss.id
                      join cli in db.client
                      on inss.client_id equals cli.id
                      join au in db.auteur
                      on liv.auteur_id equals au.id
                      where inss.matricule.Contains(matricule)
                      select new OrganisationPret
                      {
                          Numero = p.id.ToString(),
                          Matricule = inss.matricule,
                          Nom = cli.nom_client,
                          Prenom = cli.prenom_client,
                          Niveau_etude = liv.niveau_etude.libelle_niveau_etude,
                          Titre = liv.libelle_livre,
                          Auteur = au.prenom_auteur + " " + au.nom_auteur,
                          Date_Debut = (DateTime)p.date_debut,
                          Date_Fin = (DateTime)p.date_fin,

                      };

            dataPrets.ItemsSource = res.ToList();
            nombre_txt.Text = "   " + res.Count().ToString();
        }



        //Action rechercher pret en cours
        private void reche_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
               ListRecherchePret((reche_txt.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error is " + ex.ToString());
            }
        }

        //Chargement datagrid pret en cours apres recherche
        private void ListRecherchePretencours(String matricule)
        {
            var res = from p in db.pret
                      join liv in db.livre
                      on p.livre_id equals liv.id
                      join inss in db.inscription
                      on p.inscription_id equals inss.id
                      join cli in db.client
                      on inss.client_id equals cli.id
                      join au in db.auteur
                      on liv.auteur_id equals au.id
                      where p.statut_pret == 1 && p.date_fin > DateTime.Today && (inss.matricule.Contains(matricule))
                      select new OrganisationPret
                        {
                            Numero = p.id.ToString(),
                            Matricule = inss.matricule,
                            Nom = cli.nom_client,
                            Prenom = cli.prenom_client,
                          Niveau_etude = liv.niveau_etude.libelle_niveau_etude,
                          Titre = liv.libelle_livre,
                            Auteur = au.prenom_auteur + " " + au.nom_auteur,
                            Date_Debut = (DateTime)p.date_debut,
                            Date_Fin = (DateTime)p.date_fin,

                        };
            
            dataPretCours.ItemsSource = res.ToList();
            nombre_encours_txt.Text = "   " + res.Count().ToString();
        }



        //Action rechercher pret en cours
        private void reche_encours_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListRecherchePretencours((reche_encours_txt.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error is " + ex.ToString());
            }
        }
        //Chargement datagrid pret non rendu apres recherche
        private void ListRecherchePretNonRendu(String matricule)
        {
            var resu = from p in db.pret
                       join liv in db.livre
                       on p.livre_id equals liv.id
                       join inss in db.inscription
                       on p.inscription_id equals inss.id
                       join cli in db.client
                       on inss.client_id equals cli.id
                       join au in db.auteur
                       on liv.auteur_id equals au.id
                       where p.statut_pret == 1 && p.date_fin < DateTime.Today && (inss.matricule.Contains(matricule))
                       select new OrganisationPret
                       {
                           Numero = p.id.ToString(),
                           Matricule = inss.matricule,
                           Nom = cli.nom_client,
                           Prenom = cli.prenom_client,
                           Niveau_etude = liv.niveau_etude.libelle_niveau_etude,
                           Titre = liv.libelle_livre,
                           Auteur = au.prenom_auteur + " " + au.nom_auteur,
                           Date_Debut = (DateTime)p.date_debut,
                           Date_Fin = (DateTime)p.date_fin,
                       };
            dataPretnonrendu.ItemsSource = resu.ToList();
            nombre_nonrendu_txt.Text = "   " + resu.Count().ToString();
        }
        //Action rechercher pret non rendu
        private void recherche_nonrendu_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListRecherchePretNonRendu((recherche_nonrendu_txt.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error is " + ex.ToString());
            }
        }
        //Chargement datagrid pret non rendu apres recherche
        private void ListRecherchePretRendu(String matricule)
        {
            var resu = from p in db.pret
                       join liv in db.livre
                       on p.livre_id equals liv.id
                       join inss in db.inscription
                       on p.inscription_id equals inss.id
                       join cli in db.client
                       on inss.client_id equals cli.id
                       join au in db.auteur
                       on liv.auteur_id equals au.id
                       where p.statut_pret == 0 &&  (inss.matricule.Contains(matricule))
                       select new OrganisationPret
                       {
                           Numero = p.id.ToString(),
                           Matricule = inss.matricule,
                           Nom = cli.nom_client,
                           Prenom = cli.prenom_client,
                           Niveau_etude = liv.niveau_etude.libelle_niveau_etude,
                           Titre = liv.libelle_livre,
                           Auteur = au.prenom_auteur + " " + au.nom_auteur,
                           Date_Debut = (DateTime)p.date_debut,
                           Date_Fin = (DateTime)p.date_fin
                       };
            dataPretRendu.ItemsSource = resu.ToList();
            nombre_rendu_txt.Text = "   " + resu.Count().ToString();
        }
        private void rech_rendu_tx_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListRecherchePretRendu((rech_rendu_txt.Text));

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
                var res = from p in db.pret
                          join liv in db.livre
                          on p.livre_id equals liv.id
                          join inss in db.inscription
                          on p.inscription_id equals inss.id
                          join cli in db.client
                          on inss.client_id equals cli.id
                          join au in db.auteur
                          on liv.auteur_id equals au.id
                          where (p.date_debut >= datedebutp_dtp.SelectedDate && p.date_debut <= datefinp_dtp.SelectedDate)
                          select new OrganisationPret
                          {
                              Numero = p.id.ToString(),
                              Matricule = inss.matricule,
                              Nom = cli.nom_client,
                              Prenom = cli.prenom_client,
                              Niveau_etude = liv.niveau_etude.libelle_niveau_etude,
                              Titre = liv.libelle_livre,
                              Auteur = au.prenom_auteur + " " + au.nom_auteur,
                              Date_Debut = (DateTime)p.date_debut,
                              Date_Fin = (DateTime)p.date_fin,

                          };
                datastatistique.ItemsSource = res.ToList();
                int o = res.Count();
                nbrepret_txt.Text = o.ToString();
            }
        }

        private void Rendre_Click(object sender, RoutedEventArgs e)
        {
            Rendre(idPret_txt.Text);
        }

        private void Rendre(string s)
        {
            IPret ip = new PretImpl();
            pret p = new pret();
            if (!s.Equals(""))
            {

                p = ip.FindPretById(int.Parse(s));

                var query = db.pret.Where(c => c.id == p.id).FirstOrDefault();
                query.date_rendu = DateTime.Now;
                query.statut_pret = 0;

                int o = db.SaveChanges();
                if (o != 0)
                {
                    ILivre iliv = new LivreImpl();
                    livre l = new livre();
                    l = iliv.FindLivreById((int)p.livre_id);
                    iliv.RendrePret(l, 1);
                    MessageBox.Show("Livre Rendu");
                    charge();
                }
                else
                {
                    MessageBox.Show("Erreur");
                }
            }
            else
                MessageBox.Show("vous devez selectionner une ligne.");
        }

        private void dataPretCours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OrganisationPret org = dataPretCours.SelectedValue as OrganisationPret;
            if (org != null)
                idPret_txt.Text = org.Numero;
        }
        


        private void sortdata(object sender, MouseEventArgs e)
        {   
            dataPretRendu.SelectedValue = null;
            datastatistique.SelectedValue = null;
            dataPrets.SelectedValue = null;
        }

        private void dataPretnonrendu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           OrganisationPret org = dataPretnonrendu.SelectedValue as OrganisationPret;
            if (org != null)
                idPretsnonrendu_txt.Text = org.Numero;
        }

        private void Rendre2_Click(object sender, RoutedEventArgs e)
        {
            Rendre(idPretsnonrendu_txt.Text);
        }
        
    }
}
