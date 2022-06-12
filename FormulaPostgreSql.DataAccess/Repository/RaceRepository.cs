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
    public class RaceRepository : Repository<Race>, IRaceRepository
    {
        private readonly FormulaPostgreSqlContext _context;

        public RaceRepository(FormulaPostgreSqlContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Race race)
        {
            _context.Races.Update(race);

        }
    }
}
