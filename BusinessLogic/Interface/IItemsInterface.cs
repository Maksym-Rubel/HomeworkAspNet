using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IItemsInterface
    {
        Task<ItemDto>? GetOneItem(int id);
        //IList<ItemDto>? GetDayItems(DateTime dateTime, int WeekDay);
        Task<IList<ItemDto>>? GetAllItem(int? WeekDay = null);
        Task<CreateItemDto>? CreateItem(CreateItemDto model);
    }
}
