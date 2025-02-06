# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/Exam/Presentation/Exam.API/Exam.API.csproj", "src/Services/Exam/Presentation/Exam.API/"]
COPY ["src/Services/Exam/Core/Exam.Application/Exam.Application.csproj", "src/Services/Exam/Core/Exam.Application/"]
COPY ["src/Services/Exam/Core/Exam.Domain/Exam.Domain.csproj", "src/Services/Exam/Core/Exam.Domain/"]
COPY ["src/Services/Exam/Infrastructure/Exam.Persistence/Exam.Persistence.csproj", "src/Services/Exam/Infrastructure/Exam.Persistence/"]
RUN dotnet restore "./src/Services/Exam/Presentation/Exam.API/Exam.API.csproj"
COPY . .
WORKDIR "src/Services/Exam/Presentation/Exam.API"
RUN dotnet build "./Exam.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Exam.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Exam.API.dll"]