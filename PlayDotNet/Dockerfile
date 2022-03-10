FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PlayDotNet/PlayDotNet.csproj", "PlayDotNet/"]
RUN dotnet restore "PlayDotNet/PlayDotNet.csproj"
COPY . .
WORKDIR "/src/PlayDotNet"
RUN dotnet build "PlayDotNet.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PlayDotNet.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PlayDotNet.dll"]
