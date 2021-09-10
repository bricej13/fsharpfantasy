FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["fsharpfantasy/fsharpfantasy.fsproj", "fsharpfantasy/"]
RUN dotnet restore "fsharpfantasy/fsharpfantasy.fsproj"
COPY . .
WORKDIR "/src/fsharpfantasy"
RUN dotnet build "fsharpfantasy.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "fsharpfantasy.fsproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "fsharpfantasy.dll"]
