using Azure;
using Azure.Data.Tables;

namespace ABC_RetailApp.Models
{
   

    public class CustomerProduct : ITableEntity
    {
        public string PartitionKey { get; set; } = "Customer"; // Can be same for all
        public string RowKey { get; set; } = Guid.NewGuid().ToString(); // Unique identifier
        public string Name { get; set; }
        public string Product { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }

}
