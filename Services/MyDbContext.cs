using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MyDbContext : DbContext
    {
        public MyDbContext(string connectNameOrConnectString) : base(connectNameOrConnectString)
        {
        }


        public DbSet<DeviceInfoRelation> DeviceInfoRelations { get; set; }
    }
}
