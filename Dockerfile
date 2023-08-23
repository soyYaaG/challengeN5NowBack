FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
EXPOSE 81

COPY . .
RUN dotnet restore

RUN dotnet publish Permission.Api/Permission.Api.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
COPY --from=build-env /out .
EXPOSE 81
ENTRYPOINT ["dotnet", "Permission.Api.dll"]
