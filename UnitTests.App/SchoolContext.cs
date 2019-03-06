using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace UnitTests.App
{
    public class SchoolContext:DbContext
    {
        public SchoolContext() : base("SchoolContext") { }
        public DbSet<Student> Students
        {
            get;
            set;
        }
    }
}
