param (
    [string]$Uri = "mongodb://localhost:27017"
)

$hasError = $False;
$hasAuth = $True;

Write-Host "Cleanup starting..."

mongosh --file "${PSScriptRoot}/mongosh/cleanup.js" --username superadmin --password superadmin --authenticationDatabase admin "$Uri" | Out-Null

if (!$?) {
    Write-Host "No superadmin user found. Trying to cleanup without authentication."
    mongosh --file "${PSScriptRoot}/mongosh/cleanup.js" "$Uri" | Out-Null
    $hasAuth = $False;

    if (!$?) {
        $hasError = $True;
    }
}

Write-Host "Initializing... this may take a while."

Get-ChildItem -Path "${PSScriptRoot}/mongosh/collections" -Filter "*.js" | ForEach-Object {
    $nameWithoutExtension = [System.IO.Path]::GetFileNameWithoutExtension($_.Name)
    Write-Host "creating collection $nameWithoutExtension with schema"
    if ($hasAuth) {
        & mongosh --file "${PSScriptRoot}/mongosh/collections/$($_.Name)" --username superadmin --password "superadmin" --authenticationDatabase admin "$Uri" | Out-Null
    }
    else {
        & mongosh --file "${PSScriptRoot}/mongosh/collections/$($_.Name)" "$Uri" | Out-Null
    }
    if (!$?) {
        $script:hasError = $True;
    }
}

if (!$?) {
    $hasError = $True;
}


if ($hasAuth) {
    mongosh --file "${PSScriptRoot}/mongosh/indexes.js" --username superadmin --password "superadmin" --authenticationDatabase admin "$Uri" | Out-Null
}
else {
    mongosh --file "${PSScriptRoot}/mongosh/indexes.js" "$Uri" | Out-Null
}


if (!$?) {
    $hasError = $True;
}


Get-ChildItem -Path "${PSScriptRoot}/mongosh/migration" -Filter "*.js" | ForEach-Object {
    $nameWithoutExtension = [System.IO.Path]::GetFileNameWithoutExtension($_.Name)
    Write-Host "processing migration $nameWithoutExtension"
    if ($hasAuth) {
        & mongosh --file "${PSScriptRoot}/mongosh/migration/$($_.Name)" --username superadmin --password "superadmin" --authenticationDatabase admin "$Uri" | Out-Null
    }
    else {
        & mongosh --file "${PSScriptRoot}/mongosh/migration/$($_.Name)" "$Uri" | Out-Null
    }

    if (!$?) {
        $script:hasError = $True;
    }
}

if (!$?) {
    $hasError = $True;
}

if ($hasAuth) {
    mongosh --file "${PSScriptRoot}/mongosh/create-dml-and-superadmin.js" --username superadmin --password "superadmin" --authenticationDatabase admin "$Uri" | Out-Null
}
else {
    mongosh --file "${PSScriptRoot}/mongosh/create-dml-and-superadmin.js" "$Uri" | Out-Null
}

if (!$?) {
    $hasError = $True;
}

if ($hasError) {
    Write-Host "An Error occured. Ensure a MongoDB instance is running and and a superadmin user exists. with the password 'superadmin'."
    Read-Host
}