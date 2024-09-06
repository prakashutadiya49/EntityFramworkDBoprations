﻿using EFDBoprationAPI.Data;
using System.ComponentModel.DataAnnotations;

namespace DbOperationsWithEFCoreApp.Data
{


    /// <summary>
    /// this is a master table.
    /// </summary>
    
    public class Language
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }


        public ICollection<Book> Book { get; set; }
    }
}