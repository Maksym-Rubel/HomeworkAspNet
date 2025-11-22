using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IBaseService
    {
        Task<ItemWeekDayDto>? CreateItemWeekDay(ItemWeekDayDto model);
        Task<WeekDayDto>? CreateWeekDay(WeekDayDto model);

    }
}
