FROM microsoft/aspnetcore:2.0
RUN mkdir /app
WORKDIR /app
COPY publish/ /app/
EXPOSE 5000/tcp
ENTRYPOINT dotnet /app/BigBang.WebApi.dll