#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["N5TLTest/N5TLTest.csproj", "N5TLTest/"]
RUN dotnet restore "N5TLTest/N5TLTest.csproj"
COPY . .
WORKDIR "/src/N5TLTest"
RUN dotnet build "N5TLTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "N5TLTest.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "N5TLTest.dll"]