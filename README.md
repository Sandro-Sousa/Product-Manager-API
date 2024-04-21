# Projeto Product-Manager-API
## Criando uma API com Asp.NetCore Utilizando Padrão Fluent Api, Paginação e Metodologia DDD. 

## Tecnologias Usadas

- [.NET 6] - Framework da Microsoft Para Desenvolver Diversos Tipos de Projetos.
- [Entity Framework] - Framework Para Mapeamento de Dados Relacionais.
- [SQLServer] -Gerenciador de Banco de Dados Relacionais.
- [Swagger] - framework Para Interface de Uma APi Para, Documentar, Visualizar, Consumir APIRest.


# Como Utilizar

## Configurando String de Conexão
Para que o Projeto Utilize a base de Dados é nescessario Criar Uma String de Conexão dentro do Arquivo appsettings.json, Ele Geralemte Fica Localizado Na Pasta da API, Nesse Caso "Unimed.API" Nome do Arquivo:appsettings.json.
 Dentro do appsettings.json Modificar a connection string, Utilizando o Exemplo Abaixo:
 
  "ConnectionStrings": {
    "DefaultConnection": "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;"
  },

Caso Tenha Dúvida Consultar o Artigo sobre ConnectionString:
https://www.connectionstrings.com/sql-server/


### Criar Migração
```sh
Add-Migration Nome
```

### Criar tabelas do Bando de Dados:

```sh
Update-Database
```


