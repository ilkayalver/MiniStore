using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniStore.WebAPI.Data.DbContexts;
using MiniStore.WebAPI.Data.Entities;

namespace MiniStore.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly MiniStoreDbContext _context;

        public CategoriesController(MiniStoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories(int? categoryId, int? parentCategoryId)
        {
            if (categoryId == null && parentCategoryId == null)
            {
                return await _context.Categories.ToListAsync();
            }
            else
            {
                return await _context.Categories.Where(c => c.Id == parentCategoryId).ToListAsync();
            }
        }

    }
}
