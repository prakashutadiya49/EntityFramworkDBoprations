﻿using System.ComponentModel.DataAnnotations;

namespace DbOperationsWithEFCoreApp.Data
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
    }
}