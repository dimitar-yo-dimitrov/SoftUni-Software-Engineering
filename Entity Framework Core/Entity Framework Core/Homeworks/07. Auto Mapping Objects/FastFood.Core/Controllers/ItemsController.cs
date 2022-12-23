using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FastFood.Services.Interfaces;
using FastFood.Services.Models.Categories;
using FastFood.Services.Models.Items;
using FastFood.Web.ViewModels.Items;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.Web.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICategoryService categoryService;
        private readonly IItemService itemService;

        public ItemsController(IMapper mapper, ICategoryService categoryService, IItemService itemService)
        {
            this.mapper = mapper;
            this.categoryService = categoryService;
            this.itemService = itemService;
        }

        public async Task<IActionResult> Create()
        {
            ICollection<ListCategoryDto> categories = await this.categoryService.GetAll();

            IList<CreateItemViewModel> itemsViewModels = categories
                .Select(createDto => this.mapper.Map<CreateItemViewModel>(createDto))
                .ToList();

            return this.View(itemsViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateItemInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Create", "Items");
            }

            bool categoryValid = await this.categoryService.ExistById(model.CategoryId);
            if (!categoryValid)
            {
                return this.RedirectToAction("Create", "Items");
            }

            CreateItemDto itemDto = this.mapper.Map<CreateItemDto>(model);
            await this.itemService.Add(itemDto);

            return this.RedirectToAction("All", "Items");
        }

        public async Task<IActionResult> All()
        {
            ICollection<ListItemDto> itemDtos = await this.itemService.GetAll();

            IList<ItemsAllViewModels> itemsAllViewModel = itemDtos
                .Select(createDto => this.mapper.Map<ItemsAllViewModels>(createDto))
                .ToList();

            return this.View(itemsAllViewModel);
        }
    }
}
