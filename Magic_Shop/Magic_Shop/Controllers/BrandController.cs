﻿using Magic_Shop.Models.Domain;
using Magic_Shop.Models.DTO.Brand;
using Magic_Shop.Repositories.Implementation;
using Magic_Shop.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Magic_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandRepository brandRepository;

        public BrandController(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandRequestDto request)
        {
            // Map Dto to Domain
            var brand = new Brand
            {
                Name = request.Name
            };

            await brandRepository.CreateAsync(brand);

            // Map Domain to Dto
            var response = new BrandDto
            {
                Name = brand.Name
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            var brands = await brandRepository.GetAllAsync();

            // Map Domain to Dto
            var response = new List<BrandDto>();
            foreach (var brand in brands)
            {
                response.Add(new BrandDto
                {
                    ID = brand.ID,
                    Name = brand.Name
                });
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{brandID:int}")]
        public async Task<IActionResult> GetBrandByID(int brandID)
        {
            var existingBrand = await brandRepository.GetByID(brandID);

            if (existingBrand != null)
            {
                var response = new BrandDto
                {
                    ID = existingBrand.ID,
                    Name = existingBrand.Name,
                };

                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("{brandID:int}")]
        public async Task<IActionResult> UpdateBrand([FromRoute] int brandID, [FromBody] UpdateBrandRequestDto request)
        {
            var brand = new Brand
            {
                ID = brandID,
                Name = request.Name,
            };

            brand = await brandRepository.UpdateAsync(brand);

            if(brand == null)
            {
                return NotFound();
            }

            // Convert Domain to Dto
            var response = new BrandDto
            {
                ID = brand.ID,
                Name = brand.Name,
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("{brandID:int}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int brandID)
        {
            var brand = await brandRepository.DeleteAsync(brandID);

            if (brand == null)
            {
                return NotFound();
            }

            // Map Domain to Dto
            var response = new BrandDto
            {
                ID = brand.ID,
                Name = brand.Name
            };

            return Ok(response);
        }
    }
}
