using System.Data.SqlClient;

namespace Home_assoc
{
    static partial class DataBase
    {
        static internal partial class DataBaseOperation
        {
            static internal class DataBaseOperationInsert
            {
                static internal void InsertInTable(string tableName,
                                                   System.Collections.Generic.Dictionary<string, string> InsertCoup)
                {
                    var (Coll, vall) = DataBaseHelper.InsertFormateHelper(InsertCoup);

                    using (SqlConnection connection = DataBaseConnect.Connect())
                    {
                        try
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand(
                                string.Format(DataBaseConstants.InsertQuery, tableName, Coll, vall),
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
