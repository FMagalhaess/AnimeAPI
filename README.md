
# 📺 AnimeAPI

## 🚀 Visão Geral

**AnimeAPI** é uma API RESTful desenvolvida com **ASP.NET Core** que permite o gerenciamento de informações sobre animes, como título, diretor e resumo. 

Projetada com os princípios da **Clean Architecture** e **Domain-Driven Design (DDD)**, esta aplicação demonstra uma estrutura modular, testável e de fácil manutenção, utilizando:

- **MediatR** para orquestração de comandos e queries
- **Entity Framework Core** para persistência de dados
- **Swagger/OpenAPI** para documentação da API

---

## ✨ Funcionalidades

- ✅ **Criação de Animes:** Adicione novos animes com título, diretor e resumo  
- 📄 **Listagem de Animes:** Recupere todos os animes com suporte a paginação  
- 🔍 **Busca de Animes:** Busque por título ou diretor  
- 🔎 **Detalhes do Anime:** Obtenha informações detalhadas via ID  
- ♻️ **Atualização de Animes:** Atualize dados existentes  
- ❌ **Exclusão de Animes:** Remova animes da base de dados  
- 📦 **Versionamento de API:** Suporte a múltiplas versões (V1.0 implementada)  
- 🐳 **Dockerização:** Ambiente conteinerizado para facilitar execução e deploy  

---

## 🛠️ Tecnologias Utilizadas

- **ASP.NET Core**
- **.NET 9**
- **MediatR**
- **Entity Framework Core**
- **SQL Server**
- **Docker & Docker Compose**
- **Swagger / OpenAPI**
- **xUnit**

---

## 📦 Estrutura do Projeto (Clean Architecture)

```
AnimeAPI/
│
├── AnimeAPI.API              → Camada de Apresentação (Controllers, DTOs, Configs)
├── AnimeAPI.Application      → Casos de uso (Commands, Queries, Handlers)
├── AnimeAPI.Domain.Entities  → Entidades e VOs (Regra de Negócio)
├── AnimeAPI.Domain.Shared    → Contratos, Interfaces e objetos compartilhados
└── AnimeAPI.Infrastructure   → Acesso a dados (DbContext, Migrations, Repositórios)
```

---

## 🚀 Como Rodar o Projeto

### ✅ Pré-requisitos

- Docker Desktop (ou Docker Engine)
- .NET SDK 9 *(se for executar fora do Docker ou usar EF CLI)*
- Git

### 🔧 Passos para Execução

#### 1. Clone o Repositório

```bash
git clone https://github.com/FMagalhaess/AnimeAPI.git
cd AnimeAPI
```

#### 2. Configure o Banco de Dados (Docker Compose)

Verifique se as portas 1433, 5104 e 5105 estão livres.

#### 3. Construa e Suba os Contêineres

```bash
docker compose up --build -d
```

#### 4. Aplique as Migrações do EF Core

```bash
docker ps  # Pegue o CONTAINER ID da sua API

docker exec -it [CONTAINER_ID_DA_SUA_API] dotnet ef database update \
  --project AnimeAPI.Infrastructure \
  --startup-project AnimeAPI.API
```


## 🌐 Endpoints Principais

### Swagger (Interface Web)

- http://localhost:5104/swagger

### Exemplos:

#### 📥 Criar Anime (POST)

```http
POST /api/v1.0/Animes
Content-Type: application/json
```

```json
{
  "nameTitle": "Attack on Titan",
  "directorName": "Tetsurō Araki",
  "summaryText": "A humanidade se esconde atrás de muralhas para se proteger de gigantes devoradores de homens."
}
```

#### 📃 Listar Animes (GET)

```http
GET /api/v1.0/Animes?pageNumber=1&pageSize=5
```

#### 🔎 Buscar por Título/Diretor (GET)

```http
GET /api/v1.0/Animes/search?name=titan&director=araki
```

#### 🧾 Detalhar por ID (GET)

```http
GET /api/v1.0/Animes/{id}
```

#### ✏️ Atualizar Anime (PUT)

```http
PUT /api/v1.0/Animes/{id}
Content-Type: application/json
```

```json
{
  "nameTitle": "Attack on Titan: The Final Season",
  "directorName": "Yuichiro Hayashi",
  "summaryText": "Eren Jaeger continua sua jornada para o destino do mundo."
}
```

#### ❌ Deletar Anime (DELETE)

```http
DELETE /api/v1.0/Animes/{id}
```

---

## 🛑 Como Parar o Projeto

### Parar contêineres:

```bash
docker compose down
```

### Parar e remover volumes (inclui dados do banco):

```bash
docker compose down -v
```

---

## 🤝 Contribuição

Contribuições são bem-vindas! Sinta-se livre para abrir *issues*, *pull requests* ou sugerir melhorias.

1. Fork este repositório  
2. Crie uma branch (`git checkout -b feature/MinhaFuncionalidade`)  
3. Commit suas mudanças (`git commit -m 'feat: Adiciona nova funcionalidade'`)  
4. Push para a branch (`git push origin feature/MinhaFuncionalidade`)  
5. Abra um Pull Request

---


## 📧 Contato

**Filipe Silva Magalhães**  
📫 Email: 7filipe093@gmail.com  
🔗 [LinkedIn](https://www.linkedin.com/in/filipemagalhaesdev/)  
🐙 [GitHub](https://github.com/FMagalhaess)
