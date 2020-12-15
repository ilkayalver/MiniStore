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
    public class ProductsController : ControllerBase
    {
        private readonly MiniStoreDbContext _context;

        public ProductsController(MiniStoreDbContext context)
        {
            _context = context;
        }


        [HttpGet("GetProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(int? categoryId)
        {
            if (categoryId == null)
            {
                return await _context.Products.ToListAsync();
            }
            else
            {
                return await _context.Products.Where(x => x.CategoryId == categoryId).ToListAsync();
            }
        }

        [HttpGet("GetDefaultProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> GetDefaultProducts()
        {
            var firstSubCategoryId = _context.Categories.Where(c => c.ParentCategoryId != null).First().Id;
            return await _context.Products.Where(p => p.CategoryId == firstSubCategoryId).ToListAsync();
        }
    }
}
