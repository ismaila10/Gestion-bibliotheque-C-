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
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        private bibliothequeEntities db = new bibliothequeEntities();
        int idi;
        public Menu(int id)
        {
            InitializeComponent();

            idi = id;
            IHistorique IH = new HistoriqueImpl();
            historique h=new historique();
            h = IH.FindHistoriqueById(idi);
            IAdmin IA = new AdminsImpl();
            admins ad = new admins();
            int o = (int)h.admin_id;
            ad = IA.FindAdminById(o);

            if (ad.type == 0)
                ListViewMenu.Items.RemoveAt(4);
         

            // idtxt.Text = id.ToString();
        }

        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {   
            Application.Current.Shutdown();

            var query = db.historique.Where(c => c.id == idi).FirstOrDefault();
            
            query.date_fin_cnx= DateTime.Now;
             db.SaveChanges();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            switch (index)
            {
                case 0:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new Accueil());
                    break;
                case 1:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new Gestion_Inscription());
                    break;
                case 2:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new Gestion_Livres());
                    break;
                case 3:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new Gestion_Pret());
                    break;
                case 4:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new Gestion_User());
                    break;
                default:
                    break;
            }
        }

        private void MoveCursorMenu(int index)
        {
            TrainsitionigContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (100 + (60 * index)), 0, 0);
        }

        private void deconnexion_Click(object sender, RoutedEventArgs e)
        {
           
            var query = db.historique.Where(c => c.id == idi).FirstOrDefault();
            query.date_fin_cnx = DateTime.Now;
            db.SaveChanges();


            MainWindow m = new MainWindow();
            m.Show();
            this.Hide();

        }
    }
}
