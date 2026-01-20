

---

# 🎓 Student Management System

**ASP.NET MVC + ADO.NET**

A **Student Management System** built using **ASP.NET MVC** with **ADO.NET**, supporting **CRUD operations**, **row-level editing**, **AJAX-based dropdowns**, and **multi-document uploads** mapped to document types.

This project follows **real-world ASP.NET architecture**, uses **stored procedures only**, and avoids Entity Framework completely.

---

## 🚀 Features

* ✅ Create, Read, Update, Delete (CRUD) students
* ✅ Row-level editing without page reload
* ✅ AJAX-based department dropdown
* ✅ Gender selection using dropdown
* ✅ Upload **multiple documents per student**
* ✅ Document-type mapping (Aadhar, PAN, DL, etc.)
* ✅ View uploaded documents
* ✅ Secure form submission using **Anti-Forgery Token**
* ✅ 100% **ADO.NET** (No Entity Framework)

---

## 🛠️ Tech Stack

| Layer        | Technology                              |
| ------------ | --------------------------------------- |
| Frontend     | Razor Views (CSHTML), Bootstrap, jQuery |
| Backend      | ASP.NET MVC                             |
| Data Access  | ADO.NET                                 |
| Database     | SQL Server                              |
| Security     | Anti-Forgery Token                      |
| File Uploads | IFormFile + GUID                        |

---

## 📂 Project Structure

```
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
│   │   ├── Update.cshtml
│   │   └── ViewDocuments.cshtml
│
├── wwwroot/
│   └── uploads/
│
├── Scripts/
│   └── index.js
│
└── README.md
```

---

## 🗄️ Database Design

### Tables

* **Students**
* **Department**
* **DocumentTypes**
* **StudentDocuments**
* **StudentDocumentFiles**

### Relationships

* One **Student** → Many **Documents**
* One **DocumentType** → Many **Files**
* Foreign keys enforced for data integrity

---

## 📜 Stored Procedures Used

* `sp_InsertStudent`
* `sp_UpdateStudent`
* `sp_DeleteStudent`
* `sp_SelectAllStudents`
* `sp_GetDepartments`
* `sp_GetDocumentTypes`
* `sp_InsertStudentDocuments`
* `sp_InsertStudentDocumentFiles`
* `sp_GetStudentDocuments`

---

## 🔄 Application Execution Flow

1. User submits form with **Anti-Forgery Token**
2. MVC model binding maps form → ViewModel
3. Controller validates `ModelState`
4. DAL executes stored procedures via ADO.NET
5. Files saved in `/wwwroot/uploads` using **GUID**
6. File metadata stored in database
7. Redirect to Index page with `TempData` message

---

## 📁 File Upload Strategy

* Supports **multiple file uploads**
* Each file mapped to a **document type**
* Files stored as:

```
/wwwroot/uploads/{GUID}_{OriginalFileName}
```

* Database stores:

  * Original file name
  * File path
  * Document type ID
  * Student ID

---

## 🔐 Security

* Anti-Forgery Token for POST requests
* SQL Injection protection using:

  * Stored Procedures
  * Parameterized queries
* File name collision prevention using GUID

---

## ⚡ AJAX Usage

* Load departments dynamically
* Load document types dynamically
* Improves UX (no full page reloads)

---

## 🧪 Error Handling

* Handles `DBNull` values safely
* Uses nullable fields where required
* Validates input before database operations

---

## 🎯 Learning Outcomes

* ASP.NET MVC architecture
* ADO.NET with Stored Procedures
* Model vs ViewModel usage
* AJAX integration in MVC
* Secure file uploads
* Real-world CRUD workflows

---

## ▶️ How to Run the Project

1. Clone the repository

```bash
git clone https://github.com/your-username/student-management-ado.git
```

2. Configure SQL Server connection string in `appsettings.json`

3. Execute SQL scripts to create:

   * Tables
   * Stored Procedures

4. Open the project in **Visual Studio**

5. Run the application 🎉

---

## 👨‍💻 Author

**Sahil Sawant**
MCA Student
ASP.NET MVC | ADO.NET | SQL Server

---

## ⭐ Support

If you found this project useful, please give it a ⭐ on GitHub!

---
