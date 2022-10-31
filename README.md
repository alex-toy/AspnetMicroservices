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
- Run all commands from *mongo_articles.txt*

3. Run *Articles.API* microservice **locally**
- Run :
```
docker start articles-mongo
```
- In *appsettings.Development.json*, set : "ConnectionString" : "mongodb://localhost:27017"
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




## Users.API with MongoDb

### Packages

1. Package Manager Command in **Users.API**
```
Install-Package MongoDB.Driver 
Install-Package MongoDB.Bson 
```

2. Mongo database

- Go in *Developper Powershell* and run :
```
docker pull mongo
docker run -d -p 27018:27017 --name users-mongo mongo
docker logs -f users-mongo
docker exec -it users-mongo mongosh
```
- Run all commands from *mongo_users.txt*

3. Run *Users.API* microservice **locally**
- Run :
```
docker start users-mongo
```
- In *appsettings.Development.json*, set : "ConnectionString" : "mongodb://localhost:27017"
- Hit **Users.API**
- go to *Users.API* : http://localhost:5501/swagger/index.html

4. Run *Users.API* microservice **containerized**
- In *appsettings.Development.json*, set : "ConnectionString" : "mongodb://usermongodb:27017"
- Hit **Docker Compose**

5. Run *Users.API* microservice **docker compose**
```
docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml down
docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d
```
- go to *Users.API* : http://localhost:8500/swagger/index.html

<img src="/pictures/user_swagger.png" title="user swagger"  width="800">

