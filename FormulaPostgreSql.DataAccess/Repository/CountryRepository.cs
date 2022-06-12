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
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        private readonly FormulaPostgreSqlContext _context;

        public CountryRepository(FormulaPostgreSqlContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Country country)
        {
            _context.Country.Update(country);

        }
    }
}
