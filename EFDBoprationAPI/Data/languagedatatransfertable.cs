using System.ComponentModel.DataAnnotations;

namespace EFDBoprationAPI.Data
{
    public class languagedatatransfertable
    {
        [Key]
        public int languageid { get; set; }

        [Required]
        [MaxLength(50)]
        public string languagename {  get; set; }
    }
}
