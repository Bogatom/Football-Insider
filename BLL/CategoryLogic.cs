using Interfaces_BLL_DAL;
using Interfaces_UI_BLL;
using System;
using System.Collections.Generic;
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
    }
}
