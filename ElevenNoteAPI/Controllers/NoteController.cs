using ElevenNote.Models;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElevenNoteAPI.Controllers
{
    [Authorize]
    public class NoteController : ApiController
    {
        //CREATE
        [HttpPost]
        public IHttpActionResult CreateNote(NoteCreate model)
        {
            if (!ModelState.IsValid)
            return BadRequest(ModelState);

            var service = CreateNoteService();

            if(!service.CreateNote(model))
            {
                return InternalServerError();
            }
            return Ok();
        }
        //READ
        [HttpGet]
        public IHttpActionResult GetAllNotes()
        {
            NoteService service = CreateNoteService();
            var notes = service.GetNotes();
            return Ok(notes);
        }
        //READ
        [HttpGet]
        public IHttpActionResult GetNoteById(int id)
        {
            NoteService service = CreateNoteService();
            var note = service.GetNoteById(id);
            return Ok(note);
        }
        //UPDATE 
        [HttpPut]
        public IHttpActionResult PutNote(NoteEdit model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateNoteService();
            if(!service.UpdateNote(model))
            {
                return InternalServerError();
            }
            return Ok();
        }
        //DELETE
        public IHttpActionResult Delete(int id)
        {
            var service = CreateNoteService();
            if(!service.DeleteNote(id))
            {
                return InternalServerError();
            }
            return Ok("Note Deleted");
        }
        private NoteService CreateNoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new NoteService(userId);
            return noteService;
        }
    }
}
