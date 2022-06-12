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
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        private readonly FormulaPostgreSqlContext _context;

        public TeamRepository(FormulaPostgreSqlContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Team team)
        {
            _context.Teams.Update(team);

        }
    }
}
