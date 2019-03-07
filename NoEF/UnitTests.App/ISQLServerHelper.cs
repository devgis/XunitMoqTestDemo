using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.App
{
    public interface ISQLServerHelper
    {
        bool ExecSql(string sql, SqlParameter[] parameters = null);
    }
}
