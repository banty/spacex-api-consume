FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /source

COPY SpaceX/SpaceX.Api/SpaceX.Api.csproj  SpaceX/SpaceX.Api/
COPY SpaceX/SpaceX.Domain/SpaceX.Domain.csproj  SpaceX/SpaceX.Domain/
COPY SpaceX/SpaceX.Applicaiton/SpaceX.Applicaiton.csproj  SpaceX/SpaceX.Applicaiton/
COPY SpaceX/SpaceX.Infrastructure/SpaceX.Infrastructure.csproj  SpaceX/SpaceX.Infrastructure/
COPY SpaceX/SpaceX.sln SpaceX/Spacex.sln

RUN  dotnet restore SpaceX/SpaceX.Api/SpaceX.Api.csproj

COPY . .

WORKDIR /source/SpaceX/SpaceX.Api/
RUN dotnet publish -c Release -o /published

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as publish
WORKDIR /app

COPY --from=build /published .

EXPOSE 80
EXPOSE 443

ENV ASPNET_URLS http://*:80
ENTRYPOINT ["dotnet","SpaceX.Api.dll"]