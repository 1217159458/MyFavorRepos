using DapperExtensions;
using MyFavorRepos.Data.Base;
using MyFavorRepos.Data.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavorRepos.Data
{
    public class LeftRepository : Repository, ILeftRepository
    {
        public LeftRepository() : base()
        {

        }

        public LeftRepository(string conn, DataAccess.DatabaseType databaseType)
           : base(conn, databaseType)
        {
        }
    }
}
