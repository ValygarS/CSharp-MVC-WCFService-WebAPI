using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPIService.ServiceLayer
{
    public class TeaMetaData
    {
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression("^[0-9]{1,}$", ErrorMessage = "Only digits 0-9 allowed")]
        public short Qty { get; set; }

        [Required]
        [RegularExpression(@"^\b[0-9]*\.*[0-9]+\b$", ErrorMessage = "Should be integer or float")]
        public double Price { get; set; }

        [Required]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Year should have 4 numbers")]
        public string Year { get; set; }
    }
}