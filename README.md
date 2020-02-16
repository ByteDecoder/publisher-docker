# publisher-docker


## Running Web service

```bash
$ dotnet run --project .\publisher_api\ 
```

## Running the worker

```bash
$  dotnet run --project .\worker\
```

## Creating docker image from Dockerfile

```bash
$ docker build -t my_publisher_api .
```

## Docker - ELimnating stopped containers

```bash
$ docker system prune
```