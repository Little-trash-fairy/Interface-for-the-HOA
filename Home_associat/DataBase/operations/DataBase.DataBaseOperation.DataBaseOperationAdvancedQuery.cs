

using System.Data.SqlClient;

namespace Home_assoc
{
    static partial class DataBase
    {
        static internal partial class DataBaseOperation
        {
            static internal class DataBaseOperationAdvancedQuery
            {
                static internal System.Data.DataTable RunAdvancedQuery(string Query)
                {
                    var dt = new System.Data.DataTable();

                    using (var connection = DataBaseConnect.Connect())
                    {
                        try
                        {
                            connection.Open();
                            var command = new SqlCommand(
                                Query,
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
