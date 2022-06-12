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
    public class Race
    {
        public int Id { get; set; }
        [Required]
        public string RaceName { get; set; }
        [Required]
        public int RaceRound { get; set; }  
        public DateTime RaceStartDate { get; set; }
        [Required]
        public int RaceLaps { get; set; }
        public decimal RaceLength { get; set; }
        [Required]
        public bool IsSprintQualifying { get; set; }
        [Required]
        [Display(Name = "Track")]
        public int TrackFk { get; set; }
        [ForeignKey("TrackFk")]
        [ValidateNever]
        public TrackInfo TrackInfo { get; set; }
    }
}
