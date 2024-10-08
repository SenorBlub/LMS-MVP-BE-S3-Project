#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8090
EXPOSE 8091
ENV ASPNETCORE_URLS="http://+:8090;http://+:8091"
 
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["LMS-MVP-BE-S3-Project/Interaction.csproj", "LMS-MVP-BE-S3-Project/"]
COPY ["Core/Core.csproj", "Core/"]
COPY ["Data/Data.csproj", "Data/"]
RUN dotnet restore "./LMS-MVP-BE-S3-Project/Interaction.csproj"
COPY . .
WORKDIR "/src/LMS-MVP-BE-S3-Project"
RUN dotnet build "./Interaction.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Interaction.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Interaction.dll"]