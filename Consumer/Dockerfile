FROM microsoft/dotnet:2.2-sdk
WORKDIR /app

ENV BROKER_HOST_NAME=localhost
ENV MONGODB_CONNECTION_STRING=mongodb://127.0.0.1:27017

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Debug -o out
ENTRYPOINT ["dotnet", "out/Consumer.dll"]
