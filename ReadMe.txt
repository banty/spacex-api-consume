
## Running back and frontend
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
2. Frontend
  To run frontend
  1. navigate to spacex-front
  2. npm install
  3. run the follwoing command
      npm run dev
##How to use the front end   
 1. The frontend project consumes API both from spacex
       https://api.spacexdata.com/v3/launches
     and the local .net core API
       http://localhost:5028/api/Launch
  2. At the top of the Home page you will be prsented with
     a selection
      2.1 Two buttons are provided that enables you to select either remote or local api.
      2.2 Two radio buttons are provided that enables yout to select past or upcoming flight.
      
      Therfore, depending on the combination of selection the list will be refreshed automatically
      
      Deatil Page:
      
      1. If you select remote api detail page will be shown based on the flight_number fetched from remote api
      2. If you select local api detail page will be shown based on the Id fetched from local api
      
      *** The data fetch from both api is cached automatically to improve performance
 ## Backend API features
 1. Unit test is written 
 2. Circuit breaker and retery pattrn is implmented to make it fault tollerent
 3. Clean architecture with CQRS pattern is used 

 
  
 **
Containerization:

* Docker file is included in the API project
