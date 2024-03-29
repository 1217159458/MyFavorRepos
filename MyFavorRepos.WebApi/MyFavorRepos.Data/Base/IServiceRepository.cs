﻿using DapperExtensions;
using MyFavorRepos.Data.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavorRepos.Data.Base
{
    public interface IServiceRepository
    {
        IDBSession DBSession { get; }
        T GetById<T>(dynamic primaryId) where T : class;
        IEnumerable<T> GetByIds<T>(string primarykey, IList<dynamic> ids, string tablename = "") where T : class;
        IEnumerable<T> GetAll<T>() where T : class;
        int Count<T>(object predicate, bool buffered = false) where T : class;
        IEnumerable<T> GetList<T>(object predicate = null, IList<ISort> sort = null, bool buffered = false) where T : class;
        IEnumerable<T> GetPageList<T>(int pageIndex, int pageSize, out long allRowsCount, object predicate = null, IList<ISort> sort = null, bool buffered = true) where T : class;
        dynamic Insert<T>(T entity, IDbTransaction transaction = null) where T : class;
        bool InsertBatch<T>(IEnumerable<T> entityList, IDbTransaction transaction = null) where T : class;
        bool Update<T>(T entity, IDbTransaction transaction = null) where T : class;
        bool UpdateBatch<T>(IEnumerable<T> entityList, IDbTransaction transaction = null) where T : class;
        bool Delete<T>(dynamic primaryId, IDbTransaction transaction = null) where T : class;
        bool DeleteList<T>(object predicate, IDbTransaction transaction = null) where T : class;
        bool DeleteBatch<T>(IEnumerable<dynamic> ids, IDbTransaction transaction = null) where T : class;
    }
}
