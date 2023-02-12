using Bogus;
using CentralDeFinancas.BDD.Helpers;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace CentralDeFinancas.BDD.TestSteps
{
    [Binding] //Classe de testes do SpecFlow
    public class CriarContaDeUsuarioTestSteps
    {
        private WebDriver? _driver;
        private Faker _faker = new Faker("pt_BR");

        [Given(@"Acessar a página de cadastro de usuário")]
        public void GivenAcessarAPaginaDeCadastroDeUsuario()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();

            _driver.Navigate().GoToUrl(TestHelper.BASE_URL + "Account/Register");
        }

        [Given(@"Informar o nome")]
        public void GivenInformarONome()
        {
            var element = _driver.FindElement(By.XPath("//*[@id=\"Nome\"]"));
            element.SendKeys(_faker.Person.FullName);
        }

        [Given(@"Informar o email")]
        public void GivenInformarOEmail()
        {
            var element = _driver.FindElement(By.XPath("//*[@id=\"Email\"]"));
            element.SendKeys(_faker.Internet.Email().ToLower());
        }

        [Given(@"Informar e Confirmar senha")]
        public void GivenInformarEConfirmarASenha()
        {
            var senha = $"@{_faker.Internet.Password(8)}";

            var element = _driver.FindElement(By.XPath("//*[@id=\"Senha\"]"));
            element.SendKeys(senha);

            element = _driver.FindElement(By.XPath("//*[@id=\"SenhaConfirmacao\"]"));
            element.SendKeys(senha);
        }

        [When(@"Solicitar a realização do cadastro")]
        public void WhenSolicitarARealizacaoDoCadastro()
        {
            var element = _driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[5]/input"));
            element.Click();
        }

        [Then(@"Sistema informa que usuário foi cadastrado com sucesso")]
        public void ThenSistemaInformaQueOUsuarioFoiCadastradoComSucesso()
        {
            var element = _driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div/strong"));
            element.Text
                .Should()
                .Be("Usuário cadastrado com sucesso.");

            TestHelper.CreateScreeShot(_driver, $"UsuarioCadastradoComSucesso{DateTime.Now.ToString("ddMMyyyyhhmmss")}");

            _driver.Close();
        }

        [Given(@"Manter os campos com valor vazio")]
        public void GivenManterOsCamposComValorVazio()
        {
            var element = _driver.FindElement(By.XPath("//*[@id=\"Nome\"]"));
            element.Clear();

            element = _driver.FindElement(By.XPath("//*[@id=\"Email\"]"));
            element.Clear();

            element = _driver.FindElement(By.XPath("//*[@id=\"Senha\"]"));
            element.Clear();

            element = _driver.FindElement(By.XPath("//*[@id=\"SenhaConfirmacao\"]"));
            element.Clear();
        }

        [Then(@"Sistema informa que todos os campos são obrigatórios")]
        public void ThenSistemaInformaQueTodosOsCamposSaoObrigatorios()
        {
            var element = _driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[1]/span/span"));
            element.Text.Should().Be("Nome é obrigatório.");

            element = _driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[2]/span/span"));
            element.Text.Should().Be("Email é obrigatório.");

            element = _driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[3]/span/span"));
            element.Text.Should().Be("Senha é obrigatório.");

            element = _driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[4]/span/span"));
            element.Text.Should().Be("Confirmação de senha é obrigatório.");

            TestHelper.CreateScreeShot(_driver, $"ValidacaoDeCamposObrigatorios{DateTime.Now.ToString("ddMMyyyyhhmmss")}");

            _driver.Close();
        }

    }
}



