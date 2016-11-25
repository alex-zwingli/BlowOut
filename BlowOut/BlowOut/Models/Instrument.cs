using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AwesomeInstrumentCompany.Models
{
    [Table("Instrument")]
    public class Instrument
    {
        [Key]
        [ReadOnly(true)]
        [DisplayName("Instrument ID")]
        public int InstrumentID { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter an instrument description")]
        [StringLength(50, ErrorMessage = "Description is too long.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please insert an instrument type: N = New, U = Used")]
        [RegularExpression(@"[nu]{1,1}")]
        public char Type { get; set; }

        [Required(ErrorMessage = "Please enter the monthly rental price for the instrument.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DisplayName("Client ID")]
        public int? ClientID { get; set; }

    }
}