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
    public class DriverRepository : Repository<Driver>, IDriverRepository
    {
        private readonly FormulaPostgreSqlContext _context;

        public DriverRepository(FormulaPostgreSqlContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Driver obj)
        {
            _context.Drivers.Update(obj);

        }
    }
}
