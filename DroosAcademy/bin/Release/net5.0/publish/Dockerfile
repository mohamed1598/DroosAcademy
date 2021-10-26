#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
COPY . .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet DroosAcademy.dll
#EXPOSE 80
#
#FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
#WORKDIR /src
#COPY ["DroosAcademy/DroosAcademy.csproj", "DroosAcademy/"]
#RUN dotnet restore "DroosAcademy/DroosAcademy.csproj"
#COPY . .
#WORKDIR "/src/DroosAcademy"
#RUN dotnet build "DroosAcademy.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "DroosAcademy.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "DroosAcademy.dll"]