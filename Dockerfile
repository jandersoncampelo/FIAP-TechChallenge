# Use the official .NET SDK image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Set the working directory in the container
WORKDIR /app

# Copy the project file(s) to the container
COPY *.csproj ./

# Restore the NuGet packages
RUN dotnet restore

# Copy the remaining source code to the container
COPY . ./

# Build the application
RUN dotnet build -c Release --no-restore

# Publish the application
RUN dotnet publish -c Release --no-build -o out

# Use the official .NET runtime image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime

# Set the working directory in the container
WORKDIR /app

# Copy the published output from the build stage to the runtime stage
COPY --from=build /app/out ./

# Expose the port that the API will listen on
EXPOSE 5000

# Set the entry point for the container
ENTRYPOINT ["dotnet", "YourApiName.dll"]
