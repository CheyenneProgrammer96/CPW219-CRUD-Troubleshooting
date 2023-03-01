﻿using System.ComponentModel.DataAnnotations;

namespace CPW219_CRUD_Troubleshooting.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [StringLength(35)]
        public string Name { get; set; } = null!;

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
