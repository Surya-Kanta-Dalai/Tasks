# Library Management System - Configuration Guide

## Prerequisites
- **.NET SDK 8.0+** (or compatible version)
- **SQL Server Express** (or SQL Server)
- **SQL Server Management Studio (SSMS)** (optional, for easier database setup)

---

## Configuration Steps

### **1. Update appsettings.json**

Edit the `appsettings.json` file and replace `YOUR_SERVER_NAME` with your SQL Server instance name:

**Common SQL Server names:**
- `.` (dot) = Local default instance
- `.\SQLEXPRESS` = Local SQL Server Express
- `COMPUTERNAME\SQLEXPRESS` = Named instance
- `SERVER_IP\SQLEXPRESS` = Remote server

**Example:**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQLEXPRESS;Database=LibraryDB;Trusted_Connection=True;Encrypt=False;"
  }
}
```

---

### **2. Find Your SQL Server Instance Name**

**Option A: Check in SSMS**
- Open SQL Server Management Studio
- The server name appears in the "Server name" field at connection

**Option B: Check via Command Prompt**
```cmd
sqlcmd -L
```
This lists all available SQL Server instances on your network.

**Option C: Default Names**
- If using SQL Server Express: `.\\SQLEXPRESS`
- If using LocalDB: `(localdb)\\mssqllocaldb`

---

### **3. Create the Database**

**Option A: Using SQL Server Management Studio**
1. Open SSMS and connect to your SQL Server
2. Open `setup-database.sql` in SSMS
3. Execute the script (F5 or Ctrl+E)
4. Verify database "LibraryDB" appears in Object Explorer

**Option B: Using Command Line**
```cmd
sqlcmd -S YOUR_SERVER_NAME -E -i setup-database.sql
```

**Option C: Using .NET CLI**
Create a setup utility to run SQL scripts programmatically.

---

### **4. Restore NuGet Packages**

Open Terminal in the project folder and run:
```cmd
dotnet restore
```

---

### **5. Build the Project**

```cmd
dotnet build
```

---

### **6. Run the Application**

```cmd
dotnet run
```

---

## Troubleshooting

### **Error: "Connection failed"**
- ✓ Verify SQL Server is running
- ✓ Check server name in appsettings.json
- ✓ Verify database "LibraryDB" exists in SQL Server

### **Error: "Cannot connect to server"**
- ✓ Run: `sqlcmd -S YOUR_SERVER_NAME` to verify connectivity
- ✓ Check if SQL Server Authentication is enabled

### **Error: "Database does not exist"**
- ✓ Run the `setup-database.sql` script in SSMS
- ✓ Verify script executed without errors

### **Error: "Named Pipes provider"**
- ✓ Use `Encrypt=False;` in connection string (already done)
- ✓ Enable Named Pipes in SQL Server Configuration Manager

---

## Project Structure

```
LibraryManagementSystem/
├── Program.cs              (Main application entry point)
├── DBHelper.cs             (Database connection management)
├── Books.cs                (Book model)
├── BookRepository.cs       (Book operations)
├── Authors.cs              (Author model)
├── AuthorRepository.cs     (Author operations)
├── Category.cs             (Category model)
├── CategoryRepository.cs   (Category operations)
├── Members.cs              (Member model)
├── MemberRepository.cs     (Member operations)
├── Transactions.cs         (Transaction model)
├── TransactionRepository.cs (Transaction operations)
├── LibraryManagementSystem.csproj (Project file)
├── appsettings.json        (Configuration file)
└── setup-database.sql      (Database schema)
```

---

## Next Steps

1. ✅ Update `appsettings.json` with your SQL Server name
2. ✅ Run `setup-database.sql` to create the database
3. ✅ Run `dotnet restore` to install packages
4. ✅ Run `dotnet build` to compile
5. ✅ Run `dotnet run` to start the application
