using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
// Các phương thức định nghĩa
using MAssert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using MTestContext = Microsoft.VisualStudio.TestTools.UnitTesting.TestContext;
using System.Threading;



namespace TestWebMageto_08_Thang
{
    
    [TestClass]
    public class ChucNang1_Login_08_Thang
    {
        // Tạo đối tượng chứa các phương thức dùng chung cho các testcase
        public MagentoTestHelper_08_Thang method = new MagentoTestHelper_08_Thang();

        // Đối tượng TestContext để đọc dữ liệu từ file CSV
        public MTestContext TestContext { get; set; }

        // TestCase 1.1 – Đăng nhập thành công
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                    @".\LoginData_08_Thang\DataTestCase1_1_08_Thang.csv",
                    "DataTestCase1_1_08_Thang#csv", DataAccessMethod.Sequential)]
        [TestMethod, Order(1)] // Testcase chạy đầu tiên
        public void TC1_1_Login_Thanh_Cong_08_Thang()
        {
            // Đọc email và password từ file CSV
            string email = TestContext.DataRow[0].ToString();
            string password = TestContext.DataRow[1].ToString();

            // Gọi hàm đăng nhập với dữ liệu đã đọc
            method.Login_08_Thang(email, password);

            // Lấy URL hiện tại sau khi đăng nhập
            string actualUrl = method.driver_08_Thang.Url;

            // Giá trị URL mong muốn sau khi đăng nhập thành công
            string expectedUrlContains = "customer/account";

            // So sánh kết quả thực tế và mong đợi
            if (actualUrl.Contains(expectedUrlContains))
                Console.WriteLine("Pass! (Test Case: TC1)");
            else
                Console.WriteLine("Fail! (Test Case: TC1)");

            // Dừng để quan sát kết quả
            Thread.Sleep(4000);

            // Đóng trình duyệt sau khi test xong
            method.driver_08_Thang.Quit();
        }

        // TestCase 1.2 – Đăng nhập thất bại khi không nhập email

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                    @".\LoginData_08_Thang\DataTestCase1_2_08_Thang.csv",
                    "DataTestCase1_2_08_Thang#csv", DataAccessMethod.Sequential)]
        [TestMethod, Order(2)] // Testcase chạy thứ 2
        public void TC1_2_Login_That_Bai_Khong_Nhap_Email_08_Thang()
        {
            // Đọc dữ liệu: email rỗng, password hợp lệ
            string email = TestContext.DataRow[0].ToString();
            string password = TestContext.DataRow[1].ToString();

            // Gọi hàm đăng nhập
            method.Login_08_Thang(email, password);

            // Gọi hàm lấy cảnh báo sau đăng nhập
            string actualAlert = method.GetAlertMessage_08_Thang();

            // Cảnh báo kỳ vọng từ hệ thống Magento
            string expectedAlert = "This is a required field.";

            // So sánh kết quả
            MAssert.AreEqual(expectedAlert, actualAlert);

            Thread.Sleep(4000);
            method.driver_08_Thang.Quit();
        }

        // TestCase 1.3 – Đăng nhập thất bại khi không nhập password
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                    @".\LoginData_08_Thang\DataTestCase1_3_08_Thang.csv",
                    "DataTestCase1_3_08_Thang#csv", DataAccessMethod.Sequential)]
        [TestMethod, Order(3)] // Testcase chạy thứ 3
        public void TC1_3_Login_That_Bai_Khong_Nhap_MatKhau_08_Thang()
        {
            // Đọc dữ liệu: email hợp lệ, password rỗng
            string email = TestContext.DataRow[0].ToString();
            string password = TestContext.DataRow[1].ToString();

            // Gọi hàm đăng nhập
            method.Login_08_Thang(email, password);

            // Gọi hàm lấy cảnh báo lỗi
            string actualAlert = method.GetAlertMessage_08_Thang();

            // Giá trị cảnh báo mong muốn
            string expectedAlert = "This is a required field.";

            // So sánh thực tế và mong đợi
            MAssert.AreEqual(expectedAlert, actualAlert);

            Thread.Sleep(4000);
            method.driver_08_Thang.Quit();
        }

    }
}
