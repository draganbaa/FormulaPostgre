using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaPostgreSql.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICountryRepository Country { get; }

        ILocationInfoRepository LocationInfo { get; }
        ITrackInfoRepository TrackInfo { get; }
        ITeamRepository Team { get; }
        IDriverRepository Driver { get; }
        IRaceRepository Race { get; }
        IRaceResultRepository RaceResult { get; }
        IPenaltyRepository Penalty { get; }
        IQualifyingResultRepository QualifyingResult{get;}
        IImageInfoRepository ImageInfo { get; }
        void Save();
    }
}
