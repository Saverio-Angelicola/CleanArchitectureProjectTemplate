#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Src/External/CleanArchitectureProjectTemplate.API/CleanArchitectureProjectTemplate.API.csproj", "Src/External/CleanArchitectureProjectTemplate.API/"]
COPY ["Src/Core/CleanArchitectureProjectTemplate.Application/CleanArchitectureProjectTemplate.Application.csproj", "Src/Core/CleanArchitectureProjectTemplate.Application/"]
COPY ["Src/Core/CleanArchitectureProjectTemplate.Domain/CleanArchitectureProjectTemplate.Domain.csproj", "Src/Core/CleanArchitectureProjectTemplate.Domain/"]
COPY ["Src/External/CleanArchitectureProjectTemplate.Infrastructure/CleanArchitectureProjectTemplate.Infrastructure.csproj", "Src/External/CleanArchitectureProjectTemplate.Infrastructure/"]
RUN dotnet restore "Src/External/CleanArchitectureProjectTemplate.API/CleanArchitectureProjectTemplate.API.csproj"
COPY . .
WORKDIR "/src/Src/External/CleanArchitectureProjectTemplate.API"
RUN dotnet build "CleanArchitectureProjectTemplate.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CleanArchitectureProjectTemplate.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanArchitectureProjectTemplate.API.dll"]