# Hotels-API

Uma API RESTful para gestão completa de hotéis, desenvolvida com ASP.NET Core.

## Recursos

- **Gerenciamento de Recursos**: Operações completas de CRUD (Criar, Ler, Atualizar, Deletar) para hotéis, quartos, reservas, usuários e preços.
- **Design RESTful**: Adere aos princípios RESTful, utilizando métodos HTTP padrão (GET, POST, PUT, DELETE) e URLs baseadas em recursos.
- **Versionamento da API**: Suporta múltiplas versões da API para atualizações contínuas e compatibilidade retroativa.
- **Injeção de Dependências**: Utiliza injeção de dependências para uma arquitetura limpa e manutenível.
- **Filtragem**: Permite a filtragem de quartos pelo ID do hotel associado.
- **Registro (Logging)**: Registro embutido para monitoramento e depuração.

## Stack Tecnológico

- **ASP.NET Core**
- **Entity Framework Core** 

## Começando

### Clonar o Repositório

git clone https://github.com/AdrielProg/hotels-api-asp.net

## Configurar o Banco de Dados

A instância do PostgreSQL está configurada no Railway e a conexão é gerenciada automaticamente. Portanto, não é necessário configurar a string de conexão no arquivo `appsettings.json` ou executar migrações manualmente.

## Compilar e Executar

```bash
dotnet build
dotnet run

