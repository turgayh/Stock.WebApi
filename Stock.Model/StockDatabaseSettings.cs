namespace Stock.Model
{
    public class StockDatabaseSettings : IStockDatabaseSettings
    {
        public string ProductCollectionName { get; set; }
        public string BasketCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IStockDatabaseSettings
    {
        string ProductCollectionName { get; set; }
        string BasketCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
