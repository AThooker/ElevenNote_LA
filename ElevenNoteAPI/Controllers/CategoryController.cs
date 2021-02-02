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
        public IHttpActionResult CreateCategory(CategoryCreate model)
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
        [HttpGet]
        public IHttpActionResult GetAllCategories()
        {
            var service = CreateCategoryService();
            var list = service.GetCategories();
            return Ok(list);
        }
        [HttpGet]
        public IHttpActionResult GetCategoryById(int? id)
        {
            var service = CreateCategoryService();
            var catById = service.GetCategoryById(id);
            return Ok(catById);
        }
        //UPDATE 
        [HttpPut]
        public IHttpActionResult EditCategory(CategoryDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateCategoryService();
            if (!service.UpdateCategory(model))
            {
                return InternalServerError();
            }
            return Ok("Category Updated");
        }
        //DELETE
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateCategoryService();
            if (!service.DeleteCategory(id))
            {
                return BadRequest("You are trying to delete a category that either does not exist or has notes affiliated with it.");
            }
            return Ok("Category Deleted");
        }
        //Access toService
        private CategoryService CreateCategoryService()
        {
            var categoryService = new CategoryService();
            return categoryService;
        }
    }
}
