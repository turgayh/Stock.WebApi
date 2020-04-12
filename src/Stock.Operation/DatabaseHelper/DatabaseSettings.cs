namespace Stock.Operation.DatabaseHelper
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ProductCollectionName { get; set; }
        public string CustomerCollectionName { get; set; }
        public string BasketCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDatabaseSettings
    {
        string ProductCollectionName { get; set; }
        string CustomerCollectionName { get; set; }
        string BasketCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
