$backupFiles = Get-ChildItem -Path "../backups" -Filter "*.zip"

$selectedBackup = $backupFiles | Out-GridView -Title "Wählen Sie ein Backup zur Wiederherstellung" -OutputMode Single

if ($null -ne $selectedBackup) {
    mongorestore /host:localhost /port:27017 /archive:"../backups/$selectedBackup" /drop /db:SkiService /username:superadmin /password:"superadmin" /authenticationDatabase:admin /restoreDbUsersAndRoles /gzip
    if (!$?) {
        mongorestore /host:localhost /port:27017 /archive:"../backups/$selectedBackup" /drop /db:SkiService /restoreDbUsersAndRoles /gzip
    }
}

if ($?) {
    Write-Host "Backup restored."
    Read-Host
}
else {
    Write-Host "An Error occured. Ensure a MongoDB instance is running and and a superadmin user exists. with the password 'superadmin'."
    Read-Host
}