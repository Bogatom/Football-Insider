using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contexts;
using Interfaces_BLL_DAL;
using MDL;

namespace DAL
{
    public class HistoryRepository : IHistoryRepository
    {
        IHistoryContext _context;

        public HistoryRepository(IHistoryContext context)
        {
            _context = context;
        }

        public List<History> GetHistories()
        {
            return _context.GetHistories();
        }
    }
}
