using Magic_Shop.Models.Domain;
using Magic_Shop.Models.DTO.Product;
using Magic_Shop.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Magic_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductRequestDto request)
        {
            // Convert Dto to Domain
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                Quantity = request.Quantity,
                Desp = request.Desp,
                PublishedDate = request.PublishedDate,
                ExpiredDate = request.ExpiredDate
            };

            product = await productRepository.CreateAsync(product);

            // Convert Domain to Dto
            var response = new ProductDto
            {
                ID = product.ID,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                Desp = product.Desp,
                PublishedDate = product.PublishedDate,
                ExpiredDate = product.ExpiredDate
            };

            return Ok(response);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await productRepository.GetAllAsync();

            // Convert Domain to Dto
            var response = new List<ProductDto>();
            foreach (var product in products)
            {
                response.Add(new ProductDto
                {
                    ID = product.ID,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    Desp = product.Desp,
                    PublishedDate = product.PublishedDate,
                    ExpiredDate = product.ExpiredDate
                });
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{productID:int}")]
        public async Task<IActionResult> GetProductByID([FromRoute] int productID)
        {
            var existingProduct = await productRepository.GetByIdAsync(productID);
            if (existingProduct == null)
            {
                return NotFound();
            }

            //Map Domain to Dto
            var response = new ProductDto
            {
                ID = existingProduct.ID,
                Name = existingProduct.Name,
                Price = existingProduct.Price,
                Quantity = existingProduct.Quantity,
                Desp = existingProduct.Desp,
                PublishedDate = existingProduct.PublishedDate,
                ExpiredDate = existingProduct.ExpiredDate
            };

            return Ok(response);
        }

        [HttpPut]
        [Route("{productID:int}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int productID, UpdateProductRequestDto request)
        {
            // Convert Dto to Domain
            var product = new Product
            {
                ID = productID,
                Name = request.Name,
                Price = request.Price,
                Quantity = request.Quantity,
                Desp = request.Desp,
                PublishedDate = request.PublishedDate,
                ExpiredDate = request.ExpiredDate
            };

            var updatedProduct = await productRepository.UpdateAsync(product);
            if (updatedProduct == null)
            {
                return NotFound();
            }

            // Convert Domain to Dto
            var response = new ProductDto
            {
                ID = updatedProduct.ID,
                Name = updatedProduct.Name,
                Price = updatedProduct.Price,
                Quantity = updatedProduct.Quantity,
                Desp = updatedProduct.Desp,
                PublishedDate = updatedProduct.PublishedDate,
                ExpiredDate = updatedProduct.ExpiredDate
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("{productID:int}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int productID)
        {
            var deletedProduct = await productRepository.DeleteAsync(productID);
            if (deletedProduct == null)
            {
                return NotFound();
            }

            // Convert Domain to Dto
            var response = new ProductDto
            {
                ID = deletedProduct.ID,
                Name = deletedProduct.Name,
                Price = deletedProduct.Price,
                Quantity = deletedProduct.Quantity,
                Desp = deletedProduct.Desp,
                PublishedDate = deletedProduct.PublishedDate,
                ExpiredDate = deletedProduct.ExpiredDate
            };

            return Ok(response);
        }
    }
}
