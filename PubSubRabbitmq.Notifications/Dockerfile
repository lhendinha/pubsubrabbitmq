#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PubSubRabbitmq.Notifications/PubSubRabbitmq.Notifications.csproj", "PubSubRabbitmq.Notifications/"]
RUN dotnet restore "PubSubRabbitmq.Notifications/PubSubRabbitmq.Notifications.csproj"
COPY . .
WORKDIR "/src/PubSubRabbitmq.Notifications"
RUN dotnet build "PubSubRabbitmq.Notifications.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PubSubRabbitmq.Notifications.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PubSubRabbitmq.Notifications.dll"]
