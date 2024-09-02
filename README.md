# Api_Eventos

---

## Sumário

1. [Descrição do Projeto](#descrição-do-projeto)
2. [Tecnologias Utilizadas](#tecnologias-utilizadas)
3. [Como Executar](#como-executar)
4. [Documentação da API](#documentação-da-api)

## Descrição do Projeto

Este projeto é uma API para gerenciamento de eventos e participantes. 
Utiliza ASP.NET Core para construção de APIs RESTful e Entity Framework 
Core para interação com o banco de dados MySQL. A API suporta operações 
CRUD (Criar, Ler, Atualizar e Excluir) para administradores, eventos e 
participantes. Além disso, a API possui autenticação baseada em JWT para 
segurança e Swagger para documentação da API.

## Tecnologias Utilizadas

### [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet)

- Framework para construção de aplicações web e APIs com suporte para 
desenvolvimento rápido e fácil manutenção.

### [Entity Framework Core](https://docs.microsoft.com/ef/core/)

- ORM para interagir com o banco de dados MySQL de forma eficiente e sem a 
necessidade de escrever consultas SQL diretamente.

### [Swagger](https://swagger.io/)

- Ferramenta para documentação da API, permitindo explorar e testar 
endpoints diretamente da interface Swagger UI.

### [MySQL](https://www.mysql.com/)

- Sistema de gerenciamento de banco de dados relacional utilizado para 
armazenar os dados da aplicação.

### [JWT Bearer Authentication](https://docs.microsoft.com/aspnet/core/security/authentication/jwt-bearer)

- Mecanismo de autenticação utilizado para proteger endpoints da API, 
garantindo que apenas usuários autenticados possam acessar certas 
funcionalidades.

## Como Executar

### Requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) (versão recomendada: 6.0 ou superior)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/) (ou um ambiente de banco de dados compatível)

### Configuração do Banco de Dados

1. Crie um banco de dados MySQL chamado `ApiEventosBD`.
2. Atualize a string de conexão no arquivo `appsettings.json`:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;DataBase=ApiEventosBD;Uid=root;Pwd=@marelO50"
   }
   ```

### Executando a Aplicação

1. Clone o repositório:

   ```bash
   git clone "https://github.com/billygrahan/Api_Eventos.git"
   ```

2. Navegue até o diretório do projeto:

   ```bash
   cd <DIRETORIO_DO_PROJETO>
   ```

3. Restaure as dependências:

   ```bash
   dotnet restore
   ```

4. Execute o projeto:

   ```bash
   dotnet run
   ```

5. Acesse a API através dos seguintes URLs:
   - **HTTP:** [http://localhost:5127](http://localhost:5127)
   - **HTTPS:** [https://localhost:7067](https://localhost:7067)
   - **Swagger UI:** [http://localhost:5127/swagger](http://localhost:5127/swagger)

## Documentação da API

A documentação da API está disponível na interface Swagger UI após iniciar 
o projeto. Você pode testar os endpoints e visualizar a documentação 
interativa diretamente no navegador.

Para informações detalhadas sobre os endpoints, consulte a seção [Swagger UI](#swagger-ui) do projeto.

---