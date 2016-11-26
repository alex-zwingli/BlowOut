using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlowOut.Models
{
    [Table("Instrument")]
    public class Instrument
    {
        [Key]
        [ReadOnly(true)]
        [HiddenInput(DisplayValue = false)]
        [DisplayName("Instrument ID")]
        public int InstrumentID { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter an instrument description")]
        [StringLength(50, ErrorMessage = "Description is too long.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please insert an instrument type: New, Used")]
        [ScaffoldColumn(true)]
        [RegularExpression(@"(NEW)|(New)|(new)|(USED)|(Used)|(used)", ErrorMessage = "Please enter \"New\" or \"Used\".")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Please enter the monthly rental price for the instrument.")]
        [DataType(DataType.Currency, ErrorMessage = "Please enter a valid currentcy.")]
        public decimal Price { get; set; }

        [DisplayName("Client ID")]
        public int? ClientID { get; set; }

    }
}