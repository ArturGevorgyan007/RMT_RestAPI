# RMT_RestAPI

## REST server
A small REST server with good performance for simple customer management has two functions:
- POST customers
Request:
[
{
firstName: &#39;Aaaa&#39;,
lastName: &#39;Bbbb&#39;,
age: 20,
id: 5
},
{
firstName: &#39;Bbbb&#39;,
lastName: &#39;Cccc&#39;,
age: 24,
id: 6
}
]

Multiple customers can be sent in one request.

The server validates every customer of the request:
- checks that every field is supplied
- validates that the age is above 18
- validates that the ID has not been used before
  
The server then adds each customer as an object to an internal array – the customers will not be
appended to the array but instead it will be inserted at a position so that the customers are
sorted by last name and then first name WITHOUT using any available sorting functionality (an
example for the inserting is in the Appendix).

The server also persists the array so it will be still available after a restart of the server.
- GET customers

Returns the array of customers with all fields

Write the server and a small simulator which can send several requests for POST customers and GET
customers in parallel to the server.

For that program it is not allowed to use any sorting mechanism like array.sort().
The simulated POST customers requests have following requirements:
- Each request should contain at least 2 different customers
- Age should be randomized between 10 and 90
- ID should be increasing sequentially.
- The first names and last names of the Appendix should be used in random combinations

## Solution

I created webapi project with Get and Post HTTP request in Controller. For data validation I used System.ComponentModel.DataAnnotations. In order to have persistant data I saved Customers in JSON file located in Data folder.
For demo, please use Swagger with your localhost and port. Ex. http://localhost:[PortNum]/Swagger/index.html
