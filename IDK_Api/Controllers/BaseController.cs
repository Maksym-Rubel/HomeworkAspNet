using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interface;
using DataAccess.Data;
using DataAccess.Data.Entities;
using IDK_Api.Helpers;
using Microsoft.AspNetCore.Authorization;
//using IDK_Api.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IDK_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {

        private readonly IBaseService baseService;
        public BaseController(IBaseService baseService)
        {
            this.baseService = baseService;
            
        }

        [HttpPost("CreateItemWeekDay")]
        [Authorize(Roles = Roles.ADMIN)]

        public async Task<ActionResult<ItemWeekDayDto>> CreateItemWeekDay(ItemWeekDayDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error");
            }
            return Ok(await baseService.CreateItemWeekDay(model));
        }
        [HttpPost("CreateWeekDay")]
        [Authorize(Roles = Roles.ADMIN)]

        public async Task<ActionResult<WeekDayDto>> CreateWeekDay(WeekDayDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error");
            }
            return Ok(await baseService.CreateWeekDay(model));
        }
    }
}
