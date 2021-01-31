using System.Data;
using System.Windows;

namespace Home_associat.Window
{
    /// <summary>
    /// Логика взаимодействия для AdvancedSqlQueryMode.xaml
    /// </summary>
    public partial class AdvancedSqlQueryMode : System.Windows.Window
    {
        public AdvancedSqlQueryMode()
        {
            InitializeComponent();

            Hint.ItemsSource = Home_assoc.DataBase.DataBaseConstants.hint;
        }

        private void MenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void MenuItem_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                ResultQuery.ItemsSource = Home_assoc.DataBase.
                    DataBaseOperation.DataBaseOperationAdvancedQuery.
                               RunAdvancedQuery(Query.Text).AsDataView();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
