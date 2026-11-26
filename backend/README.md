
# Backend — Gestão de Servidores

API REST construída com ASP.NET Core 8 para gerenciar servidores, órgãos e lotações.

## Tecnologias

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core 8
- MySQL
- Swagger / OpenAPI

## Executar localmente

1. Instale o .NET 8 SDK e configure o MySQL.
2. Crie o banco `gerenciamento`.
3. Defina a connection string por variável de ambiente (PowerShell):

   ```powershell
   $env:ConnectionStrings__DefaultConnection="Server=localhost;Database=gerenciamento;User=root;Password=SUA_SENHA;"
   ```

4. Na pasta do backend:

   ```powershell
   dotnet restore
   dotnet run
   ```

O Swagger está habilitado no ambiente de desenvolvimento. A URL será exibida no terminal.

## Estrutura

- `Controllers/`: endpoints HTTP
- `DTOs/`: objetos de transferência de dados
- `Data/`: contexto do Entity Framework
- `Models/`: entidades
- `Repository/`: contratos e serviços
- `Migrations/`: histórico de migrações

Não coloque credenciais reais em arquivos versionados.
