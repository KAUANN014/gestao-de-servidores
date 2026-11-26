
# Gestão de Servidores

Aplicação Full Stack para cadastro, consulta, edição e exclusão de registros de servidores, com dados de órgãos e lotações.

## Tecnologias

- **Frontend:** Angular 19, TypeScript, Angular Material, RxJS
- **Backend:** ASP.NET Core 8, C#, Entity Framework Core
- **Banco de dados:** MySQL
- **Documentação da API:** Swagger / OpenAPI

## Estrutura

```
frontend/   Aplicação web Angular
backend/    API ASP.NET Core e migrations do Entity Framework
```

## Executar localmente

### Backend

Pré-requisitos: .NET 8 SDK e MySQL instalado e acessível.

1. Crie um banco de dados chamado `gerenciamento` no MySQL.
2. Configure a conexão por variável de ambiente, sem salvar credenciais no repositório:

   **PowerShell**
   ```powershell
   $env:ConnectionStrings__DefaultConnection="Server=localhost;Database=gerenciamento;User=root;Password=SUA_SENHA;"
   ```

3. Execute:

   ```powershell
   cd backend
   dotnet restore
   dotnet run
   ```

A documentação Swagger é habilitada no ambiente de desenvolvimento. Consulte a URL informada no terminal.

### Frontend

Pré-requisitos: Node.js e npm.

```bash
cd frontend
npm install
npm start
```

A aplicação estará disponível em http://localhost:4200. A URL da API está definida em `frontend/src/app/environments/environments.ts`; ajuste-a para o endereço local da API se necessário.

## Funcionalidades

- Listagem e consulta de servidores
- Cadastro e edição de registros
- Exclusão de registros
- Consulta de órgãos e lotações
- Interface com Angular Material

## Observações

Este projeto é um trabalho de portfólio e está em evolução. Antes de executar, configure o banco de dados e a URL da API conforme o ambiente local.
