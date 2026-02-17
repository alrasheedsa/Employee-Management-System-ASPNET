# Employee Management & Operations System

A secure, full-stack web application built using **ASP.NET Web Forms** and **SQL Server**. This project was developed to manage internal business processes, focusing on data integrity, security, and automated communication.

## 🚀 Key Features & Achievements
* **Full-Stack Development**: Built a comprehensive management system using **C#** and **ASP.NET**, incorporating **Authentication** and **Role-Based Access Control (RBAC)**.
* **Database Engineering**: Designed and optimized relational database schemas in **SQL Server**, ensuring data integrity and high query performance.
* **Centralized Data Access**: Engineered a custom `CRUD.cs` class using **ADO.NET** to handle all database interactions securely via parameterized queries, preventing SQL Injection.
* **Automation & Notifications**: Integrated **SMTP services** for system-wide automated notifications and utilized **Python scripts** to handle background tasks, reducing administrative overhead.
* **Dynamic UI**: Implemented interactive web pages with **GridViews** and **DropDownLists** that bind dynamically to SQL data sources.

## 🛠️ Technical Stack
* **Backend**: C# (.NET Framework 4.7.2)
* **Frontend**: ASP.NET Web Forms, HTML5, CSS3, JavaScript, Bootstrap
* **Database**: Microsoft SQL Server (SSMS 18)
* **Data Access**: ADO.NET (SqlClient)

## 📁 Project Structure
* `/Demo 1`: Contains all functional `.aspx` pages (Login, Register, Employee Management).
* `/App_Code/CRUD.cs`: The core engine for database operations.
* `Web.config`: Centralized application configuration.
* `DatabaseScript.sql`: SQL Script to regenerate the database schema and sample data.

## ⚙️ How to Setup
1.  **Clone the Repository**: Download or clone the project files.
2.  **Database Setup**: Execute the `DatabaseScript.sql` file in your SQL Server instance to create the tables and initial data.
3.  **Connection String**: Update the `connectionString` in the `Web.config` file to point to your local SQL Server.
4.  **Run**: Open the `.sln` file in Visual Studio and press **F5**.

---
**Developed by: Mohammed Alrasheed**