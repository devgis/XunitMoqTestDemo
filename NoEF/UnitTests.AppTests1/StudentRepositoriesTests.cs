using NUnit.Framework;
using UnitTests.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Data.SqlClient;

namespace UnitTests.App.Nunit3Tests
{
    [TestFixture()]
    public class StudentRepositoriesTests
    {

        [Test()]
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

        #region   Mock ISQLHelper
        private ISQLServerHelper prvSqlHelperFeed()
        {
            Mock<ISQLServerHelper> mockObject = new Mock<ISQLServerHelper>();
            mockObject.Setup(m => m.ExecSql(It.IsAny<string>(), It.IsAny<SqlParameter[]>())).Returns(true); //表示任意string
            return mockObject.Object;
        }

        [Test()]
        public void AddBySqlTest2()
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
            bool rs = r.AddBySql2(student, this.prvSqlHelperFeed());
            Assert.True(r.AddBySql2(student, this.prvSqlHelperFeed()));
        }
        #endregion

        #region 第三方Demo
        // 定义mock的逻辑
        private IUSD_RMB_ExchangeRateFeed prvGetMockExchangeRateFeed()
        {
            Mock<IUSD_RMB_ExchangeRateFeed> mockObject = new Mock<IUSD_RMB_ExchangeRateFeed>();
            mockObject.Setup(m => m.GetActualUSDValue()).Returns(500);
            return mockObject.Object;
        }
        // 测试divide方法
        [Test()]
        public void TC1_Divide9By3()
        {
            IUSD_RMB_ExchangeRateFeed feed = this.prvGetMockExchangeRateFeed();
            ICalculator calculator = new Calculator(feed);
            int actualResult = calculator.Divide(9, 3);
            int expectedResult = 3;
            Assert.Equals(expectedResult, actualResult);
        }
        [Test()]
        public void TC2_DivideByZero()
        {
            Assert.Throws<System.DivideByZeroException>(() => {
                IUSD_RMB_ExchangeRateFeed feed = this.prvGetMockExchangeRateFeed();
                ICalculator calculator = new Calculator(feed);
                int actualResult = calculator.Divide(9, 0);
            });
        }

        [Test()]
        public void TC3_ConvertUSDtoRMBTest()
        {
            IUSD_RMB_ExchangeRateFeed feed = this.prvGetMockExchangeRateFeed();
            ICalculator calculator = new Calculator(feed);
            int actualResult = calculator.ConvertUSDtoRMB(1);
            int expectedResult = 500;
            Assert.Equals(expectedResult, actualResult);
        }
        #endregion

        [Theory()]
        [TestCase(1, 2)]
        [TestCase(0, 2)]
        [TestCase(2, 2)]
        public void ModeTest(int a, int b)
        {
            StudentRepositories r = new StudentRepositories();
            Assert.True(a % b == r.Mode(a, b));
        }

        [Theory]
        [TestCase(1, 0)]
        public void ModeTestByZero(int a, int b)
        {
            StudentRepositories r = new StudentRepositories();
            Assert.Throws<System.DivideByZeroException>(() => r.Mode(a, b));
        }
    }
}