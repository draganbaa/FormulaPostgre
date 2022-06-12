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
    public class RaceResult
    {
        public int Id { get; set; }
        [Required]   
        public int? FinalPosition { get; set; }
        public TimeSpan FastestLap { get; set; }
        public int? LapsFinished { get; set; }
        public string? RaceTime { get; set; }
        public int? PointsGained { get; set; }
        [Required]
        [Display(Name = "Driver")]
        public int DriverFk { get; set; }
        [ForeignKey("DriverFk")]
        [ValidateNever]
        public Driver Driver { get; set; }
        [Required]
        [Display(Name = "Race")]
        public int RaceFk { get; set; }
        [ForeignKey("RaceFk")]
        [ValidateNever]
        public Race Race { get; set; }
    }
}
