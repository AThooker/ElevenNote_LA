using ElevenNote.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _ctx = new ApplicationDbContext();

        private readonly Guid _userId;

        public CategoryService(Guid userId)
        {
            _userId = userId;
        }

    }
}
