using CentralDeFinancas.BDD.Helpers;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace CentralDeFinancas.BDD.TestSteps
{
    [Binding] //Classe de testes do specflow
    public class AutenticarUsuarioTestSteps
    {
        private WebDriver? _driver;

        [Given(@"Acessar a página de autenticação de usuário")]
        public void GivenAcessarAPaginaDeAutenticacaoDeUsuario()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(TestHelper.BASE_URL + "Account/Login");
        }

        [Given(@"Informar o e-mail de acesso ""([^""]*)""")]
        public void GivenInformarOE_MailDeAcesso(string email)
        {
            var element = _driver.FindElement(By.XPath("//*[@id=\"Email\"]"));
            element.SendKeys(email);
        }

        [Given(@"Informar a senha de acesso ""([^""]*)""")]
        public void GivenInformarASenhaDeAcesso(string senha)
        {
            var element = _driver.FindElement(By.XPath("//*[@id=\"Senha\"]"));
            element.SendKeys(senha);
        }

        [When(@"Solicitar a realização do acesso")]
        public void WhenSolicitarARealizacaoDoAcesso()
        {
            var element = _driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[3]/input"));
            element.Click();
        }

        [Then(@"Sistema autentica o usuário e exibe a página de Dashboard")]
        public void ThenSistemaAutenticaOUsuarioEExibeAPaginaDeDashboard()
        {
            _driver.Url.Should().Be(TestHelper.BASE_URL + "Dashboard/Index");
            TestHelper.CreateScreeShot(_driver, $"AutenticarUsuarioComSucesso{DateTime.Now.ToString("ddMMyyyyhhmmss")}");
            _driver.Close();
        }

        [Then(@"Sistema informa que o acesso é negado")]
        public void ThenSistemaInformaQueOAcessoENegado()
        {
            var element = _driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div/strong"));
            element.Text.Should().Be("Acesso negado. Usuário não encontrado.");
            TestHelper.CreateScreeShot(_driver, $"AcessoNegado{DateTime.Now.ToString("ddMMyyyyhhmmss")}");
            _driver.Close();
        }

    }
}
