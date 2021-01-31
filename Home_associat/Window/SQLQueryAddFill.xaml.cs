using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Home_associat
{
    /// <summary>
    /// Логика взаимодействия для SQLQueryAddFill.xaml
    /// </summary>
    public partial class SQLQueryAddFill : System.Windows.Window
    {
        ObservableCollection<CoupleTwoValues> Vall = null;
        public SQLQueryAddFill()
        {
            InitializeComponent();

            Vall = new ObservableCollection<CoupleTwoValues>();

            Hint.ItemsSource = Home_assoc.DataBase.DataBaseConstants.hint;

            Value.ItemsSource = Vall;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Home_assoc.DataBase.DataBaseConstants.hint.Any(elem => elem.First == tableName))
            {
                bool condition_error = false;
                Dictionary<string, string> valElem = new Dictionary<string, string>();

                foreach (CoupleTwoValues item in Vall)
                {
                    if (item.First != null && item.First != "")
                    {
                        if (Home_assoc.DataBase.DataBaseConstants.hint.Any(elem => elem.Second == item.First && elem.First == tableName))
                        {
                            if (!valElem.ContainsKey(item.First))
                            {
                                if (item.Second == null || item.Second == "")
                                {
                                    item.Second = " = NULL";
                                }
                                valElem.Add(item.First, item.Second);
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
                        Home_assoc.DataBase.DataBaseOperation.DataBaseOperationInsert.
                        InsertInTable(tableName, valElem);
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
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Vall.Add(new CoupleTwoValues());
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
