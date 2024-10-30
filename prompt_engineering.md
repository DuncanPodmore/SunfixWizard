# **System Design Document: Steel Frame Quoting System for Solar Panel Installations**

## 1. **Overview**

This project involves building a **web-based quoting system** for a structural engineering and construction company specializing in steel structures and solar panel installations. The system enables users to **design solar panel arrays**, **manage parts and presets**, and **generate quotes** with real-time part calculations. Each **quote stores the part prices at the time of creation**, ensuring historical consistency. 

The **frontend will be built with Svelte**, and the **backend will use C# with .NET Core**. **PostgreSQL** will handle data storage, and **Azure** will be the hosting provider.

---

## 2. **Requirements**

### 2.1 **Functional Requirements**

1. **User Interface (Frontend)**
   - Draw a **2D solar panel array** with configurable dimensions.
   - Select **panel orientation** (portrait or landscape) for the entire array.
   - Choose **roof type**, **roof sheet**, and **rail type** (continuous or short).
   - Display part calculations **in real-time** based on the array configuration.
   - **Add or edit parts** through a form interface with fields for name, type, and price.
   - Save and reuse **part presets**, associating them with specific roof sheets.
   - **Generate quotes**, storing part prices and quantities in **immutable JSON fields**.
   - **View and archive quotes** using a soft delete (inactive flag).
   - **Export quotes to PDF** using simple HTML rendering.

2. **Backend Services**
   - Manage **clients, projects, quotes, parts, and presets**.
   - Store **part prices within quotes** at the time of creation to ensure consistency.
   - Allow **adding and editing parts**, with updated prices reflected only in new quotes.
   - Handle **soft delete** of quotes, marking them as inactive instead of deleting.
   - **Generate simple PDF quotes** from HTML templates.

3. **Quote Generation Logic**
   - Calculate parts based on:
     - **2D dimensions** of the solar panel array.
     - **Panel orientation** (portrait or landscape).
     - **Roof type, roof sheet**, and **rail type** (continuous or short).
   - Store **part breakdowns with prices** in a JSON field.
   - Display a **line-item cost breakdown** in the quote view.

4. **User Management**
   - Single **admin user** for system management and quote generation.
   - **Secure authentication** to access the system.

---

## 3. **Architecture & System Design**

### 3.1 **Frontend Architecture**

- **Framework:** Svelte  
- **Features:**
  - **Form-based part management** for adding and editing parts.
  - **Drawing tool** to create a solar panel array in 2D.
  - Dropdowns for selecting **roof type, roof sheet**, and **rail type**.
  - **Real-time part calculation** and part display as the array changes.
  - **Simple HTML rendering** for generating PDF quotes.

### 3.2 **Backend Architecture**

- **Framework:** C# with .NET Core
- **API Endpoints:**
  - **Parts Management:**
    - `POST /api/parts` - Add a new part.
    - `PUT /api/parts/{id}` - Edit an existing part.
    - `GET /api/parts` - Retrieve the list of all parts with current prices.
  - **Quote Management:**
    - `POST /api/quotes` - Create a new quote with part prices stored in JSON.
    - `GET /api/quotes/{id}` - Retrieve a specific quote with historical part prices.
    - `PATCH /api/quotes/{id}` - Mark a quote as inactive (soft delete).
  - **Presets Management:**
    - `POST /api/presets` - Create a new part preset.
    - `GET /api/presets` - Retrieve all presets.

### 3.3 **Database Schema (Core Entities)**

1. **Parts**
   - `id` (PK), `name`, `type`, `price` (current), `roof_sheet_id` (optional FK), `preset_flag`.

2. **Part Presets**
   - `id` (PK), `name`, `part_ids` (array of FKs), `roof_sheet_id`.

3. **Quotes**
   - `id` (PK), `project_id` (FK), `array_dimensions` (2D array), `orientation`,  
     `roof_type`, `roof_sheet`, `rail_type`, `active` (boolean), `total_cost`,  
     `parts_snapshot` (JSON field storing part breakdown and prices at the time of quote).

4. **Projects**
   - `id` (PK), `client_id` (FK), `name`, `description`.

5. **Clients**
   - `id` (PK), `name`, `contact_info`.

---

## 4. **Data Structures & Models**

### 4.1 **Quote Request Payload:**
```json
{
  "project_id": 1,
  "array_dimensions": [5, 10],
  "orientation": "landscape",
  "roof_type": "metal",
  "roof_sheet": "trapezoidal",
  "rail_type": "short"
}
```

### 4.2 **Quote Response Example:**
```json
{
  "quote_id": 101,
  "project_id": 1,
  "parts_snapshot": [
    {"name": "Mid Clamp", "quantity": 50, "price": 3.50},
    {"name": "End Clamp", "quantity": 10, "price": 4.00},
    {"name": "Rail Segment", "quantity": 15, "price": 25.00}
  ],
  "total_cost": 475.00,
  "active": true
}
```

### 4.3 **Part Preset Example:**
```json
{
  "preset_id": 3,
  "name": "Mid-Clamp for Trapezoidal Roof",
  "parts": [
    {"name": "Bolt", "quantity": 4, "price": 0.50},
    {"name": "Clamp Base", "quantity": 1, "price": 2.00}
  ],
  "roof_sheet": "trapezoidal"
}
```

---

## 5. **Dependencies & Integrations**

- **Frontend:**  
  Svelte for the user interface and part management.

- **Backend:**  
  C# with .NET Core for API services.

- **Database:**  
  PostgreSQL for relational data storage.

- **Hosting:**  
  **Azure** for deployment and hosting.

- **Libraries:**  
  - **HTML to PDF:** Use `Puppeteer` or `DinkToPdf` to render simple HTML into PDFs.
  - **Authentication:** ASP.NET Identity for user authentication.
  - **Validation:** FluentValidation for input validation.

---

## 6. **Prompts & Tasks for LLMs**

1. **Prompt:**  
   *"Generate a C# API with .NET Core that creates a quote, storing the part breakdown and prices in a JSON field."*  
   **Constraints:**  
   - Store part prices in the `parts_snapshot` field during quote creation.

2. **Prompt:**  
   *"Create a Svelte component for managing parts with form inputs for name, type, and price."*  
   **Constraints:**  
   - Validate that price inputs are positive decimal values.

3. **Prompt:**  
   *"Implement an HTML-based PDF generation service for quotes using .NET Core and Puppeteer."*  
   **Constraints:**  
   - Ensure PDF generation captures all relevant quote details cleanly.

---

## 7. **Assumptions & Constraints**

1. **Assumptions:**
   - **Part prices** can be updated but will not affect existing quotes.
   - Only one **user** will access the system at launch.

2. **Constraints:**
   - **Soft delete**: Quotes can only be archived, not deleted.
   - **Simple HTML to PDF rendering** without complex branding.

