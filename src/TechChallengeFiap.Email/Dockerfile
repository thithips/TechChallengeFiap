FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8082
EXPOSE 8083

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/TechChallengeFiap.Email/TechChallengeFiap.Email.csproj", "src/TechChallengeFiap.Email/"]
COPY ["src/TechChallengeFiap.Core/TechChallengeFiap.Core.csproj", "src/TechChallengeFiap.Core/"]
RUN dotnet restore "src/TechChallengeFiap.Email/TechChallengeFiap.Email.csproj"
COPY . .
WORKDIR /src/src/TechChallengeFiap.Email
RUN dotnet build "TechChallengeFiap.Email.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TechChallengeFiap.Email.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TechChallengeFiap.Email.dll"]