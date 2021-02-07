# Use Microsoft's official .NET image.
# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build-env

# Copy the CSPROJ and restore any dependencies (via NUGET)
WORKDIR /app
COPY *.csproj .
RUN dotnet restore

# Copy the project files and build our release
COPY . ./
RUN dotnet publish -c Release -o out

# Generate runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal
WORKDIR /app
EXPOSE 8080
COPY --from=build-env /app/out/ .

# Make sure the app binds to port 8080
ENV ASPNETCORE_URLS http://*:8080
ENTRYPOINT [ "dotnet", "HelloApi.dll" ]

# How to Build Image:
# docker build -t cesar/hello-api -f Dockerfile .
# docker images

# How to run image:
# docker run --rm -d --name hello-api -p 8080:8080 cesar/hello-api:latest -e SIDERCAR_URL=http://localhost:8180/

# See logs
# docker logs --follow <imageId>