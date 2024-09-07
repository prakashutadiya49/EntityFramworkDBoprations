using System.ComponentModel.DataAnnotations;

namespace DbOperationsWithEFCoreApp.Data
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        [MaxLength(20)]
        public int NoOfPages { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }


        public int LanguageId { get; set; }

        [Required]
        //public int? AuthorId { get; set; }

        public Language? Language { get; set; }
        //public Author? Author { get; set; }
    }
}