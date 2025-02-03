FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY ["pinpag_banking.csproj", "./"]
RUN dotnet restore "pinpag_banking.csproj"

COPY . /app/

# Copia os arquivos para /app
RUN dotnet build "pinpag_banking.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "pinpag_banking.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "pinpag_banking.dll"]
