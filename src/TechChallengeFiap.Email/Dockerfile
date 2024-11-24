FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8082
EXPOSE 8083

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/TechChallengeFiap.Email/TechChallengeFiap.Email.csproj", "src/services/TechChallengeFiap.Email/"]
COPY ["src/TechChallengeFiap.Core/TechChallengeFiap.Core.csproj", "src/services/TechChallengeFiap.Core/"]
RUN dotnet restore "src/services/TechChallengeFiap.Email/TechChallengeFiap.Email.csproj"
COPY . .
WORKDIR "/src/services/TechChallengeFiap.Email/TechChallengeFiap.Email.csproj"
RUN dotnet build "TechChallengeFiap.Email.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TechChallengeFiap.Email.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TechChallengeFiap.Email.dll"]