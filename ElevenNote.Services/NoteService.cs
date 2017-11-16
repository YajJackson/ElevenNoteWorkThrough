﻿using ElevenNote.Data;
using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class NoteService
    {
        private readonly Guid _userId;
        
        public NoteService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<NoteListItemModel> GetNotes()
        {
            using (var ctx = new ElevenNoteDbContext())
            {
                return ctx
                        .Notes
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new NoteListItemModel
                                {
                                   NoteId = e.NoteId,
                                    Title = e.Title,
                                    CreatedUtc = e.CreatedUtc,
                                    ModifiedUtc = e.ModifiedUtc
                                }
                        ).ToArray();
            }
        }

        public bool CreateNote(NoteCreateModel model)
        {
            using (var ctx = new ElevenNoteDbContext())
            {
                var entity =
                    new NoteEntity
                    {
                        UserId = _userId,
                        Title = model.Title,
                        Content = model.Content,
                        CreatedUtc = DateTime.UtcNow
                    };

                ctx.Notes.Add(entity);

                return ctx.SaveChanges() == 1;
                
            }
        }

        public NoteDetailModel GetNoteById(int id)
        {
            using (var ctx = new ElevenNoteDbContext())
            {
               NoteEntity entity =
                    ctx
                        .Notes
                        .SingleOrDefault(e => e.NoteId == id && e.UserId == _userId);

                if (entity == null) return new NoteDetailModel();

                return
                    new NoteDetailModel
                    {
                        NoteId = entity.NoteId,
                        Title = entity.Title,
                        Content = entity.Content,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool updateNote(NoteEditModel model)
        {
            using (var ctx = new ElevenNoteDbContext())
            {
                NoteEntity entity =
                    ctx
                        .Notes
                        .SingleOrDefault(e => e.NoteId == model.NoteId && e.UserId == _userId);

                if (entity == null) return false;

                entity.Title = model.Title;
                entity.Content = model.Content;
                entity.ModifiedUtc = DateTime.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
