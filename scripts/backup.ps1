$name = "backups/$(Get-Date -Format "yyyyMMdd_HHmmss").zip"

New-Item -Path "../backups" -ItemType Directory -Force 
mongodump /host:localhost /port:27017 /db:SkiService /dumpDbUsersAndRoles /archive:"../${name}" /username:superadmin /password:"superadmin" /authenticationDatabase:admin /gzip

if (!$?) {
    mongodump /host:localhost /port:27017 /db:SkiService /dumpDbUsersAndRoles /archive:"../${name}" /gzip
}

if ($?) {
    Write-Host "Backup created at ${name} inside the Root of the project."
    Read-Host
}
else {
    Write-Host "An Error occured. Ensure a MongoDB instance is running and and a superadmin user exists. with the password 'superadmin'."
    Read-Host
}
