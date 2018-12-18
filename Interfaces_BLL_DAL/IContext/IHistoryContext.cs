using MDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces_BLL_DAL
{
    public interface IHistoryContext
    {
        List<History> GetHistories();
    }
}
