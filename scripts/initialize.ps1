$hasError = $False;

Write-Host "Cleanup starting..."

mongosh --file ./mongosh/cleanup.js --username superadmin --password superadmin --authenticationDatabase admin | Out-Null

if (!$?) {
    Write-Host "No superadmin user found. Trying to cleanup without authentication."
    mongosh --file ./mongosh/cleanup.js | Out-Null

    if (!$?) {
        $hasError = $True;
    }
}

Write-Host "Initializing... this may take a while."

Get-ChildItem -Path "./mongosh/collections" -Filter "*.js" | ForEach-Object {
    Write-Host "creating collection $($_.Name) with schema"
    & mongosh --file "./mongosh/collections/$($_.Name)" | Out-Null
    
    if (!$?) {
        script::$hasError = $True;
    }
}

& mongosh --file ./mongosh/indexes.js | Out-Null

if (!$?) {
    $hasError = $True;
}

mongosh --file ./mongosh/create-dml-and-superadmin.js | Out-Null

if (!$?) {
    $hasError = $True;
}

if ($hasError) {
    Write-Host "An Error occured. Ensure a MongoDB instance is running and and a superadmin user exists. with the password 'superadmin'."
    Read-Host
}
