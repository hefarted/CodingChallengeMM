# CodingChallengeMM

# Loan Management System

The Loan Management System is an ASP.NET Web API designed to facilitate the processing of loan applications. This application allows users to enter personal and financial details, calculates potential loan repayments, and validates user eligibility based on predefined rules. It's built to be consumed by third-party applications, ensuring that after validation, users are redirected to a tailored success page.

## Features

- **Loan Application**: Supports receiving comprehensive user data and saving it persistently.
- **Data Validation**: Includes validation for age, blacklist status of mobile numbers and email domains.
- **Dynamic User Interface**: Features dynamic form elements like sliders and dropdowns to enhance user experience.
- **Automatic Calculations**: Utilizes a PMT-like function to calculate repayment amounts.
- **Editable Entries**: Users can edit their data before final submission.
- **Robust Security**: Ensures that only eligible applications are processed.

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

