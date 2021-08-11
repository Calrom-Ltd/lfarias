using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_projTraining.Services
{
    public class User
    {
        //primary key
        [Required]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Required Email")]
        [MaxLength (100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Required Password")]
        public string Password { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Required first name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Required last name")]
        public string LastName { get; set; }
    }
}