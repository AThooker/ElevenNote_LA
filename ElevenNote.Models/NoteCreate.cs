using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class NoteCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Title must be longer than 2 characters")]
        public string Title { get; set; }
        [MaxLength(10000, ErrorMessage = "Note is too long")]
        public string Content { get; set; }
        public int? CategoryId { get; set; }
    }
}
