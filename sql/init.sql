CREATE DATABASE LogisticsDB;
GO
USE LogisticsDB;

CREATE TABLE InventoryLogs (
    LogId UNIQUEIDENTIFIER PRIMARY KEY,
    WarehouseId VARCHAR(50) NOT NULL,
    SKU VARCHAR(50) NOT NULL,
    QuantityChange INT NOT NULL,
    ProcessedAt DATETIME DEFAULT GETDATE(),
    Priority INT
);

-- Optimized Indexing for frequently queried analytics 
CREATE INDEX IX_Inventory_WarehouseSKU ON InventoryLogs (WarehouseId, SKU) INCLUDE (QuantityChange);
CREATE INDEX IX_Inventory_Priority ON InventoryLogs (Priority) WHERE Priority = 1;
