using AutoMapper;
using BusinessLogic.DTOs;
using DataAccess.Data;
using DataAccess.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IHomeworkService
    {
        Task<IList<HomeWorkItemDto>>? GeHomeWorkItems(DateTime dateTime);
        Task<HomeWorkItemCreateDto>? CreateHomeWork(HomeWorkItemCreateDto model);
        Task Delete(int Id);
        Task<HomeWorkItemDto>? EditHome(HomeWorkItemDto model);
        Task<HomeWorkItemDto>? GetOneHomeWorkItem(int id);

    }
}
