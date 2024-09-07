FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY SplitProject.sln ./

COPY *.csproj ./

COPY SplitProject/API.csproj ./SplitProject/

RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app

COPY --from=build /app/out .

EXPOSE 80

ENTRYPOINT ["dotnet", "api.exe"]