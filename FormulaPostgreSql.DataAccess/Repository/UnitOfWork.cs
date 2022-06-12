using FormulaPostgreSql.Data;
using FormulaPostgreSql.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaPostgreSql.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FormulaPostgreSqlContext _context;

        public UnitOfWork(FormulaPostgreSqlContext context)
        {
            _context = context;
            Country = new CountryRepository(_context);
            LocationInfo = new LocationInfoRepository(_context);
            TrackInfo = new TrackInfoRepository(_context);
            Team = new TeamRepository(_context);
            Driver = new DriverRepository(_context);
            Race = new RaceRepository(_context);
            RaceResult = new RaceResultRepository(_context);
            Penalty = new PenaltyRepository(_context);
            QualifyingResult = new QualifyingResultRepository(_context);
            ImageInfo = new ImageInfoRepository(_context);
        }


        public ICountryRepository Country { get; private set; }
        public ILocationInfoRepository LocationInfo { get; private set; }
        public ITrackInfoRepository TrackInfo { get; private set; }
        public ITeamRepository Team { get; private set; }
        public IDriverRepository Driver { get; private set; }
        public IRaceRepository Race { get; private set; }
        public IRaceResultRepository RaceResult { get; private set; }
        public IPenaltyRepository Penalty { get; private set; }
        public IQualifyingResultRepository QualifyingResult { get; private set; }
        public IImageInfoRepository ImageInfo { get; private set; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
