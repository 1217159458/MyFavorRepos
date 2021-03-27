using Microsoft.AspNetCore.Mvc;
using MyFavorRepos.Common;
using MyFavorRepos.Data;
using MyFavorRepos.Data.Dal.Entity;
using MyFavorRepos.Service.IService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyFavorRepos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MgFavorReposController : ControllerBase
    {
        #region 全局变量
        private readonly ILeftService _iLeft = null;
        private readonly IRightService _iRight = null;
        private readonly ILeftRepository _LeftRepository = null;
        #endregion

        #region 构造函数注入
        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="leftRepository"></param>
        public MgFavorReposController(ILeftService left, IRightService right, ILeftRepository leftRepository)
        {
            _iLeft = left;
            _iRight = right;
            _LeftRepository = leftRepository;
        }
        #endregion

        #region 页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Load")]
        public string Load()
        {
            var leftList = new List<tbl_Left>();
            var html = HttpRequestUtil.DownloadUrl(@"https://github.com/idcf-boat-house");
            
            if (!string.IsNullOrEmpty(html))
            {
                Log4NetUtil.LogInfo("GitHub地址访问成功");
                var list = HttpRequestUtil.GetContent(html);
                if (list != null && list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        leftList.Add(new tbl_Left { name = item });
                    }

                    Log4NetUtil.LogInfo("初始化更新数据库开始");
                    IDbTransaction transaction = this._LeftRepository.DBSession.Begin();
                    try
                    {
                        _iRight.DeleteAll();
                        _iLeft.DeleteAll();
                        _iLeft.InsertBatch(leftList);
                    }
                    catch (Exception exception)
                    {
                        this._LeftRepository.DBSession.Rollback();
                        Log4NetUtil.LogError(exception.Message, exception);
                    }
                    finally
                    {
                        this._LeftRepository.DBSession.Commit();
                        Log4NetUtil.LogInfo("初始化更新数据库成功");
                    }
                }

                return _iLeft.GetList();
            }
            else
            {
                Log4NetUtil.LogInfo("GitHub地址访问失败");
                return string.Empty;
            }
        }
        #endregion

        #region 左右切换
        /// <summary>
        /// 左右切换
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Switch")]
        public string Switch(string left, string right)
        {
            List<string> lefts = left?.Trim('\'')?.Trim().Split(',')?.ToList();
            List<string> rights = right?.Trim('\'')?.Trim().Split(',')?.ToList();
            List<tbl_Left> tbl_Lefts = (from c in lefts where !string.IsNullOrEmpty(c) select new tbl_Left { name = c } )?.ToList();
            List<tbl_Right> tbl_rights = (from c in rights where !string.IsNullOrEmpty(c) select new tbl_Right { name = c })?.ToList();
            Log4NetUtil.LogInfo("左右切换更新数据库开始");
            IDbTransaction transaction = this._LeftRepository.DBSession.Begin();
            try
            {
                _iLeft.DeleteAll();
                _iRight.DeleteAll();
                if (lefts != null && lefts.Count > 0)
                {
                    
                    _iLeft.InsertBatch(tbl_Lefts);
                }

                if (rights != null && rights.Count > 0)
                {
                    _iRight.InsertBatch(tbl_rights);
                }
                this._LeftRepository.DBSession.Commit();
                Log4NetUtil.LogInfo("左右切换更新数据库成功");
            }
            catch (Exception exception)
            {
                this._LeftRepository.DBSession.Rollback();
                Log4NetUtil.LogError(exception.Message, exception);
            }

            return $"{_iLeft.GetList()};{_iRight.GetList()}";
        }
        #endregion

        #region 生成邮件
        /// <summary>
        /// 生成邮件
        /// </summary>
        /// <param name="right"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GenerateEmail")]
        public string GenerateEmail()
        {
            var rightList = JSONHelper.ToObject<List<tbl_Right>>(_iRight.GetList());
            if (rightList == null || rightList.Count() == 0)
            {
                Log4NetUtil.LogInfo("tbl_Right不存在数据");
                return string.Empty;
            }

            var html = HttpRequestUtil.DownloadUrl(@"https://github.com/idcf-boat-house");
            if (!string.IsNullOrEmpty(html))
            {
                Log4NetUtil.LogInfo("GitHub地址访问成功");
                return HttpRequestUtil.GetDetail(html, rightList.Select(c => c.name).ToList());
            }
            else
            {
                Log4NetUtil.LogInfo("GitHub地址访问失败");
                return string.Empty;
            }
        }
        #endregion

        #region 获取左侧列表
        /// <summary>
        /// 获取左侧列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetLeftList")]
        public string GetLeftList()
        {
            return _iLeft.GetList();
        }
        #endregion
    }
}
