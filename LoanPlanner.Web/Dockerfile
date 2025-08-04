FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["LoanPlanner.Web/LoanPlanner.Web.csproj", "LoanPlanner.Web/"]
COPY ["LoanPlanner.Core/LoanPlanner.Core.csproj", "LoanPlanner.Core/"]
RUN dotnet restore "./LoanPlanner.Web/LoanPlanner.Web.csproj"
COPY . .
WORKDIR "/src/LoanPlanner.Web"
RUN dotnet build "./LoanPlanner.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./LoanPlanner.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LoanPlanner.Web.dll"]