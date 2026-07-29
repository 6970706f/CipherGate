# CipherGate

CipherGate is a web application for SSH connection management. The system allows users to register servers, authenticate, and establish SSH sessions directly from the browser using SignalR as the real-time communication channel.

The application implements JWT-based authentication and per-user SSH connection management. Each user can register their own servers, start SSH sessions directly from the browser, and maintain multiple active terminal sessions simultaneously. All connections and configurations are isolated per user, preventing access to resources belonging to other accounts.

The system design consists of a Class Diagram, which represents the domain structure, and an Entity-Relationship Diagram (ERD), which defines the database schema.

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

The backend was developed with ASP.NET Core using C#. Data access is handled through Entity Framework Core, real-time communication is powered by SignalR, and SSH connections are established using the SSH.NET library. Data persistence is provided by MariaDB, and the entire infrastructure runs in Docker containers orchestrated with Docker Compose.

To run the project:

```bash
git clone https://github.com/YOUR_USERNAME/CipherGate.git
cd CipherGate
docker compose up -d
```

Once the application has started, it will be available at:

```text
http://localhost:8080
```

To stop the services:

```bash
docker compose down
```

This project was developed to deepen knowledge of Clean Architecture, Domain-Driven Design (DDD), ASP.NET Core, Entity Framework Core, SignalR, the SSH protocol, Docker, MariaDB, and software architecture.

The project is currently under development.