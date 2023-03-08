using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Domain.Models;
using Supermarket.Domain.Services;
using Supermarket.Extensions;
using Supermarket.Resources;

namespace Supermarket.Controllers
{
    [Route("/api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductResource>> ListAsync()
        {
            var products = await _productService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProductResource resource)
        {
            // Check if modelstate is valid based on data annotations in SaveProductResource
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            // Map new resource to the model
            var product = _mapper.Map<SaveProductResource, Product>(resource);

            // Save the new product
            var result = await _productService.SaveAsync(product);

            if (!result.Success)
                return BadRequest(result.Message);

            var productResponse = _mapper.Map<Product, ProductResource>(result.Product);
            return Ok(productResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProductResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var product = _mapper.Map<SaveProductResource, Product>(resource);
            var result = await _productService.UpdateAsync(id, product);

            if (!result.Success)
                return BadRequest(result.Message);

            var productResponse = _mapper.Map<Product, ProductResource>(result.Product);
            return Ok(productResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _productService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var productResponse = _mapper.Map<Product, ProductResource>(result.Product);
            return Ok(productResponse);
        }
    }
}