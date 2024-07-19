# Hotels-API

Uma API RESTful para gestão completa de hotéis, desenvolvida com ASP.NET Core.

## Recursos

- **Gerenciamento de Recursos**: Operações completas de CRUD (Criar, Ler, Atualizar, Deletar) para hotéis, quartos, reservas, usuários e preços.
- **Design RESTful**: Adere aos princípios RESTful, utilizando métodos HTTP padrão (GET, POST, PUT, DELETE) e URLs baseadas em recursos.
- **Versionamento da API**: Suporta múltiplas versões da API para atualizações contínuas e compatibilidade retroativa.
- **Injeção de Dependências**: Utiliza injeção de dependências para uma arquitetura limpa e manutenível.
- **Filtragem**: Permite a filtragem de quartos pelo ID do hotel associado.
- **Registro (Logging)**: Registro embutido para monitoramento e depuração.
- **Integração com Swagger**: Documentação da API disponível através da Swagger UI.


## Stack Tecnológico

- **ASP.NET Core**
- **Entity Framework Core** 

## Começando

### Clonar o Repositório

git clone https://github.com/AdrielProg/hotels-api-asp.net

## Configurar o Banco de Dados

A instância do PostgreSQL está configurada no Railway e a conexão é gerenciada automaticamente. Portanto, não é necessário configurar a string de conexão no arquivo `appsettings.json` ou executar migrações manualmente.

## Compilar e Executar
- dotnet build

- dotnet run

acesse a documentação da aplicação pelo:

 localhost:porta/swagger/index.html

## Executando o Projeto com IIS Express

O IIS Express é uma versão leve e autossuficiente do IIS, otimizada para desenvolvedores. Para rodar o projeto usando IIS Express, siga estas etapas:

### Abra o Projeto no Visual Studio:

Abra o arquivo de solução (.sln) no Visual Studio.


### Execute o Projeto:

Clique no botão Run (ou pressione `F5`). Certifique-se de que o IIS Express está selecionado no dropdown de execução/debug.

O Visual Studio iniciará o IIS Express e executará sua aplicação. Por padrão, a aplicação estará disponível em:

- `http://localhost:64865` para HTTP
- `https://localhost:44341` para HTTPS


## Usando o Swagger

O Swagger está integrado ao projeto para fornecer documentação interativa da API. Uma vez que a aplicação esteja em execução, você pode acessar a interface do Swagger em:

http://localhost:porta/swagger


### utilize sempre a versão 1 para consultar a api via swagger 

