using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FastFood.Services.Interfaces;
using FastFood.Services.Models.Categories;
using FastFood.Web.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICategoryService categoryService;

        public CategoriesController(IMapper mapper, ICategoryService categoryService)
        {
            this.mapper = mapper;
            this.categoryService = categoryService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Create", "Categories");
            }

            CreateCategoryDto categoryDto = this.mapper.Map<CreateCategoryDto>(model);
            await this.categoryService.Add(categoryDto);

            return this.RedirectToAction("All", "Categories");
        }

        public async Task<IActionResult> All()
        {
            ICollection<ListCategoryDto> categoriesDtos = await this.categoryService.GetAll();

            IList<CategoryAllViewModel> categoryAllViewModel = categoriesDtos
                .Select(createDto => this.mapper.Map<CategoryAllViewModel>(createDto))
                .ToList();

            return this.View(categoryAllViewModel);
        }
    }
}
