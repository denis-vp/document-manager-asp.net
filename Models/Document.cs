using System.ComponentModel.DataAnnotations;

namespace document_manager_asp.net.Models
{
    public class Document
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 1)]
        public string Author { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int NumPages { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 1)]
        public string Type { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 1)]
        public string Format { get; set; }

        public Document()
        {
        }
    }
}
