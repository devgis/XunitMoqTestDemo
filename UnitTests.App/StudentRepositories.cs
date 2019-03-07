using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace UnitTests.App
{
    public class StudentRepositories
    {
        public SchoolContext db = new SchoolContext();
        public StudentRepositories()
        {
            try
            {
                //db.Database.Create();
            }
            catch
            { }
        }

        public DbSet<Student> Students
        {
            get
            {
                return db.Students;
            }
        }
        public int Add(Student model)
        {
            db.Set<Student>().Add(model);
            return db.SaveChanges();
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

        public Student AddRetrun(Student model)
        {
            var mod = db.Set<Student>().Add(model);
            db.SaveChanges();
            return mod;
        }
    }
}
