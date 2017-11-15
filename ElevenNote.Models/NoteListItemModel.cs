using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class NoteListItemModel
    {
        public NoteListItemModel(
            int noteId,
            string title,
            string content,
            DateTime createUtc,
            DateTime modifiedUtc
        )
        {
            NoteId = noteId;
            Title = title;
            Content = content;
            CreatedUtc = createUtc;
            ModifiedUtc = modifiedUtc;
        }

        public int NoteId { get; }

        public string Title { get; }

        public string Content { get; }

        public DateTime CreatedUtc { get; }

        public DateTime? ModifiedUtc { get; }
    }
}
