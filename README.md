# Football Fantasy Project

**Football Fantasy Management System** developed in C# using the .NET 7.0 framework. This application provides user registration, login, and comprehensive management of football fantasy teams.

## Project Overview

For a detailed understanding of the system architecture, features, and usage instructions, please consult the included PDF document:

**[Football-Fantasy.pdf](./Football-Fantasy.pdf)**

The PDF contains:

- System architecture and design  
- Layered structure explanation (Presentation, Business, Data Access)  
- Database schema and migration details  
- Sample screenshots  
- Setup, configuration, and run instructions  
- Feature descriptions and workflows  


## Project Structure

| Folder/File               | Description                                    |
|--------------------------|------------------------------------------------|
| `DataAccessLayer/`       | Data access logic and Entity Framework setup  |
| `businessLayer/`         | Business logic and core services               |
| `presentationLayer/`     | User interface and presentation logic          |
| `Migrations/`            | Entity Framework Core migration files          |
| `Program.cs`             | Application entry point                         |
| `database0.db`           | SQLite database file                            |
| `appsettings.json`       | Application configuration                       |
| `Football-Fantasy.pdf`   |  Main project documentation                   |
| `front.zip`              | (Optional) Front-end assets or related files    |


## Technologies Used

- **Programming Language:** C#  
- **Framework:** .NET 7.0  
- **ORM:** Entity Framework Core  
- **Database:** SQLite  
- **Architecture:** Layered Architecture (DAL, BLL, UI)  

## Features Summary

- User Registration (Sign Up) with validation  
- Secure User Login with JWT authentication  
- OTP (One-Time Password) validation for new registrations  
- Team management with player selection  
- Integration with external APIs for live player data  
- Data pagination and sorting for efficient API consumption  
- Error handling and input validation  


## Getting Started

### Prerequisites

- Visual Studio 2022 or newer with .NET 7.0 SDK installed  
- SQLite (optional, if you want to inspect the database directly)  

### Setup Instructions

1. **Clone or download** the repository.  
2. Open the solution file `SignUPAndLoginSection.sln` in Visual Studio.  
3. Verify and configure `appsettings.json` for your environment (e.g., connection strings).  
4. Build and run the project (F5 or Ctrl+F5).  


## Usage Details

### Registration (Sign Up)

- Users can register by providing:  
  - Full Name  
  - Email  
  - Username  
  - Password  
- Validations include email format check, password strength, and username uniqueness.  
- OTP verification is sent to validate the user's email before activation.

### Login

- Users log in using username/email and password.  
- Successful login returns a **JWT token** used for authenticated requests.  
- JWT tokens ensure secure access to user-specific data and APIs.  
- Token validation prevents unauthorized access.

### Team & Player Management

- Players and teams are managed based on live API data from the Fantasy Premier League:  
  `https://fantasy.premierleague.com/api/bootstrap-static/`  
- Supports data pagination and sorting to efficiently handle large data sets.  
- Users can select players within budget constraints to build their fantasy team.


## Important Notes

- The project strictly follows **Object-Oriented Programming (OOP)** principles.  
- Source control is managed using **Git** — please follow best practices for commits and branches.  
- The API design and implementation emphasize scalability and maintainability.  
- Unit testing and integration testing are encouraged to ensure stability.  


## Contact & Support

For questions or support, please refer to the documentation or contact the project maintainer.



> **هشدار:**  
> این پروژه به زبان فارسی و انگلیسی مستند شده است.  
> برای مطالعه کامل و دقیق‌تر به فایل PDF اصلی مراجعه کنید.  
