using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaPostgreSql.Models
{
    public class ImageInfo
    {
        public int Id { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public string? ImageDescription { get; set; }
        public int TeamFk { get; set; }
        [ForeignKey("TeamFk")]
        [ValidateNever]
        public Team Team { get; set; }

        [Display(Name = "Driver")]
        public int DriverFk { get; set; }
        [ForeignKey("DriverFk")]
        [ValidateNever]
        public Driver Driver { get; set; }

        [Display(Name = "Track")]
        public int TrackFk { get; set; }
        [ForeignKey("TrackFk")]
        [ValidateNever]
        public TrackInfo TrackInfo { get; set; }

        [Display(Name = "Country")]
        public int CountryFk { get; set; }
        [ForeignKey("CountryFk")]
        [ValidateNever]
        public Country Country { get; set; }

    }
}
