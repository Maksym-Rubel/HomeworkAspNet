using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.DTOs.Account;
using DataAccess.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ItemDto, Item>();
            CreateMap<Item, ItemDto>();

            CreateMap<Item, CreateItemDto>();
            CreateMap<CreateItemDto, Item>();

            CreateMap<ItemWeekDayDto, ItemWeekDay>();
            CreateMap<ItemWeekDay, ItemWeekDayDto>();

            CreateMap<WeekDayDto, WeekDay>();
            CreateMap<WeekDay, WeekDayDto>();

            CreateMap<HomeWorkItemDto, HomeWorkItem>();
            CreateMap<HomeWorkItem, HomeWorkItemDto>();
            CreateMap<HomeWorkItemCreateDto, HomeWorkItem>();
            CreateMap<HomeWorkItem, HomeWorkItemCreateDto>();

            CreateMap<RegisterModel, User>()
                .ForMember(x=> x.UserName, opt => opt.MapFrom(s => s.Email))
                .ForMember(x => x.PasswordHash, opt => opt.Ignore());


        }
    }
}
