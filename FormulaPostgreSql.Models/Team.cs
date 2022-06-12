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
    public class Team
    {
        public int Id { get; set; }
        [Required]
        public string TeamName { get; set; }
        public string TeamChief { get; set; }
        public string Chassis { get; set; }
        public string PowerUnit { get; set; }
        [Required]
        [Display(Name = "Team Country")]
        public int CountryFk { get; set; }
        [ForeignKey("CountryFk")]
        [ValidateNever]
        public Country Country { get; set; }

        [Required]
        [Display(Name = "Team Location")]
        public int LocationFk { get; set; }
        [ForeignKey("LocationFk")]
        [ValidateNever]
        public LocationInfo LocationInfo { get; set; }
    }
}
