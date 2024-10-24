using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamilaFattakhova321_Pets.DbConnection;

namespace KamilaFattakhova321_Pets.Data
{
    internal class DataBaseManager
    {
        public static KamilaFattakhova321_PetsEntities DataBaseConnection = new KamilaFattakhova321_PetsEntities();
    }
}
