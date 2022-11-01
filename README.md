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

### Deployment

1. Run *Articles.API* microservice **locally**
- Run :
```
docker start articles-mongo
```
- In *appsettings.Development.json*, set : "ConnectionString" : "mongodb://localhost:27017"
- Hit **Articles.API**

<img src="/pictures/article_swagger.png" title="article swagger"  width="800">

2. Run *Articles.API* microservice **containerized**
- In *appsettings.Development.json*, set : "ConnectionString" : "mongodb://articlemongodb:27017"
- Hit **Docker Compose**

3. Run *Articles.API* microservice **docker compose**
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

### Deployment

1. Run *Users.API* microservice **locally**
- Run :
```
docker start users-mongo
```
- In *appsettings.Development.json*, set : "ConnectionString" : "mongodb://localhost:27017"
- Hit **Users.API**
- go to *Users.API* : http://localhost:5501/swagger/index.html

2. Run *Users.API* microservice **containerized**
- In *appsettings.Development.json*, set : "ConnectionString" : "mongodb://usermongodb:27017"
- Hit **Docker Compose** or run :
```
docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml down
docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d
```
- go to *Users.API* : http://localhost:8500/swagger/index.html

<img src="/pictures/user_swagger.png" title="user swagger"  width="800">




## Inventory.API with Redis

### Packages

1. Package Manager Command in **Inventory.API**
```
Install-Package Microsoft.Extensions.Caching.StackExchangeRedis 
Update-Package -ProjectName Inventory.API
```

2. Redis database
```
docker pull redis
docker run -d -p 6379:6379 --name inventory-redis redis
docker logs -f inventory-redis
docker exec -it inventory-redis /bin/bash
redis-cli
set key value
get key
```

### Deployment

1. Run *Users.API* microservice **locally**
- Run :
```
docker start inventory-redis
```
- In *appsettings.Development.json*, set : "ConnectionString" : "localhost:6379"
- Hit **Inventory.API**

2. Run *Inventory.API* microservice **containerized**
- In *appsettings.Development.json*, set : "ConnectionString" : "inventorydb:6379"
- Hit **Docker Compose** or run :
```
docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml down
docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d
```
- go to *Inventory.API* : http://localhost:8001/swagger/index.html

<img src="/pictures/inventory.png" title="inventory local"  width="800">




## Portainer

- run : docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d
- go to : http://localhost:9000
- Create a user

<img src="/pictures/portainer.png" title="portainer"  width="800">




## Transport.API with Redis

### Packages

1. Package Manager Command in **Transport.API**
```
Install-Package Microsoft.Extensions.Caching.StackExchangeRedis 
Update-Package -ProjectName Transport.API
```

2. Redis database
```
docker pull redis
docker run -d -p 6380:6379 --name transport-redis redis
docker logs -f transport-redis
docker exec -it transport-redis /bin/bash
redis-cli
set key value
get key
```

### Deployment

1. Run *Users.API* microservice **locally**
- Run :
```
docker start transport-redis
```
- In *appsettings.Development.json*, set : "ConnectionString" : "localhost:6379"
- Hit **Transport.API**

2. Run *Transport.API* microservice **containerized**
- In *appsettings.Development.json*, set : "ConnectionString" : "transportdb:6379"
- Hit **Docker Compose** or run :
```
docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml down
docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d
```
- go to *Transport.API* : http://localhost:8501/swagger/index.html

<img src="/pictures/transport.png" title="transport local"  width="800">


