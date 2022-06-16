#!/bin/bash
docker build -t weather-api -f src/JbWebApi/Dockerfile .
docker build -t ping-api-1 -f src/PingApi1/Dockerfile .
docker build -t ping-api-2 -f src/PingApi2/Dockerfile .
docker-compose up
