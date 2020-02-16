# publisher-docker


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
$ docker build -t my_worker .
```

## Docker - Start docker from an docker image

```bash
$ docker run my_publisher_api 
```

## Docker - ELimnating stopped containers

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