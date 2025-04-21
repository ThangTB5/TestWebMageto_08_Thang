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
    // Chức năng tim kiếm sản phẩm
    [TestClass]
    public class ChucNang2_Search_08_Thang
    {
        // Tạo đối tượng chứa các phương thức dùng chung cho các testcase
        public MagentoTestHelper_08_Thang method = new MagentoTestHelper_08_Thang();
        public MTestContext TestContext { get; set; }

        // TestCase 2.1 – Tìm kiếm sản phẩm thành công
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                    @".\SearchData_08_Thang\TC2_1_Search_Thanh_Cong_08_Thang.csv",
                    "TC2_1_Search_Thanh_Cong_08_Thang#csv", DataAccessMethod.Sequential)]
        [TestMethod, Order(1)] // Chạy đầu tiên
        public void TC2_1_Search_Thanh_Cong_08_Thang()
        {
            string keyword = TestContext.DataRow[0].ToString();

            method.TimKiemSanPham_08_Thang(keyword);
            string tenSanPham = method.LayTenSanPham_08_Thang();

            // Kiểm tra có sản phẩm nào xuất hiện không
            MAssert.AreNotEqual("Không tìm thấy sản phẩm", tenSanPham);
            Console.WriteLine("Kết quả: " + tenSanPham);

            Thread.Sleep(3000);
            method.driver_08_Thang.Quit();
        }

        // TestCase 2.2 – Tìm kiếm không ra kết quả
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                    @".\SearchData_08_Thang\TC2_2_Search_Khong_Tim_Thay_San_Pham_08_Thang.csv",
                    "TC2_2_Search_Khong_Tim_Thay_San_Pham_08_Thang#csv", DataAccessMethod.Sequential)]
        
        [TestMethod, Order(2)] // Chạy thứ hai
        public void TC2_2_Search_Khong_Tim_Thay_San_Pham_08_Thang()
        {
            string keyword = TestContext.DataRow[0].ToString();

            method.TimKiemSanPham_08_Thang(keyword);
            string thongBao = method.KhongTimThaySanPham_08_Thang();

            string expectedMessage = "Your search returned no results.";
            MAssert.IsTrue(thongBao.Contains(expectedMessage));
            Console.WriteLine("Thông báo: " + thongBao);

            Thread.Sleep(3000);
            method.driver_08_Thang.Quit();
        }

    }
}
