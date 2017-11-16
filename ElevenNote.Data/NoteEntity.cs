using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

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

        [DefaultValue(false)]
        public bool IsStarred { get; set; }

        [Required]
        public DateTime CreatedUtc { get; set; }

        public DateTime? ModifiedUtc { get; set; }

    }
}
