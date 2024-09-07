using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DbOperationsWithEFCoreApp.Data
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
 
    }
}
