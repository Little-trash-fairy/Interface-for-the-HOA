using System.Data.SqlClient;

namespace Home_assoc
{
    static partial class DataBase
    {
        static internal partial class DataBaseOperation
        {
            static internal class DataBaseOperationDelete
            {
                static internal void DeleteInTable(string tableName,
                    System.Collections.Generic.Dictionary<string, string> WhereCouple)
                {
                    string WhereCond = DataBaseHelper.WhereFormateHelper(WhereCouple);

                    using (SqlConnection connection = DataBaseConnect.Connect())
                    {
                        try
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand(
                                string.Format(DataBaseConstants.DellQuery, tableName, WhereCond),
                                connection);
                            command.ExecuteNonQuery();
                        }
                        catch (System.Exception e)
                        {
                            connection.Close();
                            throw e;
                        }
                    }
                }
            }
        }
    }
}