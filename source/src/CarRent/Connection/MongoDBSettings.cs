using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

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
