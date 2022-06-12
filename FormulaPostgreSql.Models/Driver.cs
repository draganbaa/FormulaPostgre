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
    public class Driver
    {
        public int Id { get; set; }
        [Required]
        public string DriverName { get; set; }
        [Required]
        public int DriverNumber { get; set; }
        [Required]
        public int CountryFk { get; set; }
        [ForeignKey("CountryFk")]
        [ValidateNever]
        public Country Country { get; set; }
        [Required]
        public int TeamFk { get; set; }
        [ForeignKey("TeamFk")]
        [ValidateNever]
        public Team Team { get; set; }
    }
}
