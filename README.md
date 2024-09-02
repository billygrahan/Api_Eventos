# Api_Eventos

---

## Sum�rio

1. [Descri��o do Projeto](#descri��o-do-projeto)
2. [Tecnologias Utilizadas](#tecnologias-utilizadas)
3. [Como Executar](#como-executar)
4. [Documenta��o da API](#documenta��o-da-api)

## Descri��o do Projeto

Este projeto � uma API para gerenciamento de eventos e participantes. 
Utiliza ASP.NET Core para constru��o de APIs RESTful e Entity Framework 
Core para intera��o com o banco de dados MySQL. A API suporta opera��es 
CRUD (Criar, Ler, Atualizar e Excluir) para administradores, eventos e 
participantes. Al�m disso, a API possui autentica��o baseada em JWT para 
seguran�a e Swagger para documenta��o da API.

## Tecnologias Utilizadas

### [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet)

- Framework para constru��o de aplica��es web e APIs com suporte para 
desenvolvimento r�pido e f�cil manuten��o.

### [Entity Framework Core](https://docs.microsoft.com/ef/core/)

- ORM para interagir com o banco de dados MySQL de forma eficiente e sem a 
necessidade de escrever consultas SQL diretamente.

### [Swagger](https://swagger.io/)

- Ferramenta para documenta��o da API, permitindo explorar e testar 
endpoints diretamente da interface Swagger UI.

### [MySQL](https://www.mysql.com/)

- Sistema de gerenciamento de banco de dados relacional utilizado para 
armazenar os dados da aplica��o.

### [JWT Bearer Authentication](https://docs.microsoft.com/aspnet/core/security/authentication/jwt-bearer)

- Mecanismo de autentica��o utilizado para proteger endpoints da API, 
garantindo que apenas usu�rios autenticados possam acessar certas 
funcionalidades.

## Como Executar

### Requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) (vers�o recomendada: 6.0 ou superior)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/) (ou um ambiente de banco de dados compat�vel)

### Configura��o do Banco de Dados

1. Crie um banco de dados MySQL chamado `ApiEventosBD`.
2. Atualize a string de conex�o no arquivo `appsettings.json`:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;DataBase=ApiEventosBD;Uid=root;Pwd=@marelO50"
   }
   ```

### Executando a Aplica��o

1. Clone o reposit�rio:

   ```bash
   git clone "https://github.com/billygrahan/Api_Eventos.git"
   ```

2. Navegue at� o diret�rio do projeto:

   ```bash
   cd <DIRETORIO_DO_PROJETO>
   ```

3. Restaure as depend�ncias:

   ```bash
   dotnet restore
   ```

4. Execute o projeto:

   ```bash
   dotnet run
   ```

5. Acesse a API atrav�s dos seguintes URLs:
   - **HTTP:** [http://localhost:5127](http://localhost:5127)
   - **HTTPS:** [https://localhost:7067](https://localhost:7067)
   - **Swagger UI:** [http://localhost:5127/swagger](http://localhost:5127/swagger)

## Documenta��o da API

A documenta��o da API est� dispon�vel na interface Swagger UI ap�s iniciar 
o projeto. Voc� pode testar os endpoints e visualizar a documenta��o 
interativa diretamente no navegador.

Para informa��es detalhadas sobre os endpoints, consulte a se��o [Swagger UI](#swagger-ui) do projeto.

---