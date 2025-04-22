using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework; // Giữ lại để dùng Order()
using MAssert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using MTestContext = Microsoft.VisualStudio.TestTools.UnitTesting.TestContext;
using System.Threading;

namespace TestWebMageto_08_Thang
{
    [TestClass]
    public class ChucNang3_Register_08_Thang
    {
        // Tạo đối tượng chứa các phương thức dùng chung cho các testcase
        public MagentoTestHelper_08_Thang method = new MagentoTestHelper_08_Thang();

        // Đối tượng TestContext để đọc dữ liệu từ file CSV
        public MTestContext TestContext { get; set; }

        // TC3_1 – Đăng ký thành công
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @".\RegisterData_08_Thang\TC3_1_Register_Thanh_Cong_08_Thang.csv",
            "TC3_1_Register_Thanh_Cong_08_Thang#csv", DataAccessMethod.Sequential)]
        // Chạy đầu tiên
        [TestMethod, Order(1)]
        public void TC3_1_Register_Thanh_Cong_08_Thang()
        {
            string fname = TestContext.DataRow[0].ToString();
            string lname = TestContext.DataRow[1].ToString();
            string email = TestContext.DataRow[2].ToString();
            string password = TestContext.DataRow[3].ToString();
            string confirm = TestContext.DataRow[4].ToString();

            method.Register_08_Thang(fname, lname, email, password, confirm);

            string actualUrl = method.driver_08_Thang.Url;
            MAssert.IsTrue(actualUrl.Contains("customer/account"));

            Thread.Sleep(3000);
            method.driver_08_Thang.Quit();
        }

        // TC3_2 – Không nhập email
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @".\RegisterData_08_Thang\TC3_2_Register_That_Bai_Khong_Nhap_Email_08_Thang.csv",
            "TC3_2_Register_That_Bai_Khong_Nhap_Email_08_Thang#csv", DataAccessMethod.Sequential)]
        // Chạy thứ hai
        [TestMethod, Order(2)]
        public void TC3_2_Register_That_Bai_Khong_Nhap_Email_08_Thang()
        {
            string fname = TestContext.DataRow[0].ToString();
            string lname = TestContext.DataRow[1].ToString();
            string email = TestContext.DataRow[2].ToString();
            string password = TestContext.DataRow[3].ToString();
            string confirm = TestContext.DataRow[4].ToString();

            method.Register_08_Thang(fname, lname, email, password, confirm);

            string error = method.GetEmailError_Register_08_Thang();
            MAssert.AreEqual("This is a required field.", error);

            Thread.Sleep(3000);
            method.driver_08_Thang.Quit();
        }

        // TC3_3 – Không nhập mật khẩu
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @".\RegisterData_08_Thang\TC3_3_Register_That_Bai_Khong_Nhap_MatKhau_08_Thang.csv",
            "TC3_3_Register_That_Bai_Khong_Nhap_MatKhau_08_Thang#csv", DataAccessMethod.Sequential)]
        // Chạy thứ ba
        [TestMethod, Order(3)]
        public void TC3_3_Register_That_Bai_Khong_Nhap_MatKhau_08_Thang()
        {
            string fname = TestContext.DataRow[0].ToString();
            string lname = TestContext.DataRow[1].ToString();
            string email = TestContext.DataRow[2].ToString();
            string password = TestContext.DataRow[3].ToString();
            string confirm = TestContext.DataRow[4].ToString();

            method.Register_08_Thang(fname, lname, email, password, confirm);

            string error = method.GetPasswordError_Register_08_Thang();
            MAssert.AreEqual("This is a required field.", error);

            Thread.Sleep(3000);
            method.driver_08_Thang.Quit();
        }
    }
}
