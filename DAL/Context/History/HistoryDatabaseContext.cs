using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces_BLL_DAL;
using MDL;

namespace DAL.Contexts
{
    public class HistoryDatabaseContext : IHistoryContext
    {
        Connection database = new Connection();
        private List<History> histories = new List<History>();

        public List<History> GetHistories()
        {
            string query = "SELECT * FROM [History]";
            var model = new List<History>();

            using (SqlConnection connection = new SqlConnection(database.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var history = new History
                                {
                                    Type = reader["Type"].ToString(),
                                    Date = reader["Date"].ToString()
                                };

                                model.Add(history);
                                model.ToList();
                                histories = model;
                            }
                        }

                        connection.Close();
                    }
                    return histories;
                }
                catch (SqlException sqlException)
                {
                    throw sqlException;
                }
                catch (InvalidCastException invalidCastException)
                {
                    throw invalidCastException;
                }
            }
        }
    }
}
