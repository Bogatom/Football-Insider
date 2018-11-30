using Interfaces_BLL_DAL;
using MDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoryRepository : ICategoryRepository
    {
        ICategoryContext _context;

        public CategoryRepository(ICategoryContext context)
        {
            _context = context;
        }

        public List<Category> GetAllCategories()
        {
            return _context.GetAllCategories();
        }
    }
}
