# GamesManager  
This repository contains my distributed system's course work which is basically a asp.net crud project for managing games that is divided into a MVC website and a RESTful api. It has a bearer token based authentication.  

It consists of three entities - Games, Makes and Kinds. Each game has a maker and a specific kind, but each maker/kind can belong to as many games as you want.

## Prerequisites  
*Step One - registering a user*   
In order to test the authentication first off you need to register a user. To do that navigate to localhost/api/account/register and POST a request to this URI and the pay load for this request has to contain the JSON object as below:  

````
{
  "username": "yourDesiredUsername",  
  "password": "yourDesiredPassword",  
  "confirmPassword": "yourDesiredPassword"  
}
````  

and assuming that you've registered "yourDesiredUsername" you need to generate yourself a token. To do that you can use Postman and go to the address of the api and hit the /token end point with the following details : 
  
*Step Two - getting authentication token:*  
````
Request uri - http://localhost:someNumber/token  
Method type - POST  
Headers - Accept: application-json, Content-Type: application/x-www-form-urlencoded  
Body - { "grant_type": "password", "username": "yourDesiredUsername", "password": "yourDesiredPassword" }    
````  
and you will receive as a response your own token which you need to copy.

*Step Three - adding bearer token example:*
````
Request uri - http://localhost:someNumber/api/games/getall
Method type - GET
Headers - Authorization: Bearer and paste it here. 
```` 

*(It should look something like this: Cq5L_M_53x4Yca1iUHL45WXyPUbaxNLxyjbEXwOALke5j6kD6-Es0YsgghgK0EwIkaj1O4R1nXLvnkJEqRdaorc48uvhPGUD-TVFit1RyegXZtaDUX4dBMNjQv1A3oPSeMQHKrGZZYwCiflsEn9Mb8vgXCSglAagTt6mJwIHBcx3xuTiwsRh4vtTCBeKhMvypylM6I27Rmcql-Bepz5hS1h37DM5D46oX220rurhAQw)
