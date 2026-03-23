using Brasserie.Model.Restaurant.Catering;
using Brasserie.Model.Restaurant.Design;
using Brasserie.Model.Restaurant.People;
using Brasserie.Utilities.DataAccess.Files;
using Brasserie.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.Utilities.DataAccess
{
    public class DataAccessJsonFile : DataAccess, IDataAccess
    {
        public DataAccessJsonFile(string filePath) : base(filePath)
        {
        }

        public DataAccessJsonFile(DataFilesManager dfm) : base(dfm)
        {
        }

        public DataAccessJsonFile(string filePath, string[] extensions) : base(filePath, extensions)
        {
        }

        public override CustomersCollection GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public override ItemsCollection GetAllItems()
        {
            throw new NotImplementedException();
        }

        public override StaffMembersCollection GetAllStaffMembers()
        {
            throw new NotImplementedException();
        }

        public override TablesCollection GetTables()
        {
            throw new NotImplementedException();
        }

        public override bool UpdateAllItems(ItemsCollection items)
        {
            throw new NotImplementedException();
        }
    }
}
