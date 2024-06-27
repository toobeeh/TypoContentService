FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app

# grpc
EXPOSE 8080 

ARG GRPC_VALMAR_URL="http://localhost:1234"
ENV GRPC_VALMAR_URL "${GRPC_VALMAR_URL}"

ARG GITHUB_REPO_URL="http://localhost/repo.git"
ENV GITHUB_REPO_URL "${GITHUB_REPO_URL}"

ARG GITHUB_TOKEN="123abc"
ENV GITHUB_TOKEN "${GITHUB_TOKEN}"

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["tobeh.TypoContentService.Server.csproj", "tobeh.TypoContentService.Server/"]
RUN dotnet restore "tobeh.TypoContentService.Server/tobeh.TypoContentService.Server.csproj"
COPY . ./tobeh.TypoContentService.Server
WORKDIR "/src/tobeh.TypoContentService.Server"
#RUN ls -lR
RUN dotnet build "tobeh.TypoContentService.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "tobeh.TypoContentService.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

USER root


RUN apt-get update \
    && apt-get install -y libfontconfig

# Copy the entrypoint script
COPY .docker/entrypoint.sh .
RUN chmod +x entrypoint.sh
USER $APP_UID

ENTRYPOINT ["/app/entrypoint.sh"]
CMD ["sh", "-c", "dotnet tobeh.TypoContentService.Server.dll"]