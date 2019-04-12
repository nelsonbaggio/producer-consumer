FROM microsoft/dotnet:2.2-sdk
WORKDIR /app

ENV BROKER_HOST_NAME=localhost

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Debug -o out
ENTRYPOINT ["dotnet", "out/Producer.dll"]
