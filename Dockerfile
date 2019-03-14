FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out
EXPOSE 5000
EXPOSE 8080
# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
ENV ASPNETCORE_URLS http://+:80
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "GraphQLNetCore.dll"]