using AutoMapper;
using AutoMapper.QueryableExtensions;
using FastFood.Data;
using FastFood.Models;
using FastFood.Services.Interfaces;
using FastFood.Services.Models.Items;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Services
{
    public class ItemService : IItemService
    {
        private readonly FastFoodContext dbContext;
        private readonly IMapper mapper;

        public ItemService(FastFoodContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task Add(CreateItemDto itemDto)
        {
            Item item = this.mapper.Map<Item>(itemDto);

            dbContext.Items.Add(item);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<ListItemDto>> GetAll()
        {
            ICollection<ListItemDto> result = await dbContext
                .Items
                .ProjectTo<ListItemDto>(this.mapper.ConfigurationProvider)
                .ToListAsync();

            return result;
        }
    }
}
