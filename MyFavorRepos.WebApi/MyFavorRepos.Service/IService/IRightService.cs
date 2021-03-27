using MyFavorRepos.Data;
using MyFavorRepos.Data.Dal.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavorRepos.Service.IService
{
    public interface IRightService
    {
        int Submit(tbl_Right left);
        bool Insert(tbl_Right left);
        string GetList();

        void DeleteAll(IDbTransaction transaction = null);
        bool InsertBatch(List<tbl_Right> list);
    }
}
