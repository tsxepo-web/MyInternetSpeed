using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class NetworkSpeedDbSettings
    {
        public string ConnectionString { get; set;} = null!;
        public string DatabaseName { get; set;} = null!;
        public string UserCollectionName { get; set;} = null!;
    }
}