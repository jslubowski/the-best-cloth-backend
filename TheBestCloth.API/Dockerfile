#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["TheBestCloth.API/TheBestCloth.API.csproj", "TheBestCloth.API/"]
COPY ["TheBestCloth.BLL/TheBestCloth.BLL.csproj", "TheBestCloth.BLL/"]
COPY ["TheBestCloth.DAL/TheBestCloth.DAL.csproj", "TheBestCloth.DAL/"]
RUN dotnet restore "TheBestCloth.API/TheBestCloth.API.csproj"
COPY . .
WORKDIR "/src/TheBestCloth.API"
RUN dotnet build "TheBestCloth.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TheBestCloth.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TheBestCloth.API.dll"]
