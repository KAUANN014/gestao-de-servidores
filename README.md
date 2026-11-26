# Gerenciamento de servidores — frontend

Aplicação frontend Angular para gerenciamento de registros de servidores. A estrutura contém telas para listagem, cadastro, edição e exclusão, além de serviço para comunicação com a API.

## Funcionalidades
- Listagem de servidores
- Cadastro de servidor
- Edição de registros
- Exclusão com confirmação
- Filtro na listagem
- Navegação entre telas

## Tecnologias
- Angular 19
- Angular Material / CDK
- TypeScript
- RxJS

## Como executar
```bash
npm install
npm start
```
Acesse http://localhost:4200.

## Build e testes
```bash
npm run build
npm test
```

## Backend
Este frontend consome uma API de gerenciamento de servidores. Verifique o endpoint configurado em `src/app/environments/` e a disponibilidade da API.

Repositório do frontend; backend mantido separadamente.