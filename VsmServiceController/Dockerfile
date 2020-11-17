FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY VsmServiceController/*.csproj ./VsmServiceController/
RUN dotnet restore

# copy everything else and build app
COPY VsmServiceController/. ./VsmServiceController/
WORKDIR /source/VsmServiceController
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "VsmServiceController.dll"]