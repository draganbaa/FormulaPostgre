using System.ComponentModel.DataAnnotations;

namespace FormulaPostgreSql.Models
{
    public class Country
    {
        public int Id { get; set; }
        [Display(Name = "Country Name")]
        public string Countryname { get; set; } = null!;
        [Display(Name = "Country Abbreviation")]
        public string Countryabbreviation { get; set; } = null!;
    }
}
