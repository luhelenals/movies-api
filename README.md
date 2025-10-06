# 🎬 Movies API

![.NET](https://img.shields.io/badge/.NET-8-blueviolet)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-Web%20API-blue)
![SQLite](https://img.shields.io/badge/SQLite-3-blue)
![Swagger](https://img.shields.io/badge/Swagger-API%20Doc-green)

## 📄 Sobre o Projeto

Este projeto é uma API RESTful desenvolvida em ASP.NET Core para o gerenciamento completo de sessões e reservas de assentos em um cinema. A API permite consultar sessões disponíveis, verificar a ocupação de assentos em tempo real e realizar reservas, garantindo que um mesmo assento não seja reservado duas vezes para a mesma sessão.

## ✨ Funcionalidades

- **Gerenciamento de Entidades:** CRUD para Usuários, Salas, Sessões e Assentos.
- **Reservas:** Criação e gerenciamento de reservas, vinculando usuários, sessões e assentos.
- **Consulta de Ocupação:** Verificação da disponibilidade de assentos para sessões, retornando a contagem e os IDs dos assentos livres.
- **Validação de Negócio:** Impede a criação de reservas para assentos que já estão ocupados na sessão desejada e também da criação de sessões em salas já ocupadas naquele horário.
- **Documentação Interativa:** Interface Swagger UI para visualização e teste de todos os endpoints.

## 🛠️ Tecnologias Utilizadas

- **[Microsoft .NET 8](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)**: Framework principal para o desenvolvimento da aplicação.
- **[ASP.NET Core](https://dotnet.microsoft.com/pt-br/apps/aspnet)**: Para a construção da API RESTful.
- **[Entity Framework Core 9](https://learn.microsoft.com/pt-br/ef/core/)**: ORM para a comunicação com o banco de dados.
- **[SQLite](https://www.sqlite.org/index.html)**: Banco de dados relacional leve e baseado em arquivo.
- **[Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)**: Para a geração automática da documentação Swagger/OpenAPI.

## 🏛️ Arquitetura

A API foi projetada seguindo uma arquitetura em camadas para promover a separação de responsabilidades (SoC), testabilidade e manutenibilidade do código:

- **Controllers:** Camada de apresentação, responsável por receber as requisições HTTP e retornar as respostas.
- **Services:** Camada de negócio, onde a lógica da aplicação, validações e orquestração das operações são implementadas.
- **Repositories:** Camada de acesso a dados, que abstrai a comunicação com o banco de dados usando o padrão Repository.
- **Mappers:** Classes estáticas responsáveis por converter DTOs (Data Transfer Objects) para modelos de domínio e vice-versa.

## 🚀 Como Executar o Projeto

Siga os passos abaixo para executar a aplicação localmente.

### Pré-requisitos

- [.NET SDK 9](https://dotnet.microsoft.com/pt-br/download/dotnet/9.0) ou superior.
- Uma ferramenta de linha de comando (PowerShell, Command Prompt, Terminal).
- (Opcional) Uma ferramenta para testes de API, como o Postman ou o próprio Swagger.

### Instalação e Execução

1.  **Clone o repositório:**
    ```bash
    git clone https://github.com/luhelenals/movies-api.git
    cd movies-api
    ```

2.  **Instale as ferramentas do EF Core (se ainda não tiver):**
    ```bash
    dotnet tool install --global dotnet-ef
    ```

3.  **Crie o banco de dados e aplique as migrações:**
    O arquivo do banco de dados SQLite (`movies.db`) será criado na raiz do projeto.
    ```bash
    dotnet ef database update
    ```

4.  **Execute a aplicação:**
    ```bash
    dotnet run
    ```
    A API estará rodando em `http://localhost:5157`.

---
## 📖 Documentação da API

A documentação completa e interativa da API está disponível via Swagger UI. Após iniciar a aplicação, acesse:

**`localhost:5157/swagger`**

Lá você poderá ver todos os endpoints, seus parâmetros, schemas e testá-los diretamente.

### Exemplo de Endpoints

Confira a documentação Swagger para mais detalhes.

#### Reservas

- **`POST /api/reserva`**
  - Cria uma nova reserva.
  - Exemplo de Body:
    ```json
    {
      "assentos": [1, 2],
      "usuarioId": 1,
      "sessaoId": 1
    }
    ```

- **`GET /api/reserva/{id}`**
  - Retorna uma reserva específica.

#### Sessões

- **`GET /api/sessao`**
  - Retorna todas as sessões, incluindo a contagem e os IDs dos assentos disponíveis para cada uma.

- **`GET /api/sessao/{id}`**
  - Retorna uma sessão específica com detalhes sobre os assentos disponíveis.

- **`POST /api/sessao`**
  - Cria uma nova sessão de cinema.
  - Exemplo de Body:
    ```json
    {
      "filme": "O Poderoso Chefão",
      "horarioInicio": "2025-10-07T19:00:00",
      "horarioFim": "2025-10-07T22:00:00",
      "salaId": 1
    }
    ```

#### Usuários

- **`POST /api/usuario`**
  - Cria um novo usuário.
  - Exemplo de Body:
    ```json
    {
      "nome": "seu_nome"
    }
    ```