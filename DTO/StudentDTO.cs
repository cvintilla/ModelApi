using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class StudentDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is a required field.", AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Courses are a required field.", AllowEmptyStrings = false)]
        public string Course { get; set; }

        [Required(ErrorMessage = "GPA is a required field.", AllowEmptyStrings = false)]
        public double GPA { get; set; }
    }
}
