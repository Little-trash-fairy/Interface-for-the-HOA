using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Home_associat
{
    /// <summary>
    /// Логика взаимодействия для SQLFillDeleteQuery.xaml
    /// </summary>
    public partial class SQLFillDeleteQuery : System.Windows.Window
    {
        ObservableCollection<CoupleTwoValues> Cond = null;
        public SQLFillDeleteQuery()
        {
            Cond = new ObservableCollection<CoupleTwoValues>();
            InitializeComponent();

            Hint.ItemsSource = Home_assoc.DataBase.DataBaseConstants.hint;
            Condition.ItemsSource = Cond;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Cond.Add(new CoupleTwoValues());
        }
        public string tableName
        {
            get { return TName.Text; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Home_assoc.DataBase.DataBaseConstants.hint.Any(elem => elem.First == tableName))
            {
                bool condition_error = false;
                Dictionary<string, string> cond = new Dictionary<string, string>();

                foreach (CoupleTwoValues item in Cond)
                {
                    if (item.First != null && item.First != "")
                    {
                        if (Home_assoc.DataBase.DataBaseConstants.hint.Any(elem => elem.Second == item.First && elem.First == tableName))
                        {
                            if (!cond.ContainsKey(item.First))
                            {
                                if (item.Second == null || item.Second == "")
                                {
                                    item.Second = " = NULL";
                                }
                                cond.Add(item.First, item.Second);
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
                    try
                    {
                        Home_assoc.DataBase.DataBaseOperation.DataBaseOperationDelete.
                            DeleteInTable(tableName, cond);

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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
