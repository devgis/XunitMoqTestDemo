using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.App.Tests
{
    [TestClass()]
    public class StudentRepositoriesTests
    {
        [TestMethod()]
        public void AddTest()
        {
            StudentRepositories r = new StudentRepositories();
            Student student = new Student()
            {
                ID = Guid.NewGuid().ToString(),
                Name = "张三"
            };
            r.Add(student);
            var model = r.Students.Where(t => t.ID == student.ID).FirstOrDefault();
            Assert.IsTrue(model != null);
        }

        [TestMethod()]
        public void AddTest2()
        {
            StudentRepositories r = new StudentRepositories();
            Student student = new Student()
            {
                ID = Guid.NewGuid().ToString(),
                Name = "张三"
            };
            r.Add(student);
            var model = r.AddRetrun(student);
            Assert.IsTrue(model != null);
        }

        [TestMethod()]
        public void AddTest_Mok()
        {
            StudentRepositories r = new StudentRepositories();
            Student student = new Student()
            {
                ID = Guid.NewGuid().ToString(),
                Name = "张三"
            };
            r.Add(student);
            var model = r.Students.Where(t => t.Name == "张三").FirstOrDefault();
            Assert.IsTrue(model != null);
        }
    }
}