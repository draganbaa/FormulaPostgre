﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaPostgreSql.Models.ViewModels
{
    public class PenaltyVM
    {
        public Penalty Penalty{ get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> DriverList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> RaceList { get; set; }
    }
}
 