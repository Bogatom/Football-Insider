using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces_BLL_DAL;
using Interfaces_UI_BLL;
using MDL;

namespace BLL
{
    public class HistoryLogic : IHistoryLogic
    {
        IHistoryRepository _repo;

        public HistoryLogic(IHistoryRepository repo)
        {
            _repo = repo;
        }

        public List<History> GetHistories()
        {
            try
            {
                return _repo.GetHistories();
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
