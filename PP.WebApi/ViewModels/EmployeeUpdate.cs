using PP.DAL.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace PP.WebApi.ViewModels
{
    public class EmployeeUpdate
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        public string Surname { get; set; }

        [Required]
        [Range(1, 3)]
        public EmployeeRole Role { get; set; }

        [Required]
        [MinLength(2)]
        public string Office { get; set; }
    }
}
