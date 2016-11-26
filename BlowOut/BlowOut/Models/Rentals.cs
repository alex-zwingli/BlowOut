using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlowOut.Models
{
    public class Rentals
    {
        // Instrument Data

        [Key]
        [ReadOnly(true)]
        [DisplayName("Instrument ID")]
        public int? InstrumentID { get; set; }

        [DataType(DataType.Text)]
        [ReadOnly(true)]
        [StringLength(50, ErrorMessage = "Description is too long.")]
        public string Description { get; set; }

        [ScaffoldColumn(true)]
        [ReadOnly(true)]
        [RegularExpression(@"(NEW)|(New)|(new)|(USED)|(Used)|(used)", ErrorMessage = "Please enter \"New\" or \"Used\".")]
        public string Type { get; set; }

        [DataType(DataType.Currency, ErrorMessage = "Please enter a valid currentcy.")]
        [ReadOnly(true)]
        public decimal Price { get; set; }

        [DisplayName("Client ID")]
        public int? ClientID { get; set; }

        // Client data

        //Each field is required
        [Required(ErrorMessage = "Please enter a first name.")]
        [DisplayName("First Name")]
        [StringLength(30, ErrorMessage = "This name is too long.")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        [DisplayName("Last Name")]
        [StringLength(30, ErrorMessage = "This name is too long.")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter an address.")]
        [StringLength(50, ErrorMessage = "This address is too long.")]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter a city.")]
        [StringLength(30, ErrorMessage = "This city name is too long.")]
        [DataType(DataType.Text)]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a state.")]
        [StringLength(2, ErrorMessage = "Please provide two letter state abbreviation.")]
        [DataType(DataType.Text)]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter a ZIP.")]
        [StringLength(5, ErrorMessage = "Please enter a valid 5 digit ZIP code.")]
        [DataType(DataType.PostalCode)]
        public string ZIP { get; set; }

        [Required(ErrorMessage = "Please enter an email: name@example.com.")]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "The provided email is too long.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a phone number: (000) 000-0000.")]
        [Phone]
        [RegularExpression(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}", ErrorMessage = "Please enter a valid phone number: (000) 000-0000")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }



    }
}