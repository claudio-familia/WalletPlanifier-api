#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["WalletPlanifier/WalletPlanifier.csproj", "WalletPlanifier/"]
COPY ["WalletPlanifier.Common/WalletPlanifier.Common.csproj", "WalletPlanifier.Common/"]
COPY ["WalletPlanifier.DataAccess/WalletPlanifier.DataAccess.csproj", "WalletPlanifier.DataAccess/"]
COPY ["WalletPlanifier.Domain/WalletPlanifier.Domain.csproj", "WalletPlanifier.Domain/"]
COPY ["WalletPlanifier.BusinessLogic/WalletPlanifier.BusinessLogic.csproj", "WalletPlanifier.BusinessLogic/"]
RUN dotnet restore "WalletPlanifier/WalletPlanifier.csproj"
COPY . .
WORKDIR "/src/WalletPlanifier"
RUN dotnet build "WalletPlanifier.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WalletPlanifier.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet WalletPlanifier.dll