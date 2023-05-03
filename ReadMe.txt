
## Running back and frontend

1.To run the backend 
  1. Using visual studio
      1.1 Using visual studio open the solution 
      1.2 Make sure SpaceX.Api is startup project
      1.3 Run the project
    2. Using terminal
      2.1 Open command or terminal
      2.2 Navigate to "SpaceX.Api" project folder
      2.3 Run the follwoing command
            dotnet run
2.To run frontend
  
  1. Navigate to directory "spacex-front"
  2. Install packages 
       npm install
  3. run using the follwoing command
      npm run dev
      
##How to use the front end   
 1. The frontend project consumes API both from spacex
       https://api.spacexdata.com/v3/launches
     and the local .net core API
       http://localhost:5028/api/Launch
  2. At the top of the Home page you will option to select (local/remote api) and (past/upcoming ) launches
    
      2.1 Two buttons are provided that enables you to select either remote or local api.
      2.2 Two radio buttons are provided that enables yout to select past or upcoming flight.
      
      Note: Depending on the combination of selection the list will be refreshed automatically
      
      Deatil Page:
      
      1. If you select remote api, then clik the link to see the detail that is fetched using "flight_number" from remote api
      2. If you select local api, then clik the link to see the detail that is fetched using "Id" from local api
      
      *** The data fetch from both api is cached automatically to improve performance
 ## Backend API features
 1. Unit test is written 
 2. Circuit breaker and retery pattrn is implmented to make it fault tollerent
 3. Clean architecture with CQRS pattern is used 
