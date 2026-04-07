# CarDealerProject

Hello!
Welcome to my CarDealerWebProject.

1 - Project Overview

This project was not complete for my final exam.

- The functionality of the project is a sellers website for managing the sales of cars.
- There is an admin/admins and they create new sellers which have the ability to publish cars on the website.
- Admins have the ability to do everything and sellers have the ability to only make changes to vehicles.
- Each car is availalbe to the public to see but not to change/delete.
- The log in page was scafolded and customized to fit the project.

2 - Current Functionality

- Picture management is incomplete as I was not able to implement it in time.
- There were supposed to be more car parts and vehicles.

3 - Project Structure

- The project uses the MVC structure.
- There is an Admin area, other functionality is in the main controller folder.
- A main vehicle class is created which contains different car parts.
- User and AplicationRole base classes have been modified to use GUID.

4 - Environmental variables
- A singleton is created to make sure an admin user always exists when building the project. Credentials are:
Username: "project@abv.bg"
Password: "B@bachko12"
- The Login for Users is at the bottom right of the main page.
- The connection string is located in User Secrets, but which is fetched from the serviceDependencies.local.json file in the Properties folder.

5 - Used Technologies
- .NET 8.0
- Visual studio 2022
- SQL server
- ASP.NET Core
- NuGet
  - Asp.Net.Mvc 
  - AspNetCore.Diagnostics.EntityFrameworkCore 8.0.8
  - AspNetCore.Identity.EntityFrameworkCore 8.0.11 
  - AspNetCore.Identity.UI 8.0.11
  - EntityFrameworkCore.Design 8.0.8
  - EntityFrameworkCore.Sqlite 8.0.11
  - EntityFrameworkCore.SqlServer 8.0.11
  - EntityFrameworkCore.Tools 8.0.11
  - Web.CodeGeneration.Design 8.0.7
