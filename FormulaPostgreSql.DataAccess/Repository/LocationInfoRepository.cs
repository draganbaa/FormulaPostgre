using FormulaPostgreSql.Data;
using FormulaPostgreSql.DataAccess.Repository.IRepository;
using FormulaPostgreSql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaPostgreSql.DataAccess.Repository
{
    public class LocationInfoRepository : Repository<LocationInfo>, ILocationInfoRepository
    {
        private readonly FormulaPostgreSqlContext _context;

        public LocationInfoRepository(FormulaPostgreSqlContext context) : base(context)
        {
            _context = context;
        }

        public void Update(LocationInfo obj)
        {
            _context.LocationInfos.Update(obj);

        }
    }
}
