using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Ead2Ca1Template.Models
{
    public class Generic
    {

        public int ID { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }

        [Range(0, 100, ErrorMessage = "Invalid Age")]
        public int Age { get; set; }

        [Range(0, 100000, ErrorMessage = "Invalid Salary")]
        public double Salary { get; set; }


    }
}