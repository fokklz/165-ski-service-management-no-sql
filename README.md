# SkiService Backend - NoSQL <!-- omit in toc -->

The SkiService Backend project leverages a robust NoSQL database architecture to streamline ski service management. It delivers a scalable and efficient backend system designed to handle various operational needs, including order management, user interactions, service tracking, and overall service state monitoring.

## Contents <!-- omit in toc -->

- [Installation Requirements](#installation-requirements)
  - [Dockerized Setup](#dockerized-setup)
  - [Non-Dockerized Setup](#non-dockerized-setup)
- [Installation](#installation)
  - [Dockerized](#dockerized)
  - [Non-Dockerized](#non-dockerized)
- [Technology Stack](#technology-stack)
- [Postman Tests](#postman-tests)
- [Backup \& Restore](#backup--restore)
  - [Backup](#backup)
  - [Restore](#restore)
- [Extra](#extra)
  - [Adding to PATH](#adding-to-path)

## Installation Requirements

### Dockerized Setup

- **Docker**
- **Docker Compose**

### Non-Dockerized Setup

- **MongoDB**
- **.NET 8**
- **Powershell**
- **Visual Studio 2022**

## Installation

### Dockerized

For dockerized project deployment, open a Powershell terminal at the project's root directory and execute:

```bash
docker-compose up -d --build
```

This command builds the project and starts the container in the background. Access the application at `http://localhost:8000` and the database at `mongodb://localhost:17017`. The development environment enables Swagger UI access at `http://localhost:8000/swagger`. In this mode, the application reveals raw exception data instead of user-friendly error messages.

Database initialization occurs at container start-up, controlled by a specific flag. To reset the database, delete the `initialized` flag file in the `.docker/flags` directory.

### Non-Dockerized

For non-dockerized setup, initial database configuration is required. In the `scripts` directory, execute:

**CAUTION:** This will erase all existing data linked to the `SkiService` database and `DMLUser`. Ensure you backup any important data before proceeding.

If your `mongod.cfg` includes authentication, ensure a `superadmin` user exists with the password `superadmin`.

```bash
.\initialize.ps1
```

Alternatively, right-click the file and choose `Run with Powershell` on newer Windows versions.

This script sets up the `SkiService` database and a `DMLUser` with `verySecurePassword`, using `admin` for authentication. A `superadmin` user with `superadmin` password is also created for database administration.

To secure the database, enable authentication in `mongod.cfg` by adding:

```yaml
security:
  authorization: enabled
```

Restart the database for these changes to take effect.

After setup, open `165-ski-service-management-no-sql.sln` in Visual Studio 2022 and launch the project. The application will open in the default browser at the Swagger page.

## Technology Stack

- **Framework:** ASP.NET Core
- **Database:** MongoDB
- **Logging:** Serilog with Redis Sink
- **Containerization:** Docker and Docker Compose for streamlined deployment and scaling
- **Authentication & Authorization:** JWT for secure API access

## Postman Tests

Import `SkiService-Management.postman_collection.json` from the `files` directory into Postman to run API functionality tests. The collection is pre-configured for docker environments (ensure Docker is running).

Right-click the collection and select `Run Collection` to begin testing, with a recommended delay of at least 200ms between requests to prevent collisions.

## Backup & Restore

Scripts are available for easy database backup and restoration. Ensure MongoDB tools are installed and accessible via your `PATH`.

### Backup

In the `scripts` directory, execute:

```bash
.\backup.ps1

# For Docker, use:
.\backup.docker.ps1
```

A backup archive will be created in the `backups` directory.

### Restore

To restore from a backup. In the `scripts` directory, execute:

```bash
.\restore.ps1

# For Docker, use:
.\restore.docker.ps1
```

A dialog will prompt you to select a backup file for restoration, overwriting existing data.

## Extra

### Adding to PATH

To add a tool to the `PATH` on Windows:

1. Open Start and search for `environment variables`.
2. Click `Edit the system environment variables`.
3. Select `Environment Variables...`.
4. Find `Path` under `System variables`, select it, then click `Edit...`.
5. Click `New` and type the path to the tool's installation directory.
6. Apply the changes by clicking `OK` on all dialogs
