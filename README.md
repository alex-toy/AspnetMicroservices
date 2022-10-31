# Asp.Net Microservices

## Docker general commands

    - stop all containers :     docker stop $(docker ps -aq)
    - remove all containers :   docker rm $(docker ps -aq)
    - remove all images :       docker rmi $(docker images -q)
    - in case it was up :       docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml down


## Articles.API with MongoDb

### Packages

1. Package Manager Command in **Articles.API**
```
Install-Package MongoDB.Driver 
Install-Package MongoDB.Bson 
```

2. Mongo database

- Go in *Developper Powershell* and run :
```
docker pull mongo
docker run -d -p 27017:27017 --name articles-mongo mongo
docker logs -f articles-mongo
docker exec -it articles-mongo mongosh
```
- Run all commands from *mongo_commands.txt*

3. Run *Articles.API* microservice **locally**
- In *appsettings.json*, set : "ConnectionString" : "mongodb://localhost:27017"
- Run : docker start articles-mongo
- Hit **Articles.API**

<img src="/pictures/article_swagger.png" title="article swagger"  width="800">

4. Run *Articles.API* microservice **containerized**
- In *appsettings.Development.json*, set : "ConnectionString" : "mongodb://articlemongodb:27017"
- Hit **Docker Compose**

5. Run *Articles.API* microservice **docker compose**
```
docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml down
docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d
```
- go to *Articles.API* : http://localhost:8000/swagger/index.html

<img src="/pictures/article_swagger_docker.png" title="article swagger_docker"  width="800">

