using MyFavorRepos.Data;
using MyFavorRepos.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFavorRepos.Common;

namespace MyFavorRepos.Service.Implement
{
    public class LeftService : ILeftService
    {
        private readonly ILeftRepository _LeftRepository;
        public LeftService(ILeftRepository leftRepository)
        {
            this._LeftRepository = leftRepository;
        }
        public string GetList()
        {
           return  _LeftRepository.GetAll<tbl_Left>()?.ToJson();
        }

        public bool Insert(tbl_Left left)
        {
            throw new NotImplementedException();
        }

        public int Submit(tbl_Left left)
        {
            throw new NotImplementedException();
        }
    }
}
