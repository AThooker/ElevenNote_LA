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
                    CategoryId = (int)p.CategoryId,
                    Name = p.Name
                });
            return list.ToArray();
        }
        public CategoryDetail GetCategoryById(int? id)
        {
            var category = _ctx.Categories.Single(c => c.CategoryId == id);
            return new CategoryDetail
            {
                CategoryId = category.CategoryId,
                Name = category.Name
            };
        }
        public bool UpdateCategory(CategoryDetail model)
        {
            var category = _ctx.Categories.Single(p => p.CategoryId == model.CategoryId);

            category.CategoryId = model.CategoryId;
            category.Name = model.Name;
            return _ctx.SaveChanges() == 1;
        }
        public bool DeleteCategory(int id)
        {
            var category = _ctx.Categories.Single(c => c.CategoryId == id);
            _ctx.Categories.Remove(category);
            return _ctx.SaveChanges() == 1;
        }
    }
}
