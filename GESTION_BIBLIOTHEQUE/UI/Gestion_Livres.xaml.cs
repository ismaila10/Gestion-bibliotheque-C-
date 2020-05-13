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
    /// Logique d'interaction pour Gestion_Livres.xaml
    /// </summary>
    public partial class Gestion_Livres : UserControl
    {
        private bibliothequeEntities db = new bibliothequeEntities();

        ILivre il = new LivreImpl();
        IAuteur iau = new AuteurImpl();
        ICategorie ic = new CategorieImp();
        INiveauEtude iniv = new NiveauEtudeImpl();

        public Gestion_Livres()
        {
            InitializeComponent();
            LoadCombo();
            loadData();
            
        }

        private void LoadCombo()
        {

            foreach (livre li in db.livre.ToList())
            {
                combo_titre.Items.Add(li);
            }
        }



        private void Valider_click(object sender, RoutedEventArgs e)
        {
            if (quantite_txt.Text.Equals("") || combo_titre.SelectedValue == null)
            {
                MessageBox.Show("Veuillez remplir tous les champs !!!");
            }
            else
            { int mt;
                if (!int.TryParse(quantite_txt.Text, out mt))
                {
                    MessageBox.Show("La quantité doit etre de type entier");
                }
                else
                {
                    try
                    {
                        livre l = new livre();
                        auteur au = new auteur();
                        categorie c = new categorie();
                        niveau_etude n = new niveau_etude();

                        l = combo_titre.SelectedValue as livre;

                        int qte = int.Parse(quantite_txt.Text);
                        IHistorique IH = new HistoriqueImpl();
                        var ni = 0;
                        if (IH.ListHistorique().Count != 0)
                        {
                            ni = IH.ListHistorique().LastOrDefault().id;
                        }

                        if (il.ModifQte(l, qte) != 0)
                        {
                            MessageBox.Show("LIVRE AJOUTE !!!");
                            Vider();
                            loadData();
                            Menu me = new Menu(ni);
                            me.Show();
                        }
                        else
                             MessageBox.Show("Ajout pas effectué");

                   
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex+"ERREUR !!!");
                    }
                }

            }

        }
        private void Annuler_click(object sender, RoutedEventArgs e)
        {
            Vider();
        }
        private void Vider()
        {
                combo_titre.SelectedValue = null;
                prenom_auteur_txt.Text = "";
                nom_auteur_txt.Text = "";
                nationalite_auteur_txt.Text = "";
                maison_edition_txt.Text = "";
                categorie_txt.Text = "";
                niveau_txt.Text = "";
                qteStock_txt.Text = "";
                quantite_txt.Text = "";
            }

        private void combo_titre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            livre l = new livre();
            l = combo_titre.SelectedValue as livre;
          
            prenom_auteur_txt.Text = l.auteur.prenom_auteur;
            nom_auteur_txt.Text = l.auteur.nom_auteur;
            nationalite_auteur_txt.Text = l.auteur.nationalite_auteur;
            maison_edition_txt.Text = l.maison_edition;
            
            categorie_txt.Text = l.categorie.libelle_categorie;
            niveau_txt.Text = l.niveau_etude.libelle_niveau_etude;
            qteStock_txt.Text = l.qte_stock.ToString();
        }

        private void loadData()
        {
            var q = from l in db.livre
                    from a in db.auteur
                    from c in db.categorie
                    from ni in db.niveau_etude
                    where l.deletee == 0
                    && l.auteur_id == a.id
                    && l.categorie_id == c.id
                    && l.niveau_etude_id == ni.id
                    select new Organisation_Livre
                    {   IdLivre=l.id.ToString(),
                        Titre_Livre = l.libelle_livre,
                        Auteur = a.prenom_auteur +" "+a.nom_auteur,
                        
                        //Maison_Edition = l.maison_edition,
                        Categorie = c.libelle_categorie,
                        Niveau_Etude = ni.libelle_niveau_etude,
                        Nombre_Livres = (int)l.qte_stock

                    };


            dataLivres.ItemsSource = q.ToList();
            nombre_txt.Text = "   " + q.Count().ToString();

        }
        // Auteur = a.prenom_auteur +" "+a.nom_auteur+ " "  + "("+a.nationalite_auteur+")" ,
        private void Nouveau_Click(object sender, RoutedEventArgs e)
        {

            Nouveau_Livre nl = new Nouveau_Livre();
            nl.ShowDialog();
            loadData();
        }

        private void modifier_btn_Click(object sender, RoutedEventArgs e)
        {
            if (selectLine_txt.Text.Equals(""))
            {
                MessageBox.Show("Veuillez sélectionner une ligne pour modifier !");
            }
            else
            {
                Modifier_Livre ml = new Modifier_Livre(int.Parse(selectLine_txt.Text));
                ml.ShowDialog();
                loadData();
            }
        }

        private void dataLivres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Organisation_Livre orgL = dataLivres.SelectedValue as Organisation_Livre;
            if (orgL != null)
                selectLine_txt.Text = orgL.IdLivre;

        }
        private void ListRecherche(string titre)
        {
            var q = from l in db.livre
                    from a in db.auteur
                    from c in db.categorie
                    from ni in db.niveau_etude
                    where l.auteur_id == a.id
                    && l.categorie_id == c.id
                    && l.niveau_etude_id == ni.id
                    && l.libelle_livre.Contains(titre)

                    select new Organisation_Livre
                    {
                        IdLivre = l.id.ToString(),
                        Titre_Livre = l.libelle_livre,
                        Auteur = a.prenom_auteur + " " + a.nom_auteur,

                        //Maison_Edition = l.maison_edition,
                        Categorie = c.libelle_categorie,
                        Niveau_Etude = ni.libelle_niveau_etude,
                        Nombre_Livres = (int)l.qte_stock

                    };
            
            dataLivres.ItemsSource = q.ToList();
            nombre_txt.Text = "   " + q.Count().ToString();
        }
        private void recherche_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListRecherche(recherche_txt.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error is " + ex.ToString());
            }
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {

            livre l = new livre();
            if (selectLine_txt.Text.Equals(""))
            {
                MessageBox.Show("Veuillez sélectionner une ligne pour modifier !");
            }
            else
            {
                l = il.FindLivreById(int.Parse(selectLine_txt.Text));
                int r = il.StautDelete(l);
                if (r != 0)
                    MessageBox.Show("Livre Supprimé !!!");
                else
                    MessageBox.Show("Non Supprimé !!!");
                loadData();
            }

        }
    }
}
