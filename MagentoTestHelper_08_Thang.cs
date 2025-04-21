using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TestWebMageto_08_Thang
{
    // Khai báo lớp MagentoTestHelper_08_Thang ở dạng public để dùng chung cho các UnitTest
    public class MagentoTestHelper_08_Thang
    {
        // Khởi tạo WebDriver để mở Chrome
        public IWebDriver driver_08_Thang = new ChromeDriver();

        public MagentoTestHelper_08_Thang() { }

        // Truy cập trang chủ Magento
        public void TruyCapTrangChu_08_Thang()
        {
            driver_08_Thang.Navigate().GoToUrl("https://magento.softwaretestingboard.com/");
        }

        // Truy cập trang đăng nhập
        public void TruyCapTrangLogin_08_Thang()
        {
            driver_08_Thang.Navigate().GoToUrl("https://magento.softwaretestingboard.com/customer/account/login/");
        }


        // Thực hiện đăng nhập
        public void Login_08_Thang(string email, string password)
        {
            TruyCapTrangLogin_08_Thang();

            // Nhập email bằng thuộc tính name
            IWebElement emailInput = driver_08_Thang.FindElement(By.Name("login[username]"));
            emailInput.SendKeys(email);

            // Nhập password bằng thuộc tính ID
            IWebElement passwordInput = driver_08_Thang.FindElement(By.Id("pass"));
            passwordInput.SendKeys(password);

            IWebElement loginButton = driver_08_Thang.FindElement(By.Id("send2"));
            loginButton.Click();

            Thread.Sleep(3000);
        }

        // Lấy cảnh báo khi đăng nhập thất bại
        public string GetAlertMessage_08_Thang()
        {
            try
            {
                IWebElement alert = driver_08_Thang.FindElement(By.CssSelector(".message-error > div"));
                return alert.Text;
            }
            catch (NoSuchElementException)
            {
                return "Không có cảnh báo";
            }
        }

        // Thực hiện tìm kiếm sản phẩm
        public void TimKiemSanPham_08_Thang(string keyword)
        {
            TruyCapTrangChu_08_Thang();

            IWebElement searchBox = driver_08_Thang.FindElement(By.Id("search"));
            searchBox.SendKeys(keyword);
            searchBox.SendKeys(Keys.Enter);

            Thread.Sleep(2000);
        }

        // Trả về tên sản phẩm đầu tiên được tìm thấy
        public string LayTenSanPham_08_Thang()
        {
            try
            {
                IWebElement productName = driver_08_Thang.FindElement(By.CssSelector(".product-item-link"));
                return productName.Text;
            }
            catch (NoSuchElementException)
            {
                return "Không tìm thấy sản phẩm";
            }
        }

        // Trả về thông báo khi không có sản phẩm
        public string KhongTimThaySanPham_08_Thang()
        {
            try
            {
                IWebElement emptyMessage = driver_08_Thang.FindElement(By.CssSelector(".message.notice"));
                return emptyMessage.Text;
            }
            catch (NoSuchElementException)
            {
                return "Không có thông báo nào";
            }
        }

    }
}
