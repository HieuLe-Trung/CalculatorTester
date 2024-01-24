using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using calculator;

namespace CalculatorTest
{
    [TestClass] //có nhiều testcase
    public class UnitTest1
    {
        private Calculation c;
        public TestContext TestContext { get; set; }//tạo đối tượng cho phép đọc, ghi lên file TestData.csv
        [TestInitialize] //thiết lập bộ dữ liệu dùng chung cho tất cả các TestCase
        public void SetUp()
        {
            c = new Calculation(15, 5);
        }
        [TestMethod] //đây là 1 testcase
        public void TestAddOperator()
        {
            double expected, actual;//1 biến mong đợi và 1 biến kết quá của hàm
            //Calculation c = new Calculation(15, 5);
            //kịch bản cộng 5 và 15 xem ra kq(expected) = 20 không
            expected = 20;
            actual = c.Execute("+");
            Assert.AreEqual(expected, actual);//so sánh kq của kịch bản xem khớp không

        }
        [TestMethod]
        public void TestSubOperator()
        {
            double expected, actual;
            //Calculation c = new Calculation(15, 5);
            expected = 10;
            actual = c.Execute("-");
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TestMulOperator()
        {
            double expected, actual;
            //Calculation c = new Calculation(15, 5);
            expected = 75;
            actual = c.Execute("*");
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TestDivOperator()
        {
            double expected, actual;
            //Calculation c = new Calculation(15, 5);
            expected = 3;
            actual = c.Execute("/");
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TestDivByZero()
        {
            c = new Calculation(15, 0);
            //TH chia 0 bị lỗi nhưng có thẻ [DivideByZero] đã bắt được lỗi
            Assert.ThrowsException<DivideByZeroException>(() => c.Execute("/"));
        }

        //Liên kết TestData với project
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @".\Data\TestData.csv", "TestData#csv",DataAccessMethod.Sequential)]//Sequential: đọc tuần tự từ trên xuống
        public void TestWithDataSource()
        {
            int a, b;
            double expected, actual;
            string operation;
            a = int.Parse(TestContext.DataRow[0].ToString());//đọc dữ liệu của từng dòng, lấy cột 0 của dòng đó
            b = int.Parse(TestContext.DataRow[1].ToString());
            operation = TestContext.DataRow[2].ToString();
            operation = operation.Remove(0, 1);
            expected = double.Parse(TestContext.DataRow[3].ToString());
            c = new Calculation(a, b);
            actual = c.Execute(operation);
            Assert.AreEqual(expected, actual);

        }
    }
}
