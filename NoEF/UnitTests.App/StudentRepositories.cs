using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace UnitTests.App
{
    public class StudentRepositories
    {
        public StudentRepositories()
        {
        }


        public bool AddBySql(Student model)
        {
            string sql = "insert into Students(ID,Name,Age,Remark)values(@ID,@Name,@Age,@Remark)";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("ID",model.ID),
                new SqlParameter("Name",model.Name),
                new SqlParameter("Age",model.Age),
                new SqlParameter("Remark",model.Remark)
            };
            return SQLServerHelper.ExecSql(sql,parameters);
        }


        public bool AddBySql2(Student model, ISQLServerHelper helper)
        {
            string sql = "insert into Students(ID,Name,Age,Remark)values(@ID,@Name,@Age,@Remark)";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("ID",model.ID),
                new SqlParameter("Name",model.Name),
                new SqlParameter("Age",model.Age),
                new SqlParameter("Remark",model.Remark)
            };
            bool rs= helper.ExecSql(sql, parameters);
            return rs;
        }
    }
}
