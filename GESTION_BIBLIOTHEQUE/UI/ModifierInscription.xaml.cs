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
    public partial class ModifierInscription : Window
    {
        private bibliothequeEntities db = new bibliothequeEntities();
        public ModifierInscription(string mat)
        {
            InitializeComponent();
            dateinsc_dtp.Text = DateTime.UtcNow.ToShortDateString();
            dateech_dtp.Text = DateTime.UtcNow.AddYears(1).ToShortDateString();
            montant_txt.Text = "1500";
            charge(mat);
        }
        

        private void charge(string mat)
        {
            IInscription iins = new InscriptionImpl();
            IClient icl = new ClientImpl();
            client cl = new client();
            inscription ins = new inscription();

            ins = iins.FindInscriptionByMat(mat);
            id_txt.Text = ins.id.ToString();
            //ins = iins.FindInscriptionById(int.Parse(id_txt.Text));

            idc_txt.Text = ins.client_id.ToString();
            cl = icl.FindClientById(int.Parse(idc_txt.Text));

            mat_txt.Text = ins.matricule;
            nom_txt.Text = cl.nom_client;
            prenom_txt.Text = cl.prenom_client;
            adresse_txt.Text = cl.adresse_client;
            tel_txt.Text = cl.tel_client;
            email_txt.Text = cl.email_client;
            datenaiss_dtp.Text = cl.date_naissance.ToString();
            dateinsc_dtp.Text = ins.date_inscription.ToString();
            dateech_dtp.Text = ins.date_echeance.ToString();
            montant_txt.Text = ins.montant_ins.ToString();

        }

        private void Annuler_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Valider_click(object sender, RoutedEventArgs e)
        {
            IInscription iins = new InscriptionImpl();
            inscription ins = new inscription();
            IClient icl = new ClientImpl();
            client cl = new client();
            if (nom_txt.Text.Equals(""))
            {
                MessageBox.Show("Veuillez remplir tous les champs");
            }
            else
            { int mt;
                if (!int.TryParse(montant_txt.Text, out mt))
                {
                    MessageBox.Show("Le montant doit etre de type entier");
                }
                else
                {
                    try
                    {
                        //var quer = db.inscription.Where(g => g.id == int.Parse(id_txt.Text)).FirstOrDefault();
                        ins = iins.FindInscriptionById(int.Parse(id_txt.Text));
                        cl = icl.FindClientById(int.Parse(idc_txt.Text));
                        var quer = db.inscription.Where(g => g.id == ins.id).FirstOrDefault();
                        var query = db.client.Where(c => c.id == cl.id).FirstOrDefault();

                        query.id = int.Parse(idc_txt.Text);
                        query.nom_client = nom_txt.Text;
                        query.prenom_client = prenom_txt.Text;
                        query.adresse_client = adresse_txt.Text;
                        query.tel_client = tel_txt.Text;
                        query.email_client = email_txt.Text;
                        query.date_naissance = DateTime.Parse(datenaiss_dtp.SelectedDate.ToString());

                        quer.matricule = mat_txt.Text;
                        quer.montant_ins = int.Parse(montant_txt.Text);
                        quer.date_echeance = DateTime.Parse(dateech_dtp.SelectedDate.ToString());
                        quer.date_inscription = DateTime.Parse(dateinsc_dtp.SelectedDate.ToString());
                        quer.statut = 1;
                        quer.delet = 0;
                        quer.client_id = int.Parse(idc_txt.Text);
                        int o = db.SaveChanges();
                        
                            MessageBox.Show("Données Modifiées");
                            this.Hide();
                        
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
