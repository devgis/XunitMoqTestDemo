using Xunit;
using UnitTests.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.App.Tests
{
    public class StudentRepositoriesTests
    {
        [Fact()]
        public void AddBySqlTest()
        {
            Random rd = new Random();
            StudentRepositories r = new StudentRepositories();
            Student student = new Student()
            {
                ID = Guid.NewGuid().ToString(),
                Name = "张三" + rd.Next(1, 100000),
                Age = rd.Next(12, 20),
                Remark = "Remarks" + rd.Next(1, 100000)
            };
            Assert.True(r.AddBySql(student));
        }

        //[Fact()]
        //public void AddTest()
        //{
        //    StudentRepositories r = new StudentRepositories();
        //    Student student = new Student()
        //    {
        //        ID = Guid.NewGuid().ToString(),
        //        Name = "张三"
        //    };
        //    int i = r.Add(student);
        //    Assert.True(i >= 1);
        //}

        //[Fact()]
        //public void AddTest2()
        //{
        //    StudentRepositories r = new StudentRepositories();
        //    Student student = new Student()
        //    {
        //        ID = Guid.NewGuid().ToString(),
        //        Name = "张三"
        //    };
        //    var model = r.AddRetrun(student);
        //    Assert.True(model != null);
        //}
    }
}