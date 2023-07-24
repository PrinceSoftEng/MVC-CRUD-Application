using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_CRUD_Application.Models
{
    public class clsStudentModel
    {
        [Display(Name = "ID")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Name Is Required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address Is Required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City Is Required.")]
        public string City { get; set; }
    }
}