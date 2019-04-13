# StockBoard

What is the StockBoard Project?
=====================
this is an app for CRUD operations sample using .NET Core, DDD, CQRS pattern, layered architecture ,SignalR and Angular7 front end

## How to run these porject
to run these project, simply open the solution file you have to open by VS2017 and .Net Core SDK v2.2
then urn Update-Database in StockBoard.Service.Api project and you have to start both projects StockBoard.Function.Simulator and SimpleBlog.Services.Api
it will run the api in this port
 ```sh
https://localhost:44342
```
and to run front end app  navigate to 
 ```sh
src/GuiApp/Stock-Board-App
```

and run  
```sh
npm install 
ng serve -o
```

it will run the UI in this port
 ```sh
https://localhost:4200
```


also you can try the documentaion of api throw swagger 
 ```sh
https://localhost:44342/swagger
```
 and the UI web for add a new record and see the  notification after adding a post will run in this post 
 then you have to go to 
 ```sh
http://localhost:4200
```
finally, for real-time notification test, you can open the web UI into two different browser tabs
