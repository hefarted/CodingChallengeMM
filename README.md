# CodingChallengeMM
## Table of Contents
- [Features](#features)
- [Technical Requirements](#technical-requirements)
- [Installation](#installation)
- [Running the Application](#running-the-application)
- [Testing](#testing)
- [Contributing](#contributing)
- [License](#license)
  
# Loan Management System

The Loan Management System is an ASP.NET Web API designed to facilitate the processing of loan applications. This application allows users to enter personal and financial details, calculates potential loan repayments, and validates user eligibility based on predefined rules. It's built to be consumed by third-party applications, ensuring that after validation, users are redirected to a tailored success page.

## Features

- **Loan Application**: Supports receiving comprehensive user data and saving it persistently.
- **Data Validation**: Includes validation for age, blacklist status of mobile numbers and email domains.
- **Dynamic User Interface**: Features dynamic form elements like sliders and dropdowns to enhance user experience.
- **Automatic Calculations**: Utilizes a PMT-like function to calculate repayment amounts.
- **Editable Entries**: Users can edit their data before final submission. (Todo)
- **Robust Security**: Ensures that only eligible applications are processed. (Todo)

## Prerequisites

Before you begin, ensure you have met the following requirements:
- .NET Core 3.1 SDK or .NET 5/6 (as required by your setup)
- SQL Server (appropriate version for your .NET setup)
- Visual Studio 2019 or later

## Technical Requirements

Before setting up the project, ensure you have met the following requirements:
- **.NET Core**: The backend API is built with .NET Core, ensuring cross-platform compatibility. Install the .NET Core SDK appropriate for your development needs.
- **Angular**: Front-end application built using Angular. Requires Angular CLI, Node.js, and npm for development.
- **Entity Framework Core**: Used for ORM in the .NET Core API. Ensure necessary packages are included in the project.
- **Swagger**: Integrated for API documentation and endpoint testing. Set up is required in the project configuration.
- **SQL Server**: Used as the primary database. Ensure you have access to SQL Server for development and production environments.

## Installation

Clone the repository to your local machine:



## Usage Examples

### Database Setup
1. **Create Database**:
   To initialize the system, ensure you have an SQL Server instance. First, create a database named `MoneyMeCodingChallenge` using SQL Server Management Studio (SSMS)

```bash
git clone https://github.com/hefarted/CodingChallengeMM.git
dotnet restore
npm install
```
```  sql
   CREATE DATABASE MoneyMeCodingChallenge;
```
2. **Configure Connection String**:
   Update the appsettings.json in your project to include the correct connection string pointing to your SQL Server:

```
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\MSSQLSERVER07;Database=MoneyMeCodingChallenge;Trusted_Connection=True;TrustServerCertificate=True;"
}
```
Adjust the server name and other parameters as necessary to match your SQL Server configuration.

3. **Apply Entity Framework Migrations**:
   Navigate to the directory of your .NET Core API project that contains the Startup.cs file. Use Entity Framework Core to set up and update your database schema:
```
dotnet restore
dotnet ef migrations add InitialCreate
dotnet ef database update
```
   These commands install any missing dependencies, create necessary migration scripts, and apply these migrations to update the database.

## Running the Application

### Backend API with Visual Studio Code

**Open the Backend Project**:
   Launch Visual Studio Code and open the backend project folder.
   
   Click on the green play button in the top-right corner or press F5 to start debugging. This action will run the API project and listen for incoming requests.

## Testing Procedures (Not yet implemented)

To ensure the reliability of the application, a suite of tests has been written using xUnit. These tests cover both unit and integration test cases. Follow the instructions below to run the tests:

1. **Open the Test Project**:
   Open the folder that contains your xUnit test project in Visual Studio Code or your preferred IDE.

2. **Restore Test Dependencies**:
   In the integrated terminal, execute the following command to restore all the dependencies required by the test project:
   
   ```bash
   dotnet restore
   ```
## Contributing

Contributions are welcome! Feel free to submit bug reports, feature requests, or pull requests.

## License

This project is licensed under the [MIT License](LICENSE).


