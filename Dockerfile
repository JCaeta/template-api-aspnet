FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["template-api-aspnet.csproj", "."]
RUN dotnet restore "./template-api-aspnet.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "template-api-aspnet.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "template-api-aspnet.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "template-api-aspnet.dll"]
