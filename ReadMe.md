# Structural Engineering Calculation Wizard

## Overview

The **Structural Engineering Calculation Wizard** is a full-stack application developed to streamline complex engineering calculations. It provides an interactive user interface for structural design processes, such as material selection, roof modeling, and component-based part management. The tool integrates backend logic to perform precise calculations, ensuring optimal design solutions.

This project utilizes **Svelte** for the frontend, a robust **.NET backend**, and is structured to maintain modularity for both the business logic and presentation layers. With a wizard-based approach, engineers can intuitively complete design tasks while the tool performs necessary backend validations and computations.

---

## Table of Contents

1. [Features](#features)  
2. [Tech Stack](#tech-stack)  
3. [Folder Structure](#folder-structure)  
4. [Setup and Installation](#setup-and-installation)  

---

## Features

- **Wizard-based UI:** Simplifies multi-step engineering calculations.
- **Component and Roof Management:** Create, edit, and list parts and roof types.
- **Authentication System:** Includes sign-in and sign-up functionalities.
- **Dynamic Data Handling:** Support for profile, quote, and parts management.
- **Backend Logic & Calculation Models:** Encapsulates structural analysis algorithms.
- **Responsive Frontend:** Built with Svelte for modern, fast, and smooth UX.

---

## Tech Stack

### Frontend
- **Framework:** SvelteKit
- **Routing:** Svelte’s built-in routing system  
- **Styling:** CSS-in-JS (used within Svelte components)

### Backend
- **Framework:** .NET Core  
- **Database:** SQL (Data handled through Repositories)  
- **Authentication:** JWT-based or OAuth  
- **API Controllers:** Encapsulated business logic through Controllers

---

## Folder Structure

Below is the breakdown of the primary folders and their roles within the project:

### Backend (`backend/`)
- **`Domain/Models/`**: Contains the core domain models used for structural calculations and data objects.  
- **`SunfixBackend/Controllers/`**: Houses API controllers managing requests between the frontend and backend.
- **`SunfixBackend/Data/`**: Database handling logic, including migrations and data models.
- **`SunfixBackend/Repositories/`**: Repository layer to interact with the database.
- **`Properties/`**: Configuration files for backend services.

### Frontend (`frontend/`)
- **`src/routes/`**: Defines the routing logic for the app, including `auth`, `tool`, and `profile` routes.
- **`components/`**: Reusable UI elements (e.g., `Button`, `Card`, `Sidebar`).
- **`logic/`**: Business logic specific to frontend state management.
- **`static/img/`**: Stores static images used across the application.

### Build and Generated Files
- **`build/`**: Contains compiled and optimized frontend files.
- **`.svelte-kit/generated/`**: Auto-generated files from SvelteKit during the build process.

---

## Setup and Installation

### Prerequisites
- **Node.js** (v14.x or later)
- **.NET Core SDK** (v6 or later)
- **SQL Database** setup (local or cloud)

### Steps

1. **Clone the repository:**
   ```bash
   git clone <repository-url>
   cd structural-engineering-wizard
   ```

2. **Backend Setup:**
   - Navigate to the `backend/` folder:
     ```bash
     cd backend
     dotnet restore
     dotnet build
     dotnet run
     ```
   - Ensure the database is running and migrations are applied.

3. **Frontend Setup:**
   - Navigate to the `frontend/` folder:
     ```bash
     cd frontend
     npm install
     npm run dev
     ```
   - Open `http://localhost:3000` in your browser to access the application.
