using DapperExtensions.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavorRepos.Data.DataAccess
{
    /// <summary>
    /// 数据库链接工厂类
    /// </summary>
    public class ConnectionFactory
    {
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <returns></returns>
        public static IDbConnection CreateConnection(string strConn)
        {
            return CreateConnection(strConn, DatabaseType.MySql);

        }
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <returns></returns>
        public static IDbConnection CreateConnection(string strConn, DatabaseType databaseType)
        {
            IDbConnection connection = null;
            //获取配置进行转换
            switch (databaseType)
            {
                case DatabaseType.SqlServer:
                    DapperExtensions.DapperExtensions.SqlDialect = new SqlServerDialect();
                    connection = new SqlConnection(strConn);
                    break;
                case DatabaseType.MySql:
                    break;
                case DatabaseType.Sqlite:
                    break;
                case DatabaseType.Oracle:
                    break;
            }
            return connection;
        }
    }
}
