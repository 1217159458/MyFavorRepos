using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavorRepos.Data.Base
{
    public interface IDataRepository
    {
        int Execute(string sql, dynamic param = null, IDbTransaction transaction = null);
        IEnumerable<T> Get<T>(string sql, dynamic param = null, bool buffered = true) where T : class;
    }
}
