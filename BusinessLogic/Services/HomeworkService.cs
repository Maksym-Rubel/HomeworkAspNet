using AutoMapper;
using BusinessLogic.DException;
using BusinessLogic.DTOs;
using BusinessLogic.Interface;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class HomeworkService : IHomeworkService
    {
        readonly SongDbContext ctx;
        readonly IMapper mapper;
        public HomeworkService(SongDbContext ctx, IMapper mapper)
        {

            this.ctx = ctx;
            this.mapper = mapper;
        }
        public async Task<IList<HomeWorkItemDto>>? GeHomeWorkItems(DateTime dateTime)
        {
            var dateonly = dateTime.Date;
            var nextDay = dateonly.AddDays(1);
            var model = await ctx.homeWorkItems
                .Where(m => m.HomeWorkDate >= dateonly && m.HomeWorkDate < nextDay)
                .ToListAsync();

            return mapper.Map<IList<HomeWorkItemDto>>(model);

        }
        public async Task<HomeWorkItemCreateDto>? CreateHomeWork(HomeWorkItemCreateDto model)
        {

            if (!await ctx.homeWorkItems.AnyAsync(m => m.ItemId == model.ItemId && m.HomeWorkDate == model.HomeWorkDate && m.Decription == model.Decription))
            {
                var entity = mapper.Map<HomeWorkItem>(model);
                ctx.homeWorkItems.Add(entity);
                await ctx.SaveChangesAsync();

                return mapper.Map<HomeWorkItemCreateDto>(entity);
            }
            else
            {
                throw new HttpException("This item already have", HttpStatusCode.BadRequest);
            }
               


        }

        public async Task Delete(int Id)
        {
           if(Id < 0)
           {
               throw new HttpException("Id must be > 0 ",HttpStatusCode.BadRequest);
           }

            var item = ctx.homeWorkItems.FirstOrDefault(m => m.Id == Id);


            if(item == null)
            {
                throw new HttpException("Item not find",HttpStatusCode.NotFound);
            }

            ctx.homeWorkItems.Remove(item);
            ctx.SaveChanges();
           
        }
        public async Task<HomeWorkItemDto>? GetOneHomeWorkItem(int id)
        {
            var model = await ctx.homeWorkItems
                .FirstOrDefaultAsync(m => m.Id == id);
            return mapper.Map<HomeWorkItemDto>(model);
        }
        public async Task<HomeWorkItemDto>? EditHome(HomeWorkItemDto model)
        {
           

       

            var entity =  mapper.Map<HomeWorkItem>(model);
            ctx.homeWorkItems.Update(entity);
            await ctx.SaveChangesAsync();

            return model;

        }
    }
}
