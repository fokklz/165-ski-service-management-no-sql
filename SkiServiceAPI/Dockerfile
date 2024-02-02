FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["./SkiServiceAPI/SkiServiceAPI.csproj", "./SkiServiceAPI/"]
RUN dotnet restore "./SkiServiceAPI/SkiServiceAPI.csproj"

COPY . .

RUN dotnet build "SkiServiceAPI/SkiServiceAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SkiServiceAPI/SkiServiceAPI.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=publish /app/publish .

RUN apt-get update && \
    apt-get install -y wget apt-transport-https software-properties-common && \
    wget -q "https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb" -O packages-microsoft-prod.deb && \
    dpkg -i packages-microsoft-prod.deb && \
    apt-get update && \
    apt-get install -y powershell

RUN wget -qO - https://www.mongodb.org/static/pgp/server-4.4.asc | apt-key add - && \
    echo "deb http://repo.mongodb.org/apt/ubuntu bionic/mongodb-org/4.4 multiverse" | tee /etc/apt/sources.list.d/mongodb-org-4.4.list && \
    apt-get update && \
    apt-get install -y mongodb-mongosh

COPY scripts /scripts
COPY SkiServiceAPI/entrypoint.sh /

RUN chmod +x /entrypoint.sh

RUN mkdir /flags

ENTRYPOINT [ "/entrypoint.sh" ]

CMD ["dotnet", "SkiServiceAPI.dll"]