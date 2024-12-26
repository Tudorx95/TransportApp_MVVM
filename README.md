# Public Transport App

Public Transport is a desktop application designed using the MVVM design pattern in .NET Framework, along with Microsoft-related technologies such as Entity Framework and SQL Server. This application helps citizens find the best way to navigate in a city and offers the possibility of buying new tickets in a predefined account.

## Table of Contents

- [Entity Framework](#entity-framework)
- [Windows Presentation Foundation](#windows-presentation-foundation)
- [MVVM Architecture](#mvvm-architecture)
- [Run Program](#run-program)
- [Contributors](#contributors)

### Entity Framework
Entity Framework (EF) is an Object-Relational Mapper (ORM) developed by Microsoft. It simplifies database interactions by allowing developers to work with data using .NET objects instead of manually handling SQL queries. Key features include:
- **Database Connectivity**: EF establishes a seamless connection between the application and the database.
- **Code-First Approach**: Enables model definition through code.
- **Database Migration**: Allows schema evolution without manual intervention.

### Windows Presentation Foundation
Windows Presentation Foundation is a combination of logical programming techniques and pattern-related design for the UI. 
- The logical part is implemented in C# programming language.
- The interface is designed using XAML (Extensible Application Markup Language) language.

### MVVM Architecture
Model-View-ViewModel (MVVM) is a design pattern that separates the business logic, UI, and application data. The components of MVVM in this application are:
- **Model**: Represents the database entities and data-related operations, often using Entity Framework.
- **View**: Defines the visual elements, designed using XAML.
- **ViewModel**: Acts as the bridge between the View and Model, handling data binding, commands, and interaction logic.

### Run Program
The program can run by following these steps:
- Clone the repository to your specific folder.
- Open the solution file (`TransportApp.sln`) in Visual Studio.
- Ensure Entity Framework migrations are applied by running the following command in the Package Manager Console:
  ```bash
  Update-Database
  ```
- Build the solution in Visual Studio.
- Run the executable from `TransportApp\WpfApp\WpfApp\bin\Debug\WpfApp.exe`.

### Contributors
Project was designed by Lepadatu Tudor and Stanciu George Razvan under the guidance of dr. Lect. Conf. Nita Stefania.

