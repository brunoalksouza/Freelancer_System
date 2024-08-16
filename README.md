# Overview

The project aims to develop an online platform that connects freelancers with clients seeking specialized services, facilitating direct and efficient interaction between both parties. The platform will allow clients to post their needs, while freelancers can view these requests, submit proposals, or list their own services for hire.

The development will utilize modern technologies, employing C# for the backend and Vue.js for the frontend to create a robust foundation and a user-friendly interface. Initially, the focus will be on the web version, with plans to expand to mobile applications. The platform will start as a free service but will later include secure payment mechanisms to ensure reliable transactions.

With an innovative approach, the goal is to create a virtual environment that simplifies the negotiation of freelance services, benefiting both professionals and clients. The platform has the potential to become an essential resource in the market, promoting new job opportunities and facilitating access to specialized services.

## Conventional Commits

Conventional Commits are a specification for adding human and machine-readable meaning to commit messages. This project follows the Conventional Commits specification for standardizing commit messages.

| Type     | Emoji                 | Code                    |
|:---------|:----------------------|:------------------------|
| feat     | :sparkles:            | `:sparkles:`            |
| fix      | :bug:                 | `:bug:`                 |
| docs     | :books:               | `:books:`               |
| style    | :gem:                 | `:gem:`                 |
| refactor | :hammer:              | `:hammer:`              |
| perf     | :rocket:              | `:rocket:`              |
| test     | :rotating_light:      | `:rotating_light:`      |
| build    | :package:             | `:package:`             |
| ci       | :construction_worker: | `:construction_worker:` |
| chore    | :wrench:              | `:wrench:`              |

## Running the Project

### Technologies

| Technology    | Version   |
|:--------------|:----------|
| .NET SDK      | 8.0       |
| NodeJs        | 18.4.0    |
| NPM           | 8.12.1    |

### Installing Dependencies

**Frontend Dependencies:**
Navigate to the frontend directory and install dependencies:
```bash
cd /FrontEnd/vuejsfront/
npm install
```

**Backend Dependencies:**
If you are not using an IDE like Visual Studio or Rider, you will need to manually install dependencies using the terminal. First, list the projects in the solution:
```bash
dotnet sln list
```

For Linux users, navigate to the project source directory and run:
```bash
for project in $(dotnet sln list); do dotnet add $project package NomeDoPacote; done
```

For Windows users, it is recommended to use an IDE. However, if an IDE is not available, open the terminal, navigate to the project directory, and run:
```bash
dotnet sln list | ForEach-Object { dotnet add $_ package NomeDoPacote }
```

### Running the Application

**Frontend:**
To start the frontend development server:
```bash
cd /FrontEnd/vuejsfront/
npm run serve
```