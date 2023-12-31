﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Employee_Dept_CRUD.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public Double Salary { get; set; }
        [Required]
        public string? Imageurl { get; set; }
        [Required]
        [Display(Name = "Dept Name")]
        public int Did { get; set; }
        [Required]
        [Display(Name = "Dept Name")]
        public string Dname { get; set; }

    }
}
