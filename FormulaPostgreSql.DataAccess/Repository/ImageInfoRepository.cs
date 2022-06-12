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
    public class ImageInfoRepository : Repository<ImageInfo>, IImageInfoRepository
    {
        private readonly FormulaPostgreSqlContext _context;

        public ImageInfoRepository(FormulaPostgreSqlContext context) : base(context)
        {
            _context = context;
        }

        public void Update(ImageInfo imageInfo)
        {
            _context.ImageInfos.Update(imageInfo);

        }
    }
}
