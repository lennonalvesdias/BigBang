# FROM microsoft/aspnetcore:2.0
# WORKDIR /app
# EXPOSE 5000/tcp
# COPY . .
# RUN dotnet restore
# ENTRYPOINT ["dotnet", "run"]

# FROM microsoft/aspnetcore-build:2.0 AS build-env
# WORKDIR /app

# # Copy csproj and restore as distinct layers
# # COPY *.csproj ./
# # RUN dotnet restore

# # Copy everything else and build
# COPY . ./
# WORKDIR /Aplicacao/
# RUN dotnet publish -c Release -o out

# # Build runtime image
# FROM microsoft/aspnetcore:2.0
# WORKDIR /app
# COPY --from=build-env /app/out .
# ENTRYPOINT ["dotnet", "BigBang.WebApi.dll"]

# FROM microsoft/aspnetcore-build:lts
# COPY . /app
# WORKDIR /app
# RUN ["dotnet", "restore"]
# RUN ["dotnet", "build"]
# EXPOSE 5000/tcp
# RUN chmod +x ./entrypoint.sh
# CMD /bin/bash ./entrypoint.sh

FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
COPY . ./
WORKDIR /Aplicacao/1 - Servicos/BigBang.WebApi/
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]

FROM build AS publish
RUN dotnet publish -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BigBang.WebApi.dll"]