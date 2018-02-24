FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
COPY ./ ./
WORKDIR /Aplicacao/1 - Servicos/BigBang.WebApi/
RUN dotnet restore
RUN dotnet build

FROM build AS publish
RUN dotnet publish -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BigBang.WebApi.dll"]