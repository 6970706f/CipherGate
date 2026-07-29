# CipherGate

CipherGate é uma aplicação web para gerenciamento de conexões SSH. O sistema permite cadastrar servidores, autenticar usuários e estabelecer sessões SSH diretamente pelo navegador utilizando SignalR como canal de comunicação em tempo real.

A aplicação implementa autenticação baseada em JWT e gerenciamento de conexões SSH por usuário. Cada usuário pode cadastrar seus próprios servidores, iniciar sessões SSH diretamente pelo navegador e manter múltiplos terminais ativos simultaneamente. Todas as conexões e configurações são isoladas por usuário, impedindo o acesso a recursos pertencentes a outras contas.

A modelagem do sistema é composta por um Diagrama de Classes, responsável por representar a estrutura do domínio, e por um Modelo Entidade-Relacionamento, utilizado para definir a organização do banco de dados.

<table align="center">
  <tr>
    <td align="center">
      <img src="docs/images/class-diagram.png" width="700">
    </td>
    <td align="center">
      <img src="docs/images/database-diagram.png" width="470">
    </td>
  </tr>
</table>

O backend foi desenvolvido em ASP.NET Core utilizando C#. O acesso aos dados é realizado com Entity Framework Core, a comunicação em tempo real utiliza SignalR e as conexões SSH são estabelecidas através da biblioteca SSH.NET. A persistência é feita em MariaDB e toda a infraestrutura é executada em containers Docker orquestrados pelo Docker Compose.

Para executar o projeto:

```bash
git clone https://github.com/SEU_USUARIO/CipherGate.git
cd CipherGate
docker compose up -d
```

Após a inicialização, a aplicação estará disponível em:

```text
http://localhost:8080
```

Para encerrar os serviços:

```bash
docker compose down
```

O projeto foi desenvolvido com o objetivo de aprofundar conhecimentos em Clean Architecture, Domain-Driven Design (DDD), ASP.NET Core, Entity Framework Core, SignalR, protocolo SSH, Docker, MariaDB e arquitetura de software.

O projeto encontra-se em desenvolvimento.