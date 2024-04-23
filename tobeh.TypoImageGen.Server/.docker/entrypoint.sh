#!/bin/bash
set -e
sed -i "s!GRPC_VALMAR_URL_SED_PLACEHOLDER!$GRPC_VALMAR_URL!g" /app/Configuration/appsettings.json

# Start the main process
exec "$@"