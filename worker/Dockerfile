FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Copy csproj and restore as distinct layers
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build
WORKDIR /src
COPY ./Worker/*.csproj ./Worker/
COPY ./UtilsLibrary/*.csproj ./UtilsLibrary/

RUN dotnet restore ./Worker 
RUN dotnet restore ./UtilsLibrary

# Copy everthing else and build
COPY . ./
RUN dotnet build ./Worker -c Release -o /app/build

FROM build AS publish
RUN dotnet publish ./Worker -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Worker.dll"]