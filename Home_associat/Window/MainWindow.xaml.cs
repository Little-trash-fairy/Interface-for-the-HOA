using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using static Home_assoc.DataBase;

namespace Home_associat
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (var connection = DataBaseConnect.Connect())
            {
                try
                {
                    connection.Open();
                    var command = new SqlCommand(
                        DataBaseConstants.SelectTableAndColumnName,
                        connection);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        DataBaseConstants.hint = new System.Collections.ObjectModel.ObservableCollection<CoupleTwoValues>();
                        while (reader.Read())
                        {
                            string buf_coll_name = (string)reader.GetValue(1);

                            if (buf_coll_name != "is_zip")
                            {

                                DataBaseConstants.hint.
                                    Add(new CoupleTwoValues { First = (string)reader.GetValue(0), Second = buf_coll_name });
                            }
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
            SelectGrid.IsReadOnly = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new SelectQueryFill();

            if (window.ShowDialog() == true)
            {
                SelectGrid.ItemsSource = window.Result.AsDataView();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new SQLQueryAddFill().ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new SQLQueryUpdFIll().ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            new SQLFillDeleteQuery().ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            new Window.AdvancedSqlQueryMode().ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            new Window.FindElemInTable().ShowDialog();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

            SelectGrid.ItemsSource = DataBaseOperation.
                            DataBaseOperationSelect.
                                 SelectVall("Person", new List<string>(),
                                 new Dictionary<string, string> { { "debt", " < 0" } }).AsDataView();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            using (DataBase.model.Homeowners_AssociationEntities db =
                                        new DataBase.model.Homeowners_AssociationEntities())
            {
                decimal Sum = db.List_of_services.Where(elem => elem.is_zip == false).Sum(elem => elem.price);
                MessageBox.Show($"The estimated revenue at the moment is {Sum}", "Estimated revenue");
            }
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            new Window.Search_by_apartment_owners_view().ShowDialog();
        }
    }
}
