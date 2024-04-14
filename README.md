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

## Installation

Clone the repository to your local machine:

```bash
git clone https://github.com/your-username/loan-management-system.git
cd loan-management-system
