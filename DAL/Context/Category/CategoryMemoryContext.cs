using MDL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces_BLL_DAL;

namespace DAL.Context
{
    public class CategoryMemoryContext : ICategoryContext
    {
        LocalConnection localDatabase = new LocalConnection();
        private List<Category> categories = new List<Category>();

        public List<Category> GetAllCategories()
        {
            string query = "SELECT * FROM [Category]";
            var model = new List<Category>();

            using (SqlConnection connection = new SqlConnection(localDatabase.GetConnectionString()))
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
                                var category = new Category
                                {
                                    CategoryId = Convert.ToInt32(reader["Category_ID"]),
                                    CategoryName = reader["CategoryName"].ToString(),
                                };

                                model.Add(category);
                                model.ToList();
                                categories = model;
                            }
                        }
                        connection.Close();
                    }
                    return categories;
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
