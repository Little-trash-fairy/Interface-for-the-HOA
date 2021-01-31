

using System.Data.SqlClient;

namespace Home_assoc
{
    static partial class DataBase
    {
        static internal partial class DataBaseOperation
        {
            static internal class DataBaseOperationUpdate
            {
                static internal void UpdateInTable(string tableName,
                    System.Collections.Generic.Dictionary<string, string> Value,
                    System.Collections.Generic.Dictionary<string, string> where)
                {
                    string Values = DataBaseHelper.UpdateFormateHelper(Value);
                    string StringWhere = DataBaseHelper.WhereFormateHelper(where);

                    using (SqlConnection connection = DataBaseConnect.Connect())
                    {
                        try
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand(
                                string.Format(DataBaseConstants.UpdQuery, tableName, Values, StringWhere),
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
