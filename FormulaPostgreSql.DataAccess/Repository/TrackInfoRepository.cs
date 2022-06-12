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
    public class TrackInfoRepository : Repository<TrackInfo>, ITrackInfoRepository
    {
        private readonly FormulaPostgreSqlContext _context;

        public TrackInfoRepository(FormulaPostgreSqlContext context) : base(context)
        {
            _context = context;
        }

        public void Update(TrackInfo obj)
        {
            _context.TrackInfos.Update(obj);

        }
    }
}
