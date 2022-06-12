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
    public class Penalty
    {
        public int Id { get; set; }
        public string? Penaltydetails { get; set; }
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
