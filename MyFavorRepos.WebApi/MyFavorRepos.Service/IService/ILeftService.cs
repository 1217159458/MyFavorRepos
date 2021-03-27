using MyFavorRepos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavorRepos.Service.IService
{
    public interface ILeftService
    {
        int Submit(tbl_Left left);
        bool Insert(tbl_Left left);
        string GetList();
    }
}
