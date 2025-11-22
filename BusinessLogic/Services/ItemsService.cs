using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interface;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ItemsService : IItemsInterface
    {
        readonly SongDbContext ctx;
        readonly IMapper mapper;
        public ItemsService(SongDbContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }
        public async Task<ItemDto>? GetOneItem(int id)
        {
            var model = ctx.Items
                .FirstOrDefaultAsync(m => m.Id == id);
            return mapper.Map<ItemDto>(model); 
        }
        public async Task<IList<ItemDto>> GetAllItem(int? WeekDay = null)
        {
            if(WeekDay != null)
            {
                var modelret = new List<Item>();
                var model2 = await ctx.WeekDays.FirstOrDefaultAsync(m => m.DayOfWeek == WeekDay);
                if (model2 != null)
                {
                    var ItemList = ctx.ItemWeekDays.Where(m => m.DayId == model2.Id).ToList();
                    foreach (var item in ItemList)
                    {
                        if (ctx.Items.Any(m => item.ItemId == m.Id))
                        {
                            
                             modelret.Add(await ctx.Items.FirstOrDefaultAsync(m => item.ItemId == m.Id));
                        }
                    }
                    return mapper.Map<IList<ItemDto>>(modelret);
                }
                else
                {
                    Console.WriteLine("Null");
                    return new List<ItemDto>();

                }
            }
            else
            {
                var model = ctx.Items;
                return mapper.Map<IList<ItemDto>>(model.ToList());
            }
                
        }
        public async Task<CreateItemDto>? CreateItem(CreateItemDto model)
        {
            var entity = mapper.Map<Item>(model);
            ctx.Items.Add(entity);
            ctx.SaveChangesAsync();

            return mapper.Map<CreateItemDto>(entity);

        }
    }
}
