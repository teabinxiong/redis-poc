# Project Summary

## Repository URL
[redis-poc](https://github.com/teabinxiong/redis-poc/)

## Steps
1. Install and run the Redis service using the Redis Docker image.
```properties
docker run -d --name redis-stack -p 6379:6379 -p 8001:8001 redis/redis-stack:latest
```

2. Update the Redis connection string inside the appsettings.json file.
3. Run the command <code>dotnet run</code> in your project folder to run the project.
