using System.Diagnostics.CodeAnalysis;

namespace CarRent.Connection
{
    [ExcludeFromCodeCoverage]
    public class MongoDbSettings : IMongoDbSettings
    {
        public string DatabaseName { get; set; }
        public string HostAddress { get; set; }

        public int Port { get; set; }
    }
}