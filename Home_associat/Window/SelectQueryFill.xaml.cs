using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Home_associat
{
    /// <summary>
    /// Логика взаимодействия для SelectQueryFill.xaml
    /// </summary>
    public partial class SelectQueryFill : System.Windows.Window
    {
        ObservableCollection<SelectCollName> Vall = null;
        ObservableCollection<CoupleTwoValues> Cond = null;
        public SelectQueryFill()
        {
            Vall = new ObservableCollection<SelectCollName>();
            Cond = new ObservableCollection<CoupleTwoValues>();
            InitializeComponent();

            Value.ItemsSource = Vall;
            Condition.ItemsSource = Cond;

            Hint.ItemsSource = Home_assoc.DataBase.DataBaseConstants.hint;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Home_assoc.DataBase.DataBaseConstants.hint.Any(elem => elem.First == tableName))
            {
                var condition_error = false;
                var coll = new List<string>();
                var readCOnd = new Dictionary<string, string>();

                foreach (CoupleTwoValues item in Cond)
                {
                    if (item.First != null && item.First != "")
                    {
                        if (Home_assoc.DataBase.DataBaseConstants.hint.Any(elem => elem.Second == item.First && elem.First == tableName))
                        {
                            if (!readCOnd.ContainsKey(item.First))
                            {
                                if (item.Second == null || item.Second == "")
                                {
                                    item.Second = " = NULL";
                                }
                                readCOnd.Add(item.First, item.Second);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Неверное имя столбца - " + item.First + "или таблицы - " + tableName, "Error");
                            condition_error = true;
                            break;
                        }
                    }
                }

                if (!condition_error)
                {
                    foreach (SelectCollName item in Vall)
                    {
                        if (item.Name != null && item.Name != "")
                        {
                            if (Home_assoc.DataBase.DataBaseConstants.hint.Any(elem => elem.Second == item.Name && elem.First == tableName))
                            {
                                if (!coll.Contains(item.Name))
                                {
                                    coll.Add(item.Name);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Неверное имя столбца - " + item.Name + "или таблицы - " + tableName, "Error");
                                condition_error = true;
                                break;
                            }
                        }
                    }
                }
                if (!condition_error)
                {
                    try
                    {
                        Result = Home_assoc.DataBase.DataBaseOperation.
                            DataBaseOperationSelect.
                                 SelectVall(tableName, coll, readCOnd);

                        DialogResult = true;
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
                }
            }
            else
            {
                MessageBox.Show("Неверное имя таблица", "Error");
            }
        }

        public string tableName
        {
            get { return TName.Text; }
        }
        public System.Data.DataTable Result;

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Cond.Add(new CoupleTwoValues());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Vall.Add(new SelectCollName { Name = string.Empty });
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
