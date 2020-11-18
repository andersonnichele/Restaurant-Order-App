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
1 (entrée) | eggs | steak
2 (side) | toast | potato
3 (drink) | coffee | wine
4 (dessert) | Not Applicable | cake

Sample Input and Output


<strong>Input</strong>: morning, 1, 2, 3         <strong>Output</strong>: eggs, toast, coffee

<strong>Input</strong>: morning, 2, 1, 3         <strong>Output</strong>: eggs, toast, coffee

<strong>Input</strong>: morning, 1, 2, 3, 4      <strong>Output</strong>: eggs, toast, coffee, error

<strong>Input</strong>: morning, 1, 2, 3, 3, 3   <strong>Output</strong>: eggs, toast, coffee(x3)

<strong>Input</strong>: night, 1, 2, 3, 4        <strong>Output</strong>: steak, potato, wine, cake

<strong>Input</strong>: night, 1, 2, 2, 4        <strong>Output</strong> steak, potato(x2), cake

<strong>Input</strong>: night, 1, 2, 3, 5        <strong>Output</strong>: steak, potato, wine, error

<strong>Input</strong>: night, 1, 1, 2, 3, 5     <strong>Output</strong>: steak, error


The API is temporarily available at this link: [API Link](https://restaurantorderapp.azurewebsites.net/swagger/index.html) 
