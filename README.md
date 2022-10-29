# Ef Core Migrations

Utilização de Migrations do EF Core para criação e versionamento de alterações do banco de dados.

## 1 Requisitos

Primeiramente, você precisa instalar a ferramenta `dotnet-ef` através do comando abaixo:

```bash
dotnet tool install --global dotnet-ef
```

## 2 Containers

Esta aplicação utiliza dois containers Docker, sendo que um contém uma instância do banco de dados PostgreSQL e o outro o pgAdmin.

### Inicialização dos containers

Inicialize os containers, acessando o diretório Docker/ef-migrations e executando o comando abaixo:

```bash
docker-compose up -d
```

### 2.2 Acesso ao pgAdmin

Acesse o pgAdmin através do endereço [http://localhost:16543/](http://localhost:16543/), informando o usuário `postgres@pgadmin.com.br` e a senha `pgadmin@123`.

### 2.3 Registro do servidor do PostgreSQL no pgAdmin

Registre a instância do banco de dados no pgAdmin com os seguintes dados:
- **Hostname/address:** efcore-migrations-postgres-1
- **Port:** 5432
- **Maintenance database:** postgres
- **Username:** postgres
- **Password:** postgres@123

## 3 Criação do banco de dados e tabelas

Aqui iremos executar comandos para criação do banco de dados e tabelas através do Migrations do EF Core.

### 3.1 Banco de dados e tabela __EFMigrationsHistory

Execute o comando abaixo para a criação do banco de dados e a tabela __EFMigrationsHistory, que faz o controle do versionamento de alterações do banco de dados.

```bash
dotnet ef database update
```

### 3.2 Geração da migration de criação das tabelas

Execute o comando abaixo para realizar a geração do arquivo de migration para criação das tabelas mapeadas no EF Core.

```bash
dotnet ef migrations add InitialCreate
```

### 3.3 Aplicação da migration

Execute o comando abaixo para realizar a aplicar, no banco de dados, as migrations criadas.

```bash
dotnet ef database update
```

Após isso, verifique no pgAdmin que as tabelas mapeadas no EF Core foram criadas no banco de dados.