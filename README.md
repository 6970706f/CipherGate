# CipherGate

![GitHub repo size](https://img.shields.io/github/repo-size/6970706f/CipherGate?style=for-the-badge)
![GitHub language count](https://img.shields.io/github/languages/count/6970706f/CipherGate?style=for-the-badge)
![GitHub top language](https://img.shields.io/github/languages/top/6970706f/CipherGate?style=for-the-badge)
![GitHub last commit](https://img.shields.io/github/last-commit/6970706f/CipherGate?style=for-the-badge)


> **CipherGate** é um sistema web para gerenciamento de conexões SSH. Permite cadastrar servidores, conectar-se via SSH diretamente pelo navegador e trabalhar com múltiplas abas de terminal em uma interface moderna e centralizada.

---

## 📸 Modelagem

### Diagrama de Classes

<p align="center">
    <img src="docs/images/class-diagram.png" width="900">
</p>

### Modelo Entidade-Relacionamento

<p align="center">
    <img src="docs/images/database-diagram.png" width="700">
</p>

---

## ✨ Funcionalidades

- Cadastro de usuários
- Autenticação via JWT
- Cadastro de servidores SSH
- Conexão SSH diretamente pelo navegador
- Múltiplas abas de terminal
- Gerenciamento individual de servidores
- Interface web responsiva

---

## 🛠️ Ajustes e melhorias

O projeto ainda está em desenvolvimento. As próximas versões serão voltadas para as seguintes funcionalidades:

- [ ] Modelagem do banco de dados
- [ ] Diagrama de classes
- [ ] Autenticação de usuários
- [ ] Cadastro de servidores
- [ ] Terminal SSH via navegador
- [ ] Múltiplas abas de terminal
- [ ] Criptografia das chaves SSH
- [ ] Histórico de conexões
- [ ] Compartilhamento de servidores
- [ ] Upload e download via SFTP
- [ ] Dashboard de monitoramento

---

## 💻 Tecnologias

### Backend

- ASP.NET Core
- C#
- Entity Framework Core
- SignalR
- SSH.NET

### Banco de Dados

- MariaDB

### Infraestrutura

- Docker
- Docker Compose

---

## 📂 Estrutura do Projeto

```text
CipherGate
│
├── src
│   ├── CipherGate.API
│   ├── CipherGate.Application
│   ├── CipherGate.Domain
│   └── CipherGate.Infrastructure
│
├── docs
│   └── images
│       ├── banner.png
│       ├── class-diagram.png
│       └── database-diagram.png
│
├── LICENSE
└── README.md
```

---

## 🚀 Executando o projeto

Clone o repositório:

```bash
git clone https://github.com/SEU_USUARIO/CipherGate.git
```

Entre na pasta do projeto:

```bash
cd CipherGate
```

Inicie todos os serviços:

```bash
docker compose up -d
```

A aplicação estará disponível em:

```text
http://localhost:8080
```

Para interromper os serviços:

```bash
docker compose down
```

### Execução rápida

```bash
git clone https://github.com/SEU_USUARIO/CipherGate.git && \
cd CipherGate && \
docker compose up -d
```

---

## 🎯 Objetivos do projeto

Este projeto foi desenvolvido com o objetivo de aprofundar conhecimentos em:

- Clean Architecture
- Domain-Driven Design (DDD)
- ASP.NET Core
- Entity Framework Core
- SignalR
- SSH
- Docker
- MariaDB
- Arquitetura de Software
