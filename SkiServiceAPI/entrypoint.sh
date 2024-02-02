#!/bin/bash

# Check if initialization flag file exists
if [ ! -f /flags/initialized ]; then
    pwsh /scripts/initialize.ps1 -Uri "mongodb://mongodb:27017"
    # Create the initialization flag file
    touch /flags/initialized
fi

# Start the dotnet application
exec "$@"