namespace Shared.Models;

public record InventoryUpdateMessage(
    Guid TransactionId,
    string WarehouseId,
    string SKU,
    int QuantityChange,
    DateTime Timestamp,
    int Priority // 1 = Urgent, 2 = Standard
);
