using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockbandData.Repository
{
    public interface IObjectContextFactory
    {
        InMemoryDatabaseObjectContext Create();
    }
}
