# creara la base de datos
```
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=s3cr3t!P455w0rd" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
```

```
dotnet tool install --global dotnet-ef
dotnet ef database update
```

# actualizador de base de datos


# elastic
```
docker run -p 9200:9200 -p 9300:9300 -e "discovery.type=single-node" docker.elastic.co/elasticsearch/elasticsearch:7.5.2
```