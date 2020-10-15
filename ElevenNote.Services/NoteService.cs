using ElevenNote.Data;
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
        private readonly ApplicationDbContext _ctx = new ApplicationDbContext();

        private readonly Guid _userId;
        public NoteService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateNote(NoteCreate model)
        {
            Note entity = new Note()
            {
                OwnerId = _userId,
                Title = model.Title,
                Content = model.Content,
                CreatedUtc = DateTimeOffset.Now
            };
                _ctx.Notes.Add(entity);
                return _ctx.SaveChanges() == 1;
        }

        public IEnumerable<NoteListItem> GetNotes()
        {
            IQueryable<NoteListItem> query = _ctx.Notes.Where(p => p.OwnerId == _userId).Select(
                p => new NoteListItem
                {
                    NoteId = p.NoteId,
                    Title = p.Title,
                    CreatedUtc = p.CreatedUtc
                });
            return query.ToArray();
        }
        public NoteDetail GetNoteById(int id)
        {
            var note = _ctx.Notes.Single(p => p.NoteId == id && p.OwnerId == _userId);
            return new NoteDetail
            {
                NoteId = note.NoteId,
                Title = note.Title,
                Content = note.Content,
                CreatedUtc = note.CreatedUtc,
                ModifiedUtc = note.ModifiedUtc
            };
        }
        public bool UpdateNote(NoteEdit model)
        {
            var note = _ctx.Notes.Single(p => p.NoteId == model.NoteId && p.OwnerId == _userId);

            note.Title = model.Title;
            note.Content = model.Content;
            note.ModifiedUtc = DateTimeOffset.UtcNow;

            return _ctx.SaveChanges() == 1;
        }
        public bool DeleteNote(int id)
        {
            var note = _ctx.Notes.Single(p => p.NoteId == id && p.OwnerId == _userId);
            _ctx.Notes.Remove(note);
            return _ctx.SaveChanges() == 1;
        }
    }
}
