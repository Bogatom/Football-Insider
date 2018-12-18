using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDL;

namespace Interfaces_BLL_DAL
{
    public interface IHistoryRepository
    {
        List<History> GetHistories();
    }
}
