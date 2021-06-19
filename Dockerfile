#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["IdentitySerrver4/IdentitySerrver4.csproj", "IdentitySerrver4/"]
RUN dotnet restore "IdentitySerrver4/IdentitySerrver4.csproj"
COPY . .
WORKDIR "/src/IdentitySerrver4"
RUN dotnet build "IdentitySerrver4.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentitySerrver4.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdentitySerrver4.dll"]