# SkiService Backend - NoSQL <!-- omit in toc -->

## Contents <!-- omit in toc -->

- [Installation](#installation)
- [Backup \& Restore](#backup--restore)
  - [Backup](#backup)
  - [Restore](#restore)

## Installation

To run the project mongodb the Database will need some initial setup.
Open a Powershell terminal in the `scripts` directory of the project and run the following command:

**CAUTION:** This will delete all existing data in the database! In the admin Database the users or roles named by the reserved names `DMLUser`, `superadmin` or `DMLRole` will be overwritten if changed.

```bash
.\initialize.sh
```

or right click on the file and select `Run with Powershell` if you are on a newer Windows version.

This script will create a database called `SkiService` and a user called `DMLUser` with the password `verySecurePassword` which will be used by the application to access the database. `admin` will be used as authentication database. Also a `superadmin` will be created with the password `superadmin` which can be used to administer the database.

The database will be initialized with empty collections that contain a defined schema. The schemas can be found in the `mongosh/collections` directory of the project inside the `scripts` directory.

## Backup & Restore

to simplify the creation of a Backup or Restore there are scripts in place which can be used to create a backup of the database.

To run any of these scripts ensure that you have the mongodb tools installed ([Tutorial](./tutorials/install-mongodb-tools.md)) and that the folder is added to your `PATH` variable.

### Backup

open a Powershell terminal in the `scripts` directory of the project and run the following command:

```bash
.\backup.sh
```

or right click on the file and select `Run with Powershell` if you are on a newer Windows version.

This will create a backup archived in a zip file in the `backups` directory of the project.

### Restore

open a Powershell terminal in the `scripts` directory of the project and run the following command:

```bash
.\restore.sh
```

or right click on the file and select `Run with Powershell` if you are on a newer Windows version.

This will open a dialog allowing you to select a backup file to restore. After selecting the file the script will restore the backup to the database, existing data will be overwritten.