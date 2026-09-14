using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace _05_DisconnectedMode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // connection class to database
        private SqlConnection conn = null;
        // data adapter for disconnected mode
        private SqlDataAdapter da = null;
        // DataSet
        private DataSet set = null;
        public MainWindow()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB; DataBase=SportShop;");
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // query for select data
                string sql = commandTextBox.Text;
                // create data adapter
                da = new SqlDataAdapter(sql, conn);
                // create command builder for auto generate insert, update and delete queries
                new SqlCommandBuilder(da);

                // create empty DataSet
                set = new DataSet();
                // execute select query on server and put data to DataSet
                da.Fill(set, "MyTable");

                // bind table to DataGrid
                dataGrid.ItemsSource = set.Tables["MyTable"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                // update server data (sync DataSet with database)
                da.Update(set);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
