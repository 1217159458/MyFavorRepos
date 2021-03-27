using MyFavorRepos.Data;
using MyFavorRepos.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFavorRepos.Common;
using MyFavorRepos.Data.Dal.Entity;
using System.Data;

namespace MyFavorRepos.Service.Implement
{
    public class RightService : IRightService
    {
        private readonly IRightRepository _rightRepository;
        public RightService(IRightRepository rightRepository)
        {
            this._rightRepository = rightRepository;
        }
        public string GetList()
        {
           return _rightRepository.GetAll<tbl_Right>()?.ToJson();
        }

        public bool Insert(tbl_Right left)
        {
            throw new NotImplementedException();
        }

        public int Submit(tbl_Right left)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll(IDbTransaction transaction = null)
        {
            var list = _rightRepository.GetAll<tbl_Right>();
            if (list != null && list.Count() > 0)
            {
                _rightRepository.DeleteList<tbl_Right>(list);
            }
        }

        public bool InsertBatch(List<tbl_Right> list)
        {
            return _rightRepository.InsertBatch<tbl_Right>(list);
        }
    }
}
