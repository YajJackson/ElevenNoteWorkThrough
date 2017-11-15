using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElevenNote.Data
{
    [Table("Note")]
    public class NoteEntity
    {
        [Key]
        public int NoteId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedUtc { get; set; }

        public DateTime? ModifiedUtc { get; set; }

    }
}
