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
    public class QualifyingResultRepository : Repository<QualifyingResult>, IQualifyingResultRepository
    {
        private readonly FormulaPostgreSqlContext _context;

        public QualifyingResultRepository(FormulaPostgreSqlContext context) : base(context)
        {
            _context = context;
        }

        public void Update(QualifyingResult qualifyingResult)
        {
            _context.QualifyingResults.Update(qualifyingResult);

        }
    }
}
