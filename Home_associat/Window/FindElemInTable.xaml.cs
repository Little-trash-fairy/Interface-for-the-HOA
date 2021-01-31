using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Input;

namespace Home_associat.Window
{
    /// <summary>
    /// Логика взаимодействия для FindElemInTable.xaml
    /// </summary>
    public partial class FindElemInTable : System.Windows.Window
    {
        public FindElemInTable()
        {
            InitializeComponent();
            ExtractedTableDataGrid.IsReadOnly = true;
            SelectedTableDataGrid.IsReadOnly = true;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void SelectValue(string tableName)
        {
            ExtractedTableDataGrid.ItemsSource = null;

            List<string> coll = new List<string>();
            foreach (var item in Home_assoc.DataBase.DataBaseConstants.hint)
            {
                if (item.First == tableName)
                {
                    coll.Add(item.Second);
                }
            }
            coll.Reverse();

            string find_coll_name = (SelectMode == 1) ?
                    "id_flat" :
                    (SelectMode == 2) ?
                    "payment_account" :
                    (SelectMode == 3) ?
                    "payment_account" :
                    "id_monthly_bill";

            for (int i = 0; i < coll.Count; i++)
            {
                if (coll[i] == find_coll_name)
                {
                    coll.RemoveAt(i);
                    coll.Insert(0, find_coll_name);
                    break;
                }
            }

            SelectedTableDataGrid.ItemsSource = Home_assoc.DataBase.DataBaseOperation.
                DataBaseOperationSelect.
                     SelectVall(tableName, coll,
                     new Dictionary<string, string>()).AsDataView();
        }
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SelectMode = 1;
            SelectValue("Flat");
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            SelectMode = 2;
            SelectValue("Person");
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            SelectMode = 3;
            SelectValue("Person");
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            SelectMode = 4;
            SelectValue("Monthly_bill");
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = SelectedTableDataGrid.SelectedItem as DataRowView;

            if (row != null)
            {

                string TableName = (SelectMode == 1) ?
                    "Person" :
                    (SelectMode == 2) ?
                    "Flat" :
                    (SelectMode == 3) ?
                    "Flat" :
                    "List_of_services";

                string AdvancedQuery = "Select ";

                List<string> buf_coll = new List<string>();

                foreach (var item in Home_assoc.DataBase.DataBaseConstants.hint)
                {
                    if (item.First == TableName)
                    {
                        buf_coll.Add(item.First + "." + item.Second);
                    }
                }
                buf_coll.Reverse();

                AdvancedQuery += string.Join(", ", buf_coll.ToArray());

                AdvancedQuery += (SelectMode == 1) ?
                    " from Tenant_of_flat inner join Person " +
                    "ON Person.payment_account = Tenant_of_flat.tenant_payment_account where id_flat = " :
                    (SelectMode == 2) ?
                    " from Tenant_of_flat inner join Flat " +
                    "ON Tenant_of_flat.id_flat = Flat.id_flat where Tenant_of_flat.tenant_payment_account = " :
                    (SelectMode == 3) ?
                    " from Flat where tenant_payment_account = " :
                    " from List_of_services where id_monthly_bill = ";
                AdvancedQuery += row.Row.ItemArray[0].ToString();

                ExtractedTableDataGrid.ItemsSource = Home_assoc.DataBase.
                                    DataBaseOperation.DataBaseOperationAdvancedQuery.
                                            RunAdvancedQuery(AdvancedQuery).AsDataView();
            }
        }
        private int SelectMode { set; get; }
    }
}
