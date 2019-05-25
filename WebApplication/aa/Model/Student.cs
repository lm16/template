using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Model
{
    public class Student
    {

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }


        public Gender Gender { get; set; }
    }
}
