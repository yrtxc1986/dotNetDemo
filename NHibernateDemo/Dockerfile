FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["NHibernateDemo/NHibernateDemo.csproj", "NHibernateDemo/"]
RUN dotnet restore "NHibernateDemo/NHibernateDemo.csproj"
COPY . .
WORKDIR "/src/NHibernateDemo"
RUN dotnet build "NHibernateDemo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NHibernateDemo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NHibernateDemo.dll"]