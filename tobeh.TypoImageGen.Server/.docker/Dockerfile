FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app

# grpc
EXPOSE 8080 

ARG GRPC_VALMAR_URL="http://localhost:1234"
ENV GRPC_VALMAR_URL "${GRPC_VALMAR_URL}"

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["tobeh.TypoImageGen.Server.csproj", "tobeh.TypoImageGen.Server/"]
RUN dotnet restore "tobeh.TypoImageGen.Server/tobeh.TypoImageGen.Server.csproj"
COPY . ./tobeh.TypoImageGen.Server
WORKDIR "/src/tobeh.TypoImageGen.Server"
#RUN ls -lR
RUN dotnet build "tobeh.TypoImageGen.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "tobeh.TypoImageGen.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Copy the entrypoint script
COPY .docker/entrypoint.sh .
USER root
RUN chmod +x entrypoint.sh
USER $APP_UID

ENTRYPOINT ["/app/entrypoint.sh"]
CMD ["sh", "-c", "dotnet tobeh.TypoImageGen.Server.dll"]