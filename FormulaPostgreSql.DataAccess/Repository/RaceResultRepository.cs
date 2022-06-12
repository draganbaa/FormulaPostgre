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
    public class RaceResultRepository : Repository<RaceResult>, IRaceResultRepository
    {
        private readonly FormulaPostgreSqlContext _context;

        public RaceResultRepository(FormulaPostgreSqlContext context) : base(context)
        {
            _context = context;
        }

        public void Update(RaceResult raceResult)
        {
            _context.RaceResults.Update(raceResult);

        }
    }
}
