using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apilogin.data
{
    public class MySqlConfiguration
    {
        public MySqlConfiguration(string connectionString) => ConnectionString = connectionString;
        public string ConnectionString { get; set; }
    }
}
