if (-not ([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)) {
    Start-Process powershell.exe "-File `"$PSCommandPath`"" -Verb RunAs
    exit
}


$TriggerTime = New-ScheduledTaskTrigger -Daily -At 2am
$ScriptPath = Join-Path $PSScriptRoot "backup.ps1"
$Action = New-ScheduledTaskAction -Execute "Powershell.exe" -Argument "-File `"$ScriptPath`""

Register-ScheduledTask -TaskName "DailyBackupTask" -Description "Führt das tägliche Backup für MongoDB aus" -Trigger $TriggerTime -Action $Action -RunLevel Highest -User "SYSTEM"

Read-Host