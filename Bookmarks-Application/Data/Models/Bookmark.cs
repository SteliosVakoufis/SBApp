using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookmarks_Application.Data.Models
{
    [Table("Bookmarks")]
    public class Bookmark
    {
        [Key]
        [Column("bookmark_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MinLength(4), MaxLength(125)]
        [Column("bookmark_title")]
        public string Title { get; set; }

        [Required]
        [MinLength(3), MaxLength(500)]
        [Column("bookmark_description")]
        public string Description { get; set; }

        [Required]
        [MinLength(5), MaxLength(255)]
        [Column("bookmark_url")]
        public string Url { get; set; }
    }
}
