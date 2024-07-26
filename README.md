# Gestão de Cliente

## Visão Geral

Esta aplicação tem como objetivo principal demonstrar meus conhecimentos de backend e frontend em ASP.NET. Desenvolvi este projeto utilizando a arquitetura MVC disponibilizada pelo próprio template ASP.NET MVC, além de realizar uma separação de responsabilidades. Esta aplicação consiste em três projetos: CustomerManager.Core, CustomerManager.Infrastructure e CustomerManager.Web.

### CustomerManger.Core

Este é uma biblioteca de classes (classlib) que tem como objetivo principal isolar os modelos e regras de negócios. Para que isso aconteça, a interação entre eles é realizada através de abstrações, como interfaces ou classes abstratas. Neste núcleo, não implementamos o banco de dados diretamente; resolvemos isso através do Repository Pattern, onde abstraímos as funcionalidades de banco em interfaces que serão implementadas pela camada de infraestrutura.

### CustomerManger.Infrastructre
Esta é uma biblioteca de classes que tem como objetivo principal implementar as operações de banco de dados. É dentro desta camada que implementamos os repositórios e também outras integrações, caso seja necessário.


### CustomerManager.Web

Esta é uma aplicação MVC, que tem como objetivo principal permitir a interação do sistema com o usuário que irá operá-lo.


### Conclusão

Nestes três projetos, aplico de forma simples, porém objetiva e eficaz, meus conhecimentos de backend e frontend com ASP.NET MVC, SOLID, um pouco de Clean Architecture, Separação de Responsabilidades, Repository Pattern e Observer Pattern.

## Como rodar esta Aplicação

Para rodar esta aplicação, é preciso ter instalado o .NET 8 SDK e o docker.

### Subindo banco de dados

Primeiramente devemos rodar o docker para que o banco de dados esteja disponivel no momento que a aplicação for executada

1. Acesse o diretorio do projeto
```~$ cd  customer-manager-dotnetcore```

2. Na raiz do projeto temos tres aquivos importantes: 
   - dockerfile
   - docker-compse.yml
   - scripts.sql

3. No terminal devemos digitar o seguinte comando:
   ```~/customer-manager-dotnetcore$ sudo docker compose up -d```

4. Checar se o container está configurado:
   ```~/customer-manager-dotnetcore$ sudo docker ps```

5. Na lista de containers ativos identificar por:
   ```customer-manager-dotnetcore-sql-server```

### Rodando a aplicação

A connectionstring já está configurado no appsettings da aplicação MVC, basta agora somente rodar a aplica digitando o seguint comando:
```~/customer-manager-dotnetcore$  dotnet run --project src/CustomerManger.Web``` 



# Dados do Projeto

- **Sistema Operacional:** Windiows/Linux/MacOs\
- **Banco de dados:** SQL Server 2029
- **Container Plataforms:** Docker
- **Framework:** .NET 8 Core SDK
  


