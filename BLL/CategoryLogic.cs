using Interfaces_BLL_DAL;
using Interfaces_UI_BLL;
using MDL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoryLogic : ICategoryLogic
    {
        ICategoryRepository _repo;

        public CategoryLogic(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public List<Category> GetAllCategories()
        {
            try
            {
                return _repo.GetAllCategories();
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException);
                throw;
            }
            catch (InvalidCastException invalidCastException)
            {
                Console.WriteLine(invalidCastException);
                throw;
            }
        }
    }
}
