using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductWebAPI.DAL;
using ProductWebAPI.Models;

namespace ProductWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly string _connectionString;

        private readonly ProductDbContext _context;
        public ProductController(ProductDbContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        [HttpGet]
       // [Authorize]
        public IActionResult Get()
        {

            var repository = new DapperGetProducts(_connectionString);
            var products = repository.GetProducts();
            return Ok(products);   
            //try
            //{
            //    var products = _context.Products.ToList();
            //    if (products.Count == 0)
            //    {
            //        return NotFound("No data Found..");
            //    }
            //    return Ok(products);
            //}
            //catch (Exception ex)
            //{

            //    return BadRequest(ex.Message);
            //}
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var product = _context.Products.Find(id);
                if (product == null)
                {
                    return NotFound($"Product not found with id {id}");
                }
                return Ok(product);
            }

            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Post(Product model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();

                return Ok("Product Created");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Put(Product model)
        {
            if (model == null || model.Id == 0)
            {
                if (model == null)
                {
                    return BadRequest("Model data is invalid");
                }
                if (model.Id == 0)
                {
                    return BadRequest($"Product Id {model.Id} is invalid");
                }
            }
            try
            {
                var product = _context.Products.Find(model.Id);
                if (product == null)
                {
                    return BadRequest("");
                }
                product.ProductName = model.ProductName;
                product.Price = model.Price;
                product.Qty = model.Qty;
                _context.SaveChanges();

                return Ok("Product details updated..");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var product = _context.Products.Find(id);
                if (product == null)
                {
                    return NotFound($"Product is not found with id {id}");
                }
                _context.Products.Remove(product);
                _context.SaveChanges();
                return Ok("Product deleted..");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
