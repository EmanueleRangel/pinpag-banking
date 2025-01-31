# FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
# WORKDIR /app
# EXPOSE 8080

# FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# WORKDIR /src
# COPY ["pinpag-banking.csproj", "./"]
# RUN dotnet restore "pinpag-banking/pinpag-banking.csproj"

# COPY . .
# WORKDIR "/src/pinpag-banking"
# RUN dotnet build -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish -c Release -o /app/publish

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "pinpag-banking.dll"]

FROM alpine:latest
WORKDIR /app
COPY . /app
RUN ls -R /app

