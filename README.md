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

- **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/harvesthub.git

- **Restore the Database**

   If you have a .bak file for the database backup, follow these steps to restore it:

    - Open Microsoft SQL Server Management Studio (SSMS).

    - Connect to your SQL Server instance.

    - Right-click on the Databases node in Object Explorer and select Restore Database.

    - Select Device and then click on the ellipsis (...) button to browse for the .bak file.

    - Add the HarvestHubDb.bak file and click OK.

    - Specify the database name you want to restore to and configure any additional settings if needed.

    - Click OK to start the restore process.
