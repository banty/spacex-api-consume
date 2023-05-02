
1. Backend
To run the backend 
  1. Using visual studio
  1.1 using visual studio open the solution 
  1.2 make sure SpaceX.Api is startup project
  1.3 run the project
  2. Using terminal
  2.1 open command or terminal
  2.2 navigate to SpaceX.Api project folder
  2.3  run the follwoing command
        dotnet run
2. Backend
  To run frontend
  1. navigate to spacex-front
  2. run the follwoing command
      npm run dev
      
 1. The frontend project consumes API both from spacex
       https://api.spacexdata.com/v3/launches
     and the local .net core API
       http://localhost:5028
 **
Containerization:

* Docker file is included in the API project
