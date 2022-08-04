FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
COPY . ./
WORKDIR /app/SalesApi
RUN dotnet restore
RUN dotnet build -c Release

FROM build AS publish
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=publish /app/SalesApi/out .
ENTRYPOINT ["dotnet", "SalesApi.dll"]