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
    public partial class Modifier_Livre : Window
    {
        private bibliothequeEntities db = new bibliothequeEntities();

        ILivre il = new LivreImpl();
        IAuteur iau = new AuteurImpl();
        int id;
        int idcombocat, idcomboniv;

        public Modifier_Livre(int i)
        {
            InitializeComponent();
            id = i;
            LoadCombo();
          
            loadData(i);
        }

        private void LoadCombo()
        {
            /* livre l = new livre();
             auteur au cate= new auteur();

             l = il.FindLivreById(i);
             idL_txt.Text = ((int)l.id).ToString();

             idA_txt.Text = l.auteur_id.ToString();
             au = iau.FindAuteurById(int.Parse(idA_txt.Text));*/
            /* foreach (categorie cat in db.categorie.ToList())
             {  //if(cat==)
                 combo_categorie.Items.Add(cat);
             }
             
              foreach (niveau_etude ne in db.niveau_etude.ToList())
            {
                combo_niveau_etude.Items.Add(ne);
            }*/

            livre l = new livre();
            l = il.FindLivreById(id);
         
           
            categorie cat = new categorie();
            for (int i = 0; i < db.categorie.ToList().Count; i++)
            {

                if (db.categorie.ToList()[i].id == l.categorie.id)
                    idcombocat = i;
                combo_categorie.Items.Add(db.categorie.ToList()[i]);
            }
            for (int j = 0; j < db.niveau_etude.ToList().Count; j++)
            {
                if (db.niveau_etude.ToList()[j].id == l.niveau_etude.id)
                    idcomboniv = j;
                combo_niveau_etude.Items.Add(db.niveau_etude.ToList()[j]);
            }
          
            combo_categorie.SelectedIndex = idcombocat;
            combo_niveau_etude.SelectedIndex= idcomboniv;
        }

        private void loadData(int i)
        {
            livre l = new livre();
            auteur au = new auteur();
           
            l = il.FindLivreById(i);
            idL_txt.Text = ((int)l.id).ToString();

            idA_txt.Text = l.auteur_id.ToString();
            au = iau.FindAuteurById(int.Parse(idA_txt.Text));
           
            titre_txt.Text = l.libelle_livre;
            prenom_auteur_txt.Text = au.prenom_auteur;
            nom_auteur_txt.Text = au.nom_auteur;
            nationalite_auteur_txt.Text = au.nationalite_auteur;
            maison_edition_txt.Text = l.maison_edition;
            quantite_txt.Text = l.qte_stock.ToString();
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

                   
                    n = combo_niveau_etude.SelectedValue as niveau_etude;

                    l = il.FindLivreById(int.Parse(idL_txt.Text));
                    au = iau.FindAuteurById(int.Parse(idA_txt.Text));
                    /*int o = (int)l.auteur_id;
                    au = iau.FindAuteurById(o);*/
                    var query = db.livre.Where(q => q.id == l.id).FirstOrDefault();
                    var query2 = db.auteur.Where(r => r.id == au.id).FirstOrDefault();

                    if (combo_categorie.SelectedValue != null)
                    {
                        c = combo_categorie.SelectedValue as categorie;
                        if (combo_niveau_etude.SelectedValue != null)
                        {
                            n = combo_niveau_etude.SelectedValue as niveau_etude;

                            query.libelle_livre = titre_txt.Text;
                            query.maison_edition = maison_edition_txt.Text;
                            query.qte_stock = int.Parse(quantite_txt.Text);
                           
                            query.categorie_id = c.id;
                            query.niveau_etude_id = n.id;
                            query.deletee = 1;
                            query.deletee = 0;

                            query2.prenom_auteur = prenom_auteur_txt.Text;
                            query2.nom_auteur = nom_auteur_txt.Text;
                            query2.nationalite_auteur = nationalite_auteur_txt.Text;
                            

                 
                            int sauv = db.SaveChanges();
                            
                                MessageBox.Show("Données Modifiées !!!");
                                this.Hide();
                            


                        }
                        else
                            MessageBox.Show("Vous devez choisir le niveau d'étude.");
                    }
                    else
                        MessageBox.Show("Vous devez choisir le categorie.");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex+"ERREUR !!!");
                }
            }
        }

        private void Annuler_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void combo_categorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
