using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interface;
using DataAccess.Data;
using DataAccess.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class BaseService : IBaseService
    {
        readonly SongDbContext ctx;
        readonly IMapper mapper;
        public BaseService(SongDbContext ctx, IMapper mapper)
        {

            this.ctx = ctx;
            this.mapper = mapper;
        }

        public async Task<ItemWeekDayDto>? CreateItemWeekDay(ItemWeekDayDto model)
        {
            var entity = mapper.Map<ItemWeekDay>(model);
            ctx.ItemWeekDays.Add(entity);
            ctx.SaveChanges();
            return mapper.Map<ItemWeekDayDto>(entity);
        }
        public async Task<WeekDayDto>? CreateWeekDay(WeekDayDto model)
        {
        
            var entity = mapper.Map<WeekDay>(model);
            ctx.WeekDays.Add(entity);
            ctx.SaveChangesAsync();
            return mapper.Map<WeekDayDto>(entity);
        }
    }
}
