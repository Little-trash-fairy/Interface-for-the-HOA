using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Home_associat.Window
{
    /// <summary>
    /// Логика взаимодействия для Search_by_apartment_owners_view.xaml
    /// </summary>
    public partial class Search_by_apartment_owners_view : System.Windows.Window
    {
        private Dictionary<string, TextBox> DictTextBox;
        public Search_by_apartment_owners_view()
        {
            InitializeComponent();

            using (DataBase.model.Homeowners_AssociationEntities db =
                            new DataBase.model.Homeowners_AssociationEntities())
            {
                SelectedTableDataGrid.ItemsSource = db.Flat_owner.ToList();

                DictTextBox = new Dictionary<string, TextBox>();

                var tname =
                    (from t in typeof(DataBase.model.Flat_owner).GetProperties() select t.Name);

                foreach (var item in tname)
                {
                    var sP = new StackPanel();

                    sP.Orientation = Orientation.Horizontal;

                    var tBlock = new TextBlock();
                    tBlock.Text = item;
                    tBlock.Height = 25;
                    tBlock.Width = 120;
                    sP.Children.Add(tBlock);

                    var tBox = new TextBox();
                    tBox.Name = item;
                    tBox.Margin = new Thickness(5, 5, 0, 5);
                    tBox.Height = 25;
                    tBox.Width = 110;

                    DictTextBox.Add(item, tBox);

                    sP.Children.Add(tBox);

                    CondStack.Children.Add(sP);
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            string query = "Select * from Flat_owner ";

            if (DictTextBox.Any(item => item.Value.Text != ""))
            {
                query += " Where ";
                int count = DictTextBox.Count(item => item.Value.Text != "");
                int i = 0;
                foreach (var item in DictTextBox)
                {
                    if (item.Value.Text != "")
                    {
                        query += item.Key + " = '" + item.Value.Text + "' ";
                        i++;
                        if (i < count)
                        {
                            query += " AND ";
                        }
                        if(i==count)
                        {
                            break;  
                        }
                    }

                }
            }

            using (DataBase.model.Homeowners_AssociationEntities db =
                            new DataBase.model.Homeowners_AssociationEntities())
            {
                SelectedTableDataGrid.ItemsSource =
                    db.Database.SqlQuery<DataBase.model.Flat_owner>(query).ToList();
            }
        }
    }
}
