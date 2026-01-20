🎓 Student Management System (ASP.NET MVC + ADO.NET)

A Student Management System built using ASP.NET MVC with ADO.NET, supporting CRUD operations, row-level editing, AJAX-based dropdowns, and multi-document uploads mapped to document types.

This project is designed with real-world architecture, stored procedures, and proper separation of concerns, making it suitable for college projects, placements, and learning enterprise ASP.NET development.

🚀 Features

✅ Add / Update / Delete Students

✅ Row-level editing without page reload

✅ Department dropdown loaded via AJAX

✅ Gender selection with dropdown

✅ Upload multiple documents per student

✅ Document types mapping (Aadhar, PAN, DL, etc.)

✅ View uploaded documents

✅ Secure form submission using Anti-Forgery Token

✅ Uses Stored Procedures only (No Entity Framework)

🛠️ Tech Stack
Layer	Technology
Frontend	Razor Views (CSHTML), Bootstrap, jQuery
Backend	ASP.NET MVC (.NET)
Data Access	ADO.NET
Database	SQL Server
Security	Anti-Forgery Token
File Uploads	IFormFile, GUID-based naming
📂 Project Structure
CRUD_ADO/
│
├── Controllers/
│   └── StudentController.cs
│
├── Models/
│   ├── Student.cs
│   ├── StudentViewModel.cs
│   ├── StudentCreateViewModel.cs
│   └── StudentDocumentViewModel.cs
│
├── DAL/
│   └── StudentDAL.cs
│
├── Views/
│   ├── Student/
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   └── ViewDocuments.cshtml
│
├── wwwroot/
│   └── uploads/
│
├── Scripts/
│   └── index.js
│
└── README.md

🗄️ Database Design
Tables

Students

Department

DocumentTypes

StudentDocuments

StudentDocumentFiles

Key Relationships

One Student → Many Documents

One DocumentType → Many Files

Foreign keys enforced for data integrity

📜 Stored Procedures Used

sp_InsertStudent

sp_UpdateStudent

sp_DeleteStudent

sp_SelectAllStudents

sp_GetDepartments

sp_GetDocumentTypes

sp_InsertStudentDocuments

sp_InsertStudentDocumentFiles

sp_GetStudentDocuments

🔄 Execution Flow (High Level)

User submits form with Anti-Forgery Token

MVC Model Binding maps form → ViewModel

Controller validates ModelState

DAL executes Stored Procedures via ADO.NET

Files are saved in wwwroot/uploads with GUID

File metadata stored in DB

User redirected with TempData success message

📁 File Upload Strategy

Multiple files supported

Each file mapped to a Document Type

Files stored as:

/wwwroot/uploads/{GUID}_{OriginalFileName}


Database stores:

Original file name

Relative file path

Document type

Student ID

🔐 Security

Anti-Forgery Token enabled for all POST requests

SQL Injection prevented using:

Stored Procedures

Parameterized queries

File name collision avoided using GUID

📌 AJAX Usage

Load Departments dynamically

Load Document Types dynamically

Improves UX by avoiding page reloads

🧪 Error Handling

Handles DBNull safely in ADO.NET

Uses nullable types where required

Validates input before DB operations

🎯 Learning Outcomes

ASP.NET MVC architecture

ADO.NET with Stored Procedures

Model vs ViewModel usage

AJAX integration in MVC

File uploads & DB mapping

Real-world CRUD patterns

▶️ How to Run the Project

Clone the repository

git clone https://github.com/your-username/student-management-ado.git


Configure SQL Server connection string in appsettings.json

Run SQL scripts to create:

Tables

Stored Procedures

Open project in Visual Studio

Run the application 🎉

📸 Screenshots (Optional)

Student List

Row Editing

Create Student

Document Upload

View Documents

(Add screenshots here)

👨‍💻 Author

Sahil Sawant
MCA Student | ASP.NET | ADO.NET | SQL Server
