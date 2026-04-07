# CarDealerProject

Hello!
Welcome to my CarDealerWebProject.

Project Overview

CarDealer is a web-based application designed to simulate a real-world vehicle marketplace. It enables administrators to manage sellers, while sellers can publish and manage vehicle listings that are publicly accessible.
The system demonstrates practical implementation of role-based authorization, MVC architecture, database-driven application design, and structured business logic.
Some features are not fully implemented due to time constraints.

Core Functionality

User Roles - The system implements role-based access control using ASP.NET Identity:

Administrator

Full access to all system features
Can create and manage sellers
Can manage all vehicles

Seller

Can create, edit, and delete vehicle listings

Public Users

Can browse and view vehicle details
No modification permissions

Vehicle Management

Create vehicle listings
Edit and delete vehicles
View detailed vehicle information
Support for multiple vehicle components (e.g., motors)

Authentication & Authorization

Implemented using ASP.NET Core Identity
Default Identity UI scaffolded and customized
Role-based authorization applied across controllers and views

Architecture & Design

The project follows the Model-View-Controller (MVC) pattern.

Models -Represent database entities such as Vehicle, Motor, User, and Role
Views - Razor-based UI for dynamic content rendering
Controllers - Handle HTTP requests and coordinate between Views and business logic

Additional Design Decisions

Administrative functionality is separated using Areas
Users and roles use GUIDs instead of integers
Vehicles are structured to support multiple components (motors)

Data Management

Admin Seeding - A singleton service ensures that an administrator account is automatically created when the application starts.

Default Credentials:

Username: project@abv.bg
Password: B@bachko12

Database Configuration

Connection string is stored using User Secrets
Retrieved via serviceDependencies.local.json in the Properties folder

Validation & Data Integrity

Server-side validation implemented using Data Annotations
Ensures required fields and data consistency
Basic client-side validation supported

Limitations

Due to limited development time, the following features are incomplete:

Image upload and management system
Expanded vehicle types and parts
UI/UX improvements

Technologies Used

.NET 8.0
ASP.NET Core MVC
Entity Framework Core
SQL Server
ASP.NET Identity
Bootstrap
Visual Studio 2022

NuGet Packages

Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore (8.0.8)
Microsoft.AspNetCore.Identity.EntityFrameworkCore (8.0.11)
Microsoft.AspNetCore.Identity.UI (8.0.11)
Microsoft.EntityFrameworkCore.Design (8.0.8)
Microsoft.EntityFrameworkCore.Sqlite (8.0.11)
Microsoft.EntityFrameworkCore.SqlServer (8.0.11)
Microsoft.EntityFrameworkCore.Tools (8.0.11)
Microsoft.VisualStudio.Web.CodeGeneration.Design (8.0.7)

Setup Instructions

Clone the repository
Open the project in Visual Studio 2022
Configure User Secrets (connection string)
Run database migrations using:
Update-Database
Start the application

Design Considerations

Clear separation of concerns using MVC
Role-based security model
Use of GUIDs for better scalability
Flexible vehicle structure supporting multiple components

Future Improvements

Full image upload system
Improved UI/UX
Expansion of the domain model with additional classes (e.g., more vehicle components, categories, and related entities) to better represent real-world vehicle data
