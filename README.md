# Distributed Logistics & Inventory Orchestrator

[![.NET Core](https://img.shields.io/badge/.NET%20Core-8.0-blue.svg)](https://dotnet.microsoft.com/)
[![RabbitMQ](https://img.shields.io/badge/Message%20Broker-RabbitMQ-orange.svg)](https://www.rabbitmq.com/)
[![Docker](https://img.shields.io/badge/Container-Docker-blue.svg)](https://www.docker.com/)
[![SQL Server](https://img.shields.io/badge/Database-MSSQL-red.svg)](https://www.microsoft.com/en-us/sql-server/)

## 📌 Project Overview
Developed by **Devika Shivabasappa Rudagi**, an **MS Computer Science** candidate at **San Francisco Bay University** with over **5 years of experience** in full-stack and backend development.

This project is a high-performance, event-driven microservices ecosystem designed to manage multi-warehouse inventory tracking and order fulfillment. It serves as a technical validation of professional expertise in building **enterprise monitoring applications** and **scalable inventory platforms**. The system is engineered to handle high-volume data pipelines, reflecting real-world requirements for speed, reliability, and quality

## 🏗️ System Architecture
The orchestrator leverages **Distributed Systems** concepts and **Microservices** architecture:

1.  **Ingestion Layer (Producer):** A **RESTful API** built with **ASP.NET Core** and **C#**. It acts as a secure gateway for incoming inventory updates, featuring structured JSON handling and validation.
2.  **Messaging Layer (Broker):** Utilizes **RabbitMQ** to decouple services. This asynchronous pipeline is designed to reduce system response latency, a technique previously used to achieve a **20% latency reduction** in enterprise environments.
3.  **Optimization Layer (Consumer):** A background worker service that processes messages using **asynchronous threading** and **batch processing** to handle concurrent large-scale transactions.



## 🛠️ Technical Features & Skills Validation

### 1. Event-Driven Decoupling
* **Implementation**: Developed asynchronous messaging pipelines using **RabbitMQ** and **SignalR**.
* **Impact**: Ensures the system remains responsive under heavy loads by offloading intensive processing from the main API thread.

### 2. High-Performance Matching Engine
* **Logic**: Implemented a **Priority Queue-based matching engine** for concurrent transactions.
* **Optimization**: Built on the logic used during the **Prologis University Challenge** for multi-warehouse tracking optimization.

### 3. Database & SQL Optimization
* **Schema Design**: Optimized **MSSQL** schemas and indexing strategies.
* **Performance**: Targets a **30% improvement in query performance**, replicating optimizations delivered in professional inventory platforms.

### 4. DevOps & Resilience
* **Containerization**: Fully containerized using **Docker** for seamless deployment across environments.
* **CI/CD**: Integrated with **GitHub Actions** to maintain high release velocity.

## 💻 Tech Stack
* **Languages**: C#, SQL, JavaScript.
* **Frameworks**: .NET Core, ASP.NET Core Web API, MVC.
* **Databases**: MSSQL, MySQL.
* **DevOps/Tools**: Docker, RabbitMQ, Git, Jenkins, Postman, Swagger.
* **Testing**: Cypress (E2E), NUnit.

## 🚀 Getting Started

### Prerequisites
* **Docker Desktop**
* **.NET 8.0 SDK**

### Installation & Setup
1.  **Clone the repository**:
    ```bash
    git clone [https://github.com/devika-rudagi/Logistics-Orchestrator.git](https://github.com/devika-rudagi/Logistics-Orchestrator.git)
    cd Logistics-Orchestrator
    ```
2.  **Launch Infrastructure**:
    ```bash
    docker-compose up -d
    ```
    *This initializes RabbitMQ, SQL Server, and the microservices containers.*
3.  **Verify Services**:
    * **Swagger API**: `http://localhost:5001/swagger`.
    * **RabbitMQ Management**: `http://localhost:15672` (Default: guest/guest).

## 📊 Database Schema Highlights
The **MSSQL** implementation includes optimized indexes for real-time warehouse analytics:
```sql
-- High-priority index for urgent tracking updates
CREATE INDEX IX_Inventory_Priority ON InventoryLogs (Priority) 
WHERE Priority = 1;

-- Composite index for warehouse-specific SKU lookups
CREATE INDEX IX_Inventory_WarehouseSKU 
ON InventoryLogs (WarehouseId, SKU) INCLUDE (QuantityChange);
