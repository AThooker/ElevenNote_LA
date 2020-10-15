using ElevenNote.Data;
using ElevenNote.Models;
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

        public bool CreateCategory(CategoryCreate model)
        {
            Category category = new Category()
            {
                Name = model.Name
            };
            _ctx.Categories.Add(category);
            return _ctx.SaveChanges() == 1;
        }

        public IEnumerable<CategoryListItem> GetCategories()
        {
            var list = _ctx.Categories.Select(
                p => new CategoryListItem
                {
                    CategoryId = p.CategoryId,
                    Name = p.Name
                });
            return list.ToArray();
        }

    }
}
