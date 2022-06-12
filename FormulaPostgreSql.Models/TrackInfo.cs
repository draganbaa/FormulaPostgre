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
    public class TrackInfo
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Track Name")]
        public string Trackname { get; set; } = null!;
        public int Turns { get; set; }
        [Display(Name = "Track Length")]
        public decimal Tracklength { get; set; }
        [Required]
        [Display(Name = "Location")]
        public int LocationFk { get; set; }
        [ForeignKey("LocationFk")]
        [ValidateNever]
        public LocationInfo LocationInfo { get; set; }
    }
}
