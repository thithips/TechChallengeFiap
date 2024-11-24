FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/TechChallengeFiap.Application/TechChallengeFiap.Application.csproj", "/src/services/TechChallengeFiap.Application/"]
COPY ["src/TechChallengeFiap.Core/TechChallengeFiap.Core.csproj", "/src/services/TechChallengeFiap.Core/"]
COPY ["src/TechChallengeFiap.Domain/TechChallengeFiap.Domain.csproj", "/src/services/TechChallengeFiap.Domain/"]
COPY ["src/TechChallengeFiap.Infrastructure/TechChallengeFiap.Infrastructure.csproj", "/src/services/TechChallengeFiap.Infrastructure/"]
COPY ["src/TechChallengeFiap.Services/TechChallengeFiap.Services.csproj", "/src/services/TechChallengeFiap.Services/"]
RUN dotnet restore "/src/services/TechChallengeFiap.Application/TechChallengeFiap.Application.csproj"
COPY . ./
WORKDIR "/src/services/TechChallengeFiap.Application"
RUN dotnet build "TechChallengeFiap.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TechChallengeFiap.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TechChallengeFiap.Application.dll"]

#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#USER app
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["TechChallengeFiap.Application.csproj", "."]
#RUN dotnet restore "TechChallengeFiap.Application.csproj"
#COPY . .
#WORKDIR "/src/."
#RUN dotnet build "TechChallengeFiap.Application.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
#FROM build as publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "TechChallengeFiap.Application.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#ENV ASPNETCORE_URLS="http://+:8080"
#ENV ASPNETCORE_ENVIRONMENT="Development"
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "TechChallengeFiap.Application.dll"]