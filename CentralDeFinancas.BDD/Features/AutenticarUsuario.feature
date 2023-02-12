#language: pt
#encoding: ISO-8859-1

Funcionalidade: Autenticar Usuário
	Como um usuário cadastrado no sistema
	Eu quero acessar minha conta
	Para que possa gerenciar minhas finanças

Cenário: Autenticação de usuário com sucesso
	Dado Acessar a página de autenticação de usuário
	E Informar o e-mail de acesso "mattheustoscano@outlook.com"
	E Informar a senha de acesso "M@attheus123"
	Quando  Solicitar a realização do acesso
	Então Sistema autentica o usuário e exibe a página de Dashboard

Cenario: Acesso negado
	Dado Acessar a página de autenticação de usuário
	E Informar o e-mail de acesso "mattheustoscanoteste@outlook.com"
	E Informar a senha de acesso "M@attheus123"
	Quando  Solicitar a realização do acesso
	Então Sistema informa que o acesso é negado
