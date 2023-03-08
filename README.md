# AspNetApiTutorial
 
This project follows a tutorial on how to create an ASP.NET API with the repository pattern.

Tutorial: https://www.freecodecamp.org/news/an-awesome-guide-on-how-to-build-restful-apis-with-asp-net-core-87b818123e28/

## Requirements

* Create a RESTful service that allows client applications to manage a supermarket’s product catalog. It needs to expose endpoints to create, read, edit and delete products categories, such as dairy products and cosmetics, and also to manage products of these categories.
* For categories, we need to store their names. For products, we need to store their names, unit of measurement (for example, KG for products measured by weight), quantity in the package (for example, 10 if the product is a pack of biscuits) and their respective categories.

## Setup

Open a terminal in your project folder.
For the setup you can use the following script:

```
dotnet new webapi --name Supermarket
cd Supermarket
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Relational
dotnet add package Microsoft.EntityFrameworkCore.InMemory
dotnet add package AutoMapper
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
code .
```
