using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaPostgreSql.Models.ViewModels
{
    public class ImageVM
    {
        public ImageInfo ImageInfo { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> TeamList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> DriverList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> TrackList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CountryList { get; set; }
    }
}
 