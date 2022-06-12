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
    public class LocationInfo
    {
        public int Id { get; set; }
        [Display(Name = "Location Name")]
        [Required]
        public string? Locationname { get; set; }

        [Required]
        [Display(Name = "Country")]
        public int CountryFk { get; set; }
        [ForeignKey("CountryFk")]
        [ValidateNever]
        public Country Country { get; set; }
    }
}
