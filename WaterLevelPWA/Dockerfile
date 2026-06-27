# Estágio base: Imagem de execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Estágio de build: Restaura e compila a solução
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia os arquivos de projeto individualmente para otimizar o cache de camadas
COPY ["WaterLevelPWA/WaterLevelPWA.csproj", "WaterLevelPWA/"]
COPY ["WaterLevelPWA.Client/WaterLevelPWA.Client.csproj", "WaterLevelPWA.Client/"]

# Restaura as dependências
RUN dotnet restore "WaterLevelPWA/WaterLevelPWA.csproj"

# Copia o restante dos arquivos fonte
COPY . .

# Faz o build do projeto Server (que referencia o Client)
WORKDIR "/src/WaterLevelPWA"
RUN dotnet build "WaterLevelPWA.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Estágio de publicação
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "WaterLevelPWA.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Estágio final: Imagem leve para rodar o app
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WaterLevelPWA.dll"]