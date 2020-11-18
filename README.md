![Build and deploy ASP.Net Core app to Azure Web App](https://github.com/andersonnichele/Restaurant-Order-App/workflows/Build%20and%20deploy%20ASP.Net%20Core%20app%20to%20Azure%20Web%20App%20-%20restaurantorderapp/badge.svg?branch=main)

# Restaurant-Order-App

This is a simple app with an API + Tests

Rules:
1. You must enter time of day as “morning” or “night”
2. You must enter a comma delimited list of dish types with at least one selection
3. The output must print food in the following order: entrée, side, drink, dessert
4. There is no dessert for morning meals
5. Input is not case sensitive
6. If invalid selection is encountered, display valid selections up to the error, then print error
7. In the morning, you can order multiple cups of coffee
8. At night, you can have multiple orders of potatoes
9. Except for the above rules, you can only order 1 of each dish type

<strong>Dishes for Each time of day</strong>

Dish Type | morning | night
--- | --- | ---
1 (entrée) | eggs | steak
2 (side) | toast | potato
3 (drink) | coffee | wine
4 (dessert) | Not Applicable | cake

<strong>Sample Input and Output</strong>

Input | Output
--- | --- 
morning, 1, 2, 3 | eggs, toast, coffee
morning, 2, 1, 3 | eggs, toast, coffee
morning, 1, 2, 3, 4 | eggs, toast, coffee, error
morning, 1, 2, 3, 3, 3 | eggs, toast, coffee(x3)
night, 1, 2, 3, 4 | steak, potato, wine, cake
night, 1, 2, 2, 4 | steak, potato(x2), cake
night, 1, 2, 3, 5 | steak, potato, wine, error
night, 1, 1, 2, 3, 5 | steak, error


The API is temporarily available at this link: [API Swagger Link](https://restaurantorderapp.azurewebsites.net/swagger/index.html) 

## Solution Structure
### RestaurantOrder.IntegrationTests
This project contains the Integration tests, and it is using xUnit + FluentAssertions.
There is a trigger (PR to main branch) to run this test with [Github Actions](https://github.com/andersonnichele/Restaurant-Order-App/actions?query=workflow%3A%22Build+and+deploy+ASP.Net+Core+app+to+Azure+Web+App+-+restaurantorderapp%22) before publish it to Azure

### RestaurantOrder.WebApi
This project contains the Web API project with .net Core 3.1.
There is a trigger (PR to main branch) to publish it to Azure with [Github Actions](https://github.com/andersonnichele/Restaurant-Order-App/actions?query=workflow%3A%22Build+and+deploy+ASP.Net+Core+app+to+Azure+Web+App+-+restaurantorderapp%22)

### RestaurantOrderApp.Client
This is a project with a simple console aplication that consumes the API.
The URL of API is HardCoded inside [RestaurantOrderService class](https://github.com/andersonnichele/Restaurant-Order-App/blob/develop/RestaurantOrderApp.Client/Service/RestaurantOrderService.cs) at line 9

