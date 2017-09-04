# CoreCoursesSample
A sample ASP.Net Core 2.0 project, with Postgresql DB and unit tests setup

To run it..

Make sure you have .Net 2.0 installed (http://dot.net).

The code currently is setup to connect to a local docker instance of Postgresql, so assuming you have docker installed..

    cd CoreCoursesSample.WebApi
    docker-compose -f docker-compose.dev.yml up

will start the database

then create and migrate the database

    dotnet ef database update

## To run tests

    cd CoreCoursesSample.Tests
    dotnet restore
    dotnet test

## To run Api sample

    cd CoreCoursesSample.WebApi
    dotnet restore
    dotnet run
