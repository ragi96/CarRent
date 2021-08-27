namespace CarRent.Connection
{
    public interface IMongoDbSettings
    {
        string DatabaseName { get; set; }
        string HostAddress { get; set; }
        int Port { get; set; }
    }
}