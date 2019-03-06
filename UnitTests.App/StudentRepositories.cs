using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                db.Database.Create();
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
        public void Add(Student model)
        {
            db.Set<Student>().Add(model);
            db.SaveChanges();
        }

        public Student AddRetrun(Student model)
        {
            var mod = db.Set<Student>().Add(model);
            db.SaveChanges();
            return mod;
        }
    }
}
