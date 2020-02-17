# publisher-docker

After pulling the project from github run:

```bash
$ dotnet core restore
```

Use VSCode, Visual Studio for Windows or MacOSX.

The docker containers, are linux containers, no Windows containers


## Swagger API documentation

browse
http://localhost:<port>/swagger

## Running Web service

```bash
$ dotnet run --project .\publisher_api\ 
```

# Starting docker compose

Execute at docker-compose.yml path, the next command in the terminal

```bash
$ docker-compose up --build 
$ docker-compose down
```

## Running the worker

```bash
$  dotnet run --project .\worker\
$  docker run my_worker
```

## Creating docker image from Dockerfile

```bash
$ docker build -t my_publisher_api .
$ docker build -f ./Dockerfile -t my_worker ..
```

## Docker - Start docker from an docker image

```bash
$ docker run my_publisher_api 
```

## Docker - Eliminating stopped containers

```bash
$ docker system prune
```

## Docker - Display all container && images

```bash
$ docker images ls
$ docker container ls
$ docker ps -a
$ docker rmi <image_id>
```
