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
    $nameWithoutExtension = [System.IO.Path]::GetFileNameWithoutExtension($_.Name)
    Write-Host "creating collection $nameWithoutExtension with schema"
    & mongosh --file "./mongosh/collections/$($_.Name)" | Out-Null
    
    if (!$?) {
        $script:hasError = $True;
    }
}

mongosh --file ./mongosh/indexes.js | Out-Null

Get-ChildItem -Path "./mongosh/migration" -Filter "*.js" | ForEach-Object {
    $nameWithoutExtension = [System.IO.Path]::GetFileNameWithoutExtension($_.Name)
    Write-Host "processing migration $nameWithoutExtension"
    & mongosh --file "./mongosh/migration/$($_.Name)" | Out-Null

    if (!$?) {
        $script:hasError = $True;
    }
}

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