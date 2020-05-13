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
    public partial class Nouveau_Livre : Window
    {
        private bibliothequeEntities db = new bibliothequeEntities();

        ILivre il = new LivreImpl();
        IAuteur iau = new AuteurImpl();


        public Nouveau_Livre()
        {
            InitializeComponent();
            LoadCombo();
        }

        private void LoadCombo()
        {
            foreach (categorie cat in db.categorie.ToList())
            {
                combo_categorie.Items.Add(cat);
            }
            foreach (niveau_etude ne in db.niveau_etude.ToList())
            {
                combo_niveau_etude.Items.Add(ne);
            }
            
        }


        

       

        private void Reset()
        {
            titre_txt.Text = "";
            prenom_auteur_txt.Text = "";
            nom_auteur_txt.Text = "";
            nationalite_auteur_txt.Text = "";
            maison_edition_txt.Text = "";
            combo_categorie.SelectedValue = null;
            combo_niveau_etude.SelectedValue = null;
            quantite_txt.Text = "";

        }

        private void Valider_click(object sender, RoutedEventArgs e)
        {
            if (titre_txt.Equals("") || prenom_auteur_txt.Equals("") || nom_auteur_txt.Equals("") || nationalite_auteur_txt.Equals("") || maison_edition_txt.Equals("") || quantite_txt.Equals(""))
            {
                MessageBox.Show("Veuillez remplir tous les champs !!!");
            }
            else
            {
                try
                {
                    livre l = new livre();
                    auteur au = new auteur();
                    categorie c = new categorie();
                    niveau_etude n = new niveau_etude();

                    c = combo_categorie.SelectedValue as categorie;
                    n = combo_niveau_etude.SelectedValue as niveau_etude;

                    l.libelle_livre = titre_txt.Text;
                    l.maison_edition = maison_edition_txt.Text;
                    l.qte_stock = int.Parse(quantite_txt.Text);
                    l.deletee = 0;

                    au.prenom_auteur = prenom_auteur_txt.Text;
                    au.nom_auteur = nom_auteur_txt.Text;
                    au.nationalite_auteur = nationalite_auteur_txt.Text;
                    iau.AddAuteur(au);

                    l.auteur_id = au.id;
                    l.categorie_id = c.id;
                    l.niveau_etude_id = n.id;
                    l.qte_pret = 0;

                    il.AddLivre(l);

                    MessageBox.Show("LIVRE AJOUTE !!!");
                    this.Hide();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex+"ERREUR !!!");
                }
            }
        }

        private void Annuler_click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

    }
}
