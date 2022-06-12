using FormulaPostgreSql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaPostgreSql.DataAccess.Repository.IRepository
{
    public interface ILocationInfoRepository : IRepository<LocationInfo>
    {
        void Update(LocationInfo locationInfo);
    }
}
