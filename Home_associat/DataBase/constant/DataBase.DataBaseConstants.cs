namespace Home_assoc
{
    static partial class DataBase
    {
        internal static class DataBaseConstants
        {
            internal static string connectionString = System.Configuration.
                ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            internal static string UpdQuery = "Update {0} {1} {2}";
            internal static string DellQuery = "Delete {0} {1}";
            internal static string InsertQuery = "Insert into {0} ({1})" +
                                                "values({2})";
            internal static string SelectQuery = "Select {0} from {1} {2}";
            internal static string SelectTableAndColumnName =
                "SELECT TABLE_NAME,COLUMN_NAME " +
                "FROM INFORMATION_SCHEMA.COLUMNS " +
                "where TABLE_CATALOG = 'Homeowners_Association' ORDER BY TABLE_NAME";

            internal static System.Collections.ObjectModel.
                ObservableCollection<Home_associat.CoupleTwoValues> hint;
        }
    }
}
