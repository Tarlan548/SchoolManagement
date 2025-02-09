# School Management System

## Overview

The **School Management System** is a comprehensive platform designed to streamline administrative tasks in educational institutions. It provides features for student enrollment, teacher management, course scheduling, and grade tracking.

## Features

- Student registration and profile management
- Teacher and staff management
- Course and timetable scheduling
- Attendance tracking
- Grade management
- User authentication and role-based access

## Technologies Used

- **Backend:** .NET (C#)
- **Frontend:** React.js (or Blazor)
- **Database:** SQL Server
- **Authentication:** JWT & Identity
- **Cloud Services:** AWS (Optional)
- **Architecture:** Clean Architecture, Repository Pattern, Unit of Work

## Installation

### Prerequisites

- .NET SDK installed
- SQL Server running
- Node.js (if using React for frontend)

### Steps to Run the Project

#### 1. Clone the Repository

```bash
git clone https://github.com/Tarlan548/SchoolManagement.git
cd SchoolManagement
```

#### 2. Setup Database

- Update connection string in `appsettings.json`.
- Apply migrations:

```bash
dotnet ef database update
```

#### 3. Run the Application

```bash
dotnet run
```

If using frontend:

```bash
cd frontend
npm install
npm start
```

## API Documentation

The API follows RESTful principles and provides the following endpoints:

| Endpoint             | Method | Description         |
| -------------------- | ------ | ------------------- |
| `/api/students`      | GET    | Get all students    |
| `/api/students/{id}` | GET    | Get student by ID   |
| `/api/students`      | POST   | Add new student     |
| `/api/students/{id}` | PUT    | Update student info |
| `/api/students/{id}` | DELETE | Remove student      |

## Contribution

Feel free to fork this repository and submit pull requests with improvements.

## License

This project is open-source under the **MIT License**.

