using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

public class LoginPage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
    }

    // Метод для відкриття сторінки
    public void OpenLoginPage(string url)
    {
        driver.Navigate().GoToUrl(url);
    }

    // Метод для входу як Customer
    public void LoginAsCustomer(string customerName)
    {
        IWebElement customerLoginButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[text()='Customer Login']")));
        customerLoginButton.Click();

        // Вибір користувача зі списку
        SelectElement customerDropdown = new SelectElement(wait.Until(ExpectedConditions.ElementIsVisible(By.Id("userSelect"))));
        customerDropdown.SelectByText(customerName);

        IWebElement loginButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[text()='Login']")));
        loginButton.Click();
    }

    // Метод для вибору рахунку
    public void SelectAccount(string accountNumber)
    {
        SelectElement accountDropdown = new SelectElement(wait.Until(ExpectedConditions.ElementIsVisible(By.Id("accountSelect"))));
        accountDropdown.SelectByText(accountNumber);
    }

    // Метод для виконання операції Withdraw
    public void PerformWithdraw(string amount)
    {
        IWebElement withdrawButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),'Withdrawl')]")));
        withdrawButton.Click();

        IWebElement amountInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@ng-model='amount']")));
        amountInput.SendKeys(amount);

        IWebElement submitWithdrawButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[text()='Withdraw']")));
        submitWithdrawButton.Click();
    }

    // Метод для перевірки балансу
    public string GetBalance()
    {
        IWebElement balanceLabel = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//strong[2]")));
        return balanceLabel.Text;
    }

    // Метод для закриття браузера
    public void CloseDriver()
    {
        if (driver != null)
        {
            driver.Quit();
        }
    }
}
