
using LibAppSportShop;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace _03_SportShopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SportShopDb db;

       
        public MainWindow()
        {
            InitializeComponent();
            db = new SportShopDb(@"Server=(localdb)\MSSQLLocalDB; DataBase=SportShop;");
        }

        private void GetProducts(object sender, RoutedEventArgs e)
        {
          
            try
            {
                dataGrid.ItemsSource = db.GetAll();
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void getSelect(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(text.Text);
            List<Product> list = new List<Product>();
            list.Add(db.GetOneProduct(id));
            dataGrid.ItemsSource = list;
            text.Text = "";
            //MessageBox.Show(text.Text);
        }

        private void text_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                getSelect(sender, e);
            }
        }
    }
}
