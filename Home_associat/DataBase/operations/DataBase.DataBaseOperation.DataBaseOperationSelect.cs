using System.Data.SqlClient;

namespace Home_assoc
{
    static partial class DataBase
    {
        static internal partial class DataBaseOperation
        {
            static internal class DataBaseOperationSelect
            {
                static internal System.Data.DataTable SelectVall(string tableName,
                    System.Collections.Generic.List<string> selectedCOll,
                    System.Collections.Generic.Dictionary<string, string> WhereCouple)
                {
                    var (collumn, where) = DataBaseHelper.
                        SelectFormateHelper(selectedCOll, WhereCouple);

                    var dt = new System.Data.DataTable();

                    using (var connection = DataBaseConnect.Connect())
                    {
                        try
                        {
                            connection.Open();
                            var command = new SqlCommand(
                                string.Format(DataBaseConstants.SelectQuery, collumn, tableName, where),
                                connection);
                            SqlDataAdapter da = new SqlDataAdapter(command);
                            da.Fill(dt);
                        }
                        catch (System.Exception e)
                        {
                            connection.Close();
                            throw e;
                        }
                    }
                    return dt;
                }
            }
        }
    }
}
