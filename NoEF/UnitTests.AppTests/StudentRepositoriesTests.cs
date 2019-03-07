using Xunit;
using UnitTests.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Data.SqlClient;

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

        #region   Mock ISQLHelper
        private ISQLServerHelper prvSqlHelperFeed()
        {
            Mock<ISQLServerHelper> mockObject = new Mock<ISQLServerHelper>();
            mockObject.Setup(m => m.ExecSql(It.IsAny<string>(), It.IsAny<SqlParameter[]>())).Returns(true); //表示任意string
            return mockObject.Object;
        }

        [Fact()]
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
        [Fact()]
        public void TC1_Divide9By3()
        {
            IUSD_RMB_ExchangeRateFeed feed = this.prvGetMockExchangeRateFeed();
            ICalculator calculator = new Calculator(feed);
            int actualResult = calculator.Divide(9, 3);
            int expectedResult = 3;
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact()]
        public void TC2_DivideByZero()
        {
            try
            {
                IUSD_RMB_ExchangeRateFeed feed = this.prvGetMockExchangeRateFeed();
                ICalculator calculator = new Calculator(feed);
                int actualResult = calculator.Divide(9, 0);
            }
            catch (Exception ex)
            {
                Assert.True(ex is System.DivideByZeroException);
            }
            Assert.True(false, "DivideByZeroException not occured");
        }
        [Fact()]
        public void TC3_ConvertUSDtoRMBTest()
        {
            IUSD_RMB_ExchangeRateFeed feed = this.prvGetMockExchangeRateFeed();
            ICalculator calculator = new Calculator(feed);
            int actualResult = calculator.ConvertUSDtoRMB(1);
            int expectedResult = 500;
            Assert.Equal(expectedResult, actualResult);
        }
        #endregion

        [Theory]
        [InlineData(1, 2)]
        [InlineData(0, 2)]
        [InlineData(2, 2)]
        //[InlineData(1, 0)]
        public void ModeTest(int a, int b)
        {
            StudentRepositories r = new StudentRepositories();
            Assert.True(a%b==r.Mode(a,b));
        }


        [Theory]
        [InlineData(1, 0)]
        public void ModeTestByZero(int a, int b)
        {
            StudentRepositories r = new StudentRepositories();
            Assert.Throws<System.DivideByZeroException>(() => r.Mode(a,b));
        }
    }
}