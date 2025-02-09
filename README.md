# HarvestHub

HarvestHub is a digital platform designed to revolutionize task management, monitoring, and planning in the agricultural sector. By providing real-time monitoring, task scheduling, and site management, HarvestHub aims to increase productivity, better resource utilization, and higher crop yields.

## Background

The agricultural sector is evolving, and there is a growing need for efficient task management, monitoring, and planning in the industry. Currently, tasks are assigned manually, and there is little to no visibility into task progress, field conditions, or worker performance. HarvestHub aims to revolutionize this process by providing a digital platform that offers real-time monitoring, task scheduling, and site management. HarvestHub will enable farm managers to effectively assign tasks to workers, monitor their progress in the field, and plan future operations based on real-time data.

## Features

- **Real-time Monitoring**: Monitor field conditions and task progress in real-time.
- **Task Scheduling**: Efficiently assign and schedule tasks for workers.
- **Site Management**: Manage farm sites with ease and improve resource utilization.

## Technologies

### Backend

- **Platform**: .NET Core 8.0
- **Language**: C#
- **Framework**: ASP.NET Core
- **Database**: Microsoft SQL Server

### Frontend

- **Framework**: Vue.js 3
- **HTTP Client**: Axios
- **UI Components**: Vue component library

##  Unit Testing & API Testing
- **Unit Testing** dilakukan dengan NUnit/XUnit.
- **API Testing** menggunakan:
  - **Postman Collection**: Untuk mengelola dan menjalankan request API secara otomatis.
  - **Swagger UI**: Untuk mendokumentasikan dan menguji endpoint API langsung di browser.

##  Security & Authentication Details
- **Autentikasi** menggunakan **JWT Token**.
- **Refresh Token** disediakan untuk memperpanjang sesi pengguna tanpa perlu login ulang.
- Token disimpan dengan aman dan memiliki masa berlaku yang telah ditentukan.

## Project Structure


### HarvestHubAPI
- **Frontend/hubharvestfront/**
  - **.idea/**: Folder pengaturan IDE.
  - **dist/**: Folder build yang dihasilkan.
  - **node_modules/**: Direktori pustaka yang diinstal.
  - **public/**: Folder file publik.
  - **src/**: Folder kode sumber.
  - **.gitignore**: File pengaturan gitignore.
  - **babel.config.js**: File pengaturan Babel.
  - **jsconfig.json**: File pengaturan JavaScript.
  - **package.json**: File pengaturan paket.
  - **README.md**: File dokumentasi.
  - **vue.config.js**: File pengaturan Vue.
  - **yarn.lock**: File kunci dependensi Yarn.
- **HarvestHubAPI/**
  - **bin/**: Folder bin yang dihasilkan.
  - **Controllers/**: Folder untuk pengontrol aplikasi.
  - **Data/**: Folder untuk data terkait.
    - **Helpers/**: Folder untuk helper data.
    - **Migrations/**: Folder untuk migrasi data.
  - **Models/**: Folder untuk model data.
  - **obj/**: Folder objek yang dihasilkan.
  - **Properties/**: Folder untuk properti proyek.
  - **Repositories/**: Folder untuk repositori data.
  - **Services/**: Folder untuk layanan aplikasi.
  - **Validators/**: Folder untuk validator layanan.
  - **appsettings.json**: File pengaturan aplikasi.
  - **appsettings.Development.json**: File pengaturan aplikasi untuk pengembangan.
  - **HarvestHubAPI.csproj**: File proyek untuk HarvestHubAPI.
  - **HarvestHubAPI.http**: File pengaturan HTTP untuk HarvestHubAPI.
  - **Program.cs**: File utama untuk menjalankan aplikasi.
  - **.gitignore**: File pengaturan gitignore.
  - **HarvestHubAPI.sln**: File solusi untuk Visual Studio.
  - **Scratches and Consoles**: Folder untuk catatan dan konsol.


## Prerequisites

- **.NET SDK 8.0**: Make sure you have the latest .NET SDK installed.
- **Vue.js and yarn**: Ensure you have Vue.js (version 3 or higher) and npm installed.
- **Microsoft SQL Server**: Install and configure Microsoft SQL Server.

## Environment Setup

### 1️⃣ Clone Repository
Pastikan Git telah terinstall di sistem Anda. Jalankan perintah berikut untuk meng-clone repository ini:  
```sh
git clone https://github.com/rayhanyoshh/harvesthub.git
cd harvesthub
```

### 2️⃣ Buka dengan Rider
Buka **JetBrains Rider** dan pilih opsi **Open**. Arahkan ke folder proyek yang telah di-clone.

### 3️⃣ Restore Dependensi
Pulihkan semua dependensi menggunakan perintah berikut:  
```sh
dotnet restore
```

- **Restore the Database**

   If you have a .bak file for the database backup, follow these steps to restore it:

    - Open Microsoft SQL Server Management Studio (SSMS).

    - Connect to your SQL Server instance.

    - Right-click on the Databases node in Object Explorer and select Restore Database.

    - Select Device and then click on the ellipsis (...) button to browse for the .bak file.

    - Add the HarvestHubDb.bak file and click OK.

    - Specify the database name you want to restore to and configure any additional settings if needed.

    - Click OK to start the restore process.

# HarvestHub API Documentation

## Authentication

### Login
**Endpoint:**  
`POST http://localhost:5177/api/Auth/login`  

**Headers:**  
- `Content-Type: application/json`  

**Request Body:**  
```json
{
    "email": "newuser@example.com",
    "password": "newuserpassword"
}
```

---

## Work Tasks

### Create Work Task
**Endpoint:**  
`POST http://localhost:5177/api/WorkTasks`  

**Headers:**  
- `Content-Type: application/json`  
- `Authorization: Bearer <your_token>`  

**Request Body:**  
```json
{
  "farmFieldId": 12,
  "workTaskTypeCode": "Cultivate",
  "dueDate": "2023-12-31T23:59:59Z",
  "instruction": "Complete cultivation before the end of the year",
  "WorkTaskName": "Tugas awal",
  "Attachment": "Tugas.pdf"
}
```

---

### Get All Work Tasks
**Endpoint:**  
`GET http://localhost:5177/api/WorkTasks`  

**Headers:**  
- `Content-Type: application/json`  
- `Authorization: Bearer <your_token>`  

---

## Farm Fields

### Create New Farm Field
**Endpoint:**  
`POST http://localhost:5177/api/FarmFields`  

**Headers:**  
- `Authorization: Bearer <your_token>`  

**Request Body:**  
```json
{
  "farmSiteId": 2,
  "farmFieldName": "South Field",
  "location": "South Section",
  "size": 15.5,
  "farmFieldColorHexCode": "#00FF00",
  "farmFieldRowDirection": "South-South"
}
```

---

### Get All Farm Fields
**Endpoint:**  
`GET http://localhost:5177/api/FarmFields`  

---

## Farm Sites

### Create Farm Site
**Endpoint:**  
`POST http://localhost:5177/api/FarmSites`  

**Headers:**  
- `Content-Type: application/json`  
- `Authorization: Bearer <your_token>`  

**Request Body:**  
```json
{
  "farmSiteName": "West Farm",
  "defaultPrimaryCropId": 1,
  "createdUserId": 123
}
```

---

### Get All Farm Sites
**Endpoint:**  
`GET http://localhost:5177/api/FarmSites`  

---

## Work Task Types

### Create Work Task Type
**Endpoint:**  
`POST http://localhost:5177/api/WorkTaskTypes`  

**Headers:**  
- `Content-Type: application/json`  
- `Authorization: Bearer <your_token>`  

**Request Body:**  
```json
{
    "workTaskTypeCode": "001",
    "description": "Cultivate"
}
```

---

### Get All Work Task Types
**Endpoint:**  
`GET http://localhost:5177/api/WorkTaskTypes`  

---

## Crops

### Create Crop
**Endpoint:**  
`POST http://localhost:5177/api/Crops`  

**Headers:**  
- `Content-Type: application/json`  
- `Authorization: Bearer <your_token>`  

**Request Body:**  
```json
{
    "cropCode": "WHEAT001"
}
```

**Response:**  
```json
{
    "cropId": 1,
    "cropCode": "WHEAT001",
    "createdDate": "2024-02-09T12:00:00Z",
    "createdUserId": 123,
    "modifiedDate": "2024-02-09T12:00:00Z",
    "modifiedUserId": 123,
    "isDeleted": false
}
```

---

### Get All Crops
**Endpoint:**  
`GET http://localhost:5177/api/Crops`  

**Headers:**  
- `Authorization: Bearer <your_token>`  

**Response:**  
```json
[
    {
        "cropId": 1,
        "cropCode": "WHEAT001",
        "createdDate": "2024-02-09T12:00:00Z",
        "createdUserId": 123,
        "modifiedDate": "2024-02-09T12:00:00Z",
        "modifiedUserId": 123,
        "isDeleted": false
    },
    {
        "cropId": 2,
        "cropCode": "CORN002",
        "createdDate": "2024-02-10T14:30:00Z",
        "createdUserId": 124,
        "modifiedDate": "2024-02-10T14:30:00Z",
        "modifiedUserId": 124,
        "isDeleted": false
    }
]
```

---

### Get Crop By ID
**Endpoint:**  
`GET http://localhost:5177/api/Crops/{id}`  

**Headers:**  
- `Authorization: Bearer <your_token>`  

**Response:**  
```json
{
    "cropId": 1,
    "cropCode": "WHEAT001",
    "createdDate": "2024-02-09T12:00:00Z",
    "createdUserId": 123,
    "modifiedDate": "2024-02-09T12:00:00Z",
    "modifiedUserId": 123,
    "isDeleted": false
}
```

---

### Update Crop
**Endpoint:**  
`PUT http://localhost:5177/api/Crops/{id}`  

**Headers:**  
- `Content-Type: application/json`  
- `Authorization: Bearer <your_token>`  

**Request Body:**  
```json
{
    "cropCode": "NEWCROP123",
    "modifiedUserId": 125,
    "isDeleted": false
}
```

**Response:**  
```json
{
    "cropId": 1,
    "cropCode": "NEWCROP123",
    "createdDate": "2024-02-09T12:00:00Z",
    "createdUserId": 123,
    "modifiedDate": "2024-02-10T15:00:00Z",
    "modifiedUserId": 125,
    "isDeleted": false
}
```

---

### Delete Crop (Soft Delete)
**Endpoint:**  
`DELETE http://localhost:5177/api/Crops/{id}`  

**Headers:**  
- `Authorization: Bearer <your_token>`  

**Response:**  
```json
{
    "message": "Crop successfully deleted."
}
```

## 🎯 Penutup

Terima kasih telah menggunakan proyek ini! Jika Anda memiliki pertanyaan, saran, atau menemukan masalah, jangan ragu untuk menghubungi atau membuat issue di repository ini.

📌 **Kontribusi:**  
Kami selalu terbuka untuk kontribusi! Silakan fork repository ini dan ajukan pull request untuk perbaikan atau fitur baru.

📌 **Lisensi:**  
Proyek ini dilisensikan di bawah [MIT License](LICENSE).
