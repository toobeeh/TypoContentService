#!/bin/bash
set -e
sed -i "s!GRPC_VALMAR_URL_SED_PLACEHOLDER!$GRPC_VALMAR_URL!g" /app/appsettings.json
sed -i "s!GIT_REPOSITORY_URL_SED_PLACEHOLDER!$GITHUB_REPO_URL!g" /app/appsettings.json
sed -i "s!GIT_ACCESS_TOKEN_SED_PLACEHOLDER!$GITHUB_TOKEN!g" /app/appsettings.json

# Start the main process
exec "$@"