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
    public class PenaltyRepository : Repository<Penalty>, IPenaltyRepository
    {
        private readonly FormulaPostgreSqlContext _context;

        public PenaltyRepository(FormulaPostgreSqlContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Penalty penalty)
        {
            _context.Penalties.Update(penalty);

        }
    }
}
