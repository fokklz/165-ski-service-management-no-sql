# SkiService Backend - NoSQL <!-- omit in toc -->

## Contents <!-- omit in toc -->

- [Installation](#installation)
  - [Finalizing the installation](#finalizing-the-installation)
- [Backup \& Restore](#backup--restore)
  - [Backup](#backup)
  - [Restore](#restore)
- [Extra](#extra)
  - [Adding to PATH](#adding-to-path)

## Installation

To run the project mongodb the Database will need some initial setup.
Open a Powershell terminal in the `scripts` directory of the project and run the following command:

**CAUTION:** This will delete all existing data in the database! In the admin Database the users or roles named by the reserved names `DMLUser`, `superadmin` or `DMLRole` will be overwritten if changed.

```bash
.\initialize.ps1
```

or right click on the file and select `Run with Powershell` if you are on a newer Windows version.

This script will create a database called `SkiService` and a user called `DMLUser` with the password `verySecurePassword` which will be used by the application to access the database. `admin` will be used as authentication database. Also a `superadmin` will be created with the password `superadmin` which can be used to administer the database.

The database will be initialized with empty collections that contain a defined schema. The schemas can be found in the `mongosh/collections` directory of the project inside the `scripts` directory.

### Finalizing the installation

To fully secure your database ensure to enable authentication in the `mongod.cfg` file by adding the following lines:

```yaml
security:
  authorization: enabled
```

Tbe database will have to be restarted for the changes to take effect.

## Backup & Restore

to simplify the creation of a Backup or Restore there are scripts in place which can be used to create a backup of the database.

To run any of these scripts ensure that you have the mongodb tools installed ([Tutorial](https://www.mongodb.com/docs/database-tools/installation/installation-windows/)) and that the folder is added to your `PATH` variable.

### Backup

open a Powershell terminal in the `scripts` directory of the project and run the following command:

```bash
.\backup.ps1
```

or right click on the file and select `Run with Powershell` if you are on a newer Windows version.

This will create a backup archived in a zip file in the `backups` directory of the project.

### Restore

open a Powershell terminal in the `scripts` directory of the project and run the following command:

```bash
.\restore.ps1
```

or right click on the file and select `Run with Powershell` if you are on a newer Windows version.

This will open a dialog allowing you to select a backup file to restore. After selecting the file the script will restore the backup to the database, existing data will be overwritten.

## Extra

### Adding to PATH

To include any Tool in your `PATH` environment variable on Windows, follow these instructions (ensure to link the folder containing the .exe files):

1. Open the Start menu and search for `environment variables`.
2. Select `Edit the system environment variables`.
3. Choose `Environment Variables...`.
4. In the `System variables` section, locate and select the `Path` variable, then click `Edit...`.
5. Press `New` and enter the path to your Tool installation directory.
6. Confirm your changes by clicking `OK` on all open windows.