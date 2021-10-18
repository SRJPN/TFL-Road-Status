# RoadStatus

## Description

This repo is a coding challenge provided by TFL. More details about the challenge is provided [here](Challenge.md)

## Setup

This project is build on [.Net core 5](https://dotnet.microsoft.com/download/dotnet/5.0). The dotnet cli is used to create new projects. [Visual Studio Code](https://code.visualstudio.com/) has been used as IDE. It has been used for running and debugging the project.

To run the application, there need a AppId and DeveloperKey from TFL developer portal. To generate those, register yourself with https://api-portal.tfl.gov.uk/ and create new subscription. The name of the subscription serves as AppId and the key as DeveloperKey.

Once you generate the AppId and Developer Key, you can replace the [appsettings.json](src/RoadStatus/appsettings.json) with the new values.

## Usage

### Restore
The project uses dotnet cli for build.

``` shell
$ dotnet restore
```

### Build
The project uses dotnet cli for build.

``` shell
$ dotnet build
```

### Publish
The project uses dotnet cli for publish.

``` shell
$ dotnet publish
```

### Test
To run the tests in the project 
``` shell
$ dotnet test
```

To run the tests with coverage
``` shell
$ rm -r test/RoadStatus.Test/TestResults && dotnet test --collect:"Xplat Code Coverage" && reportgenerator -reports:"../**/coverage.cobertura.xml" -targetdir:"./CoverageReport" -reporttypes:"html"
```

### Run
To run the project 
``` shell
$ dotnet run --project src/RoadStatus <road-id>
```