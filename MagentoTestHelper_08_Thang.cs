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

            Thread.Sleep(2000);

            // Nhập password bằng thuộc tính ID
            IWebElement passwordInput = driver_08_Thang.FindElement(By.Id("pass"));
            passwordInput.SendKeys(password);

            Thread.Sleep(2000);

            IWebElement loginButton = driver_08_Thang.FindElement(By.Id("send2"));
            loginButton.Click();

            Thread.Sleep(3000);
        }

        // Trả về thông báo lỗi nếu email bị bỏ trống
        public string GetEmailErrorMessage_08_Thang()
        {
            try
            {
                IWebElement alert = driver_08_Thang.FindElement(By.Id("email-error"));
                return alert.Text;
            }
            catch (NoSuchElementException)
            {
                return "Không có cảnh báo email";
            }
        }

        // Trả về thông báo lỗi nếu password bị bỏ trống
        public string GetPasswordErrorMessage_08_Thang()
        {
            try
            {
                IWebElement alert = driver_08_Thang.FindElement(By.Id("pass-error"));
                return alert.Text;
            }
            catch (NoSuchElementException)
            {
                return "Không có cảnh báo mật khẩu";
            }
        }

        // Trả về thông báo lỗi chung nếu đăng nhập sai thông tin (sai pass, sai email)
        public string GetLoginFailedMessage_08_Thang()
        {
            try
            {
                IWebElement alert = driver_08_Thang.FindElement(By.CssSelector(".message-error > div"));
                return alert.Text;
            }
            catch (NoSuchElementException)
            {
                return "Không có cảnh báo đăng nhập";
            }
        }
        // Thực hiện tìm kiếm sản phẩm
        public void TimKiemSanPham_08_Thang(string keyword)
        {
            // Truy cập trang chủ Magento
            TruyCapTrangChu_08_Thang();
            // Tìm ô tìm kiếm bằng thuộc tính ID
            IWebElement searchBox = driver_08_Thang.FindElement(By.Id("search"));
            // Nhập từ khóa tìm kiếm vào ô tìm kiếm
            searchBox.SendKeys(keyword);
            //Nhấn Enter để tìm kiếm
            searchBox.SendKeys(Keys.Enter);

            Thread.Sleep(2000);
        }

        // Trả về tên sản phẩm đầu tiên được tìm thấy từ kết quả tìm kiếm
        public string LayTenSanPham_08_Thang()
        {
            try
            {
                // Bắt element theo class "product-item-link"
                IWebElement productName = driver_08_Thang.FindElement(By.ClassName("product-item-link"));
                return productName.Text;
            }
            catch (NoSuchElementException)
            {
                return "Không tìm thấy sản phẩm";
            }
        }

        // Trả về thông báo nếu không tìm thấy sản phẩm nào
        public string KhongTimThaySanPham_08_Thang()
        {
            try
            {
                // Lấy nội dung trong div con của message.notice
                IWebElement messageDiv = driver_08_Thang.FindElement(By.CssSelector("div.message.notice > div"));
                return messageDiv.Text.Trim();
            }
            catch (NoSuchElementException)
            {
                return "Không có thông báo nào";
            }
        }


        /// <summary>
        /// Truy cập vào trang đăng ký tài khoản trên Magento
        /// </summary>
        public void TruyCapTrangDangKy_08_Thang()
        {
            driver_08_Thang.Navigate().GoToUrl("https://magento.softwaretestingboard.com/customer/account/create/");
        }


        // Thực hiện đăng ký tài khoản mới
        public void Register_08_Thang(string fname, string lname, string email, string password, string confirmPassword)
        {
            TruyCapTrangDangKy_08_Thang();

            driver_08_Thang.FindElement(By.Id("firstname")).SendKeys(fname);
            Thread.Sleep(2000);
            driver_08_Thang.FindElement(By.Id("lastname")).SendKeys(lname);
            Thread.Sleep(2000);
            driver_08_Thang.FindElement(By.Id("email_address")).SendKeys(email);
            Thread.Sleep(2000);
            driver_08_Thang.FindElement(By.Id("password")).SendKeys(password);
            Thread.Sleep(2000);
            driver_08_Thang.FindElement(By.Id("password-confirmation")).SendKeys(confirmPassword);

            driver_08_Thang.FindElement(By.CssSelector("button[title='Create an Account']")).Click();
            Thread.Sleep(3000);
        }

        // Lấy thông báo lỗi nếu không nhập email
        public string GetEmailError_Register_08_Thang()
        {
            try
            {
                return driver_08_Thang.FindElement(By.Id("email_address-error")).Text;
            }
            catch (NoSuchElementException)
            {
                return "Không có thông báo lỗi email.";
            }
        }

        // Lấy thông báo lỗi nếu không nhập mật khẩu
        public string GetPasswordError_Register_08_Thang()
        {
            try
            {
                return driver_08_Thang.FindElement(By.Id("password-error")).Text;
            }
            catch (NoSuchElementException)
            {
                return "Không có thông báo lỗi mật khẩu.";
            }
        }


    }
}
