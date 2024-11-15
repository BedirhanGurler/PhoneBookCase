﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBookApi.Business.Abstract;
using PhoneBookApi.Models.Concrete;
using PhoneBookApi.Models.DTO;

namespace PhoneBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _category;

        public CategoriesController(ICategoryService category)
        {
            _category = category;
        }

        [HttpGet("categories")]
        public async Task<IActionResult> Get()
        {
            var category = await _category.GetAllAsync();
            return Ok(category);
        }

        [HttpPost("add-category")]
        public async Task<IActionResult> CreateNewCategory([FromBody] CategoryDTO categoryDTO)
        {
            await _category.AddCategory(categoryDTO);
            return Ok(categoryDTO);
        }
    }
}
