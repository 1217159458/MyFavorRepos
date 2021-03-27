using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavorRepos.Data.DataAccess
{
    public class DBHelper
    {
        /// <summary>
        /// 根据配置文件获取字符串创建连接对象和DBSession
        /// </summary>
        /// <param name="conn">默认为空，从Connections:DefaultConnect配置节中读取</param>
        /// <param name="databaseType">默认为MySql</param>
        /// <returns></returns>
        public static DBSession CreateDBSession(string conn = "", DatabaseType databaseType = DatabaseType.SqlServer)
        {
            return new DBSession(new Database(conn, databaseType: databaseType));
        }
    }
}
