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
    public class CategoryController : ApiController
    {
        //POST
        [HttpPost]
        public IHttpActionResult Post(CategoryCreate model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateCategoryService();
            if(!service.CreateCategory(model))
            {
                return InternalServerError();
            }
            return Ok();
        }
        //GET ALL
        public IHttpActionResult GetAllCategories()
        {
            var service = CreateCategoryService();
            var list = service.GetCategories();
            return Ok(list);
        }
        //Access toService
        public CategoryService CreateCategoryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var categoryService = new CategoryService();
            return categoryService;
        }
    }
}
