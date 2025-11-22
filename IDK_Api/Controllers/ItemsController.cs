using AutoMapper;
using BusinessLogic;
using BusinessLogic.DTOs;
using BusinessLogic.Interface;
using BusinessLogic.Services;
using DataAccess.Data;
using DataAccess.Data.Entities;
using IDK_Api.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IDK_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {

        private readonly IItemsInterface itemService;
       
        public ItemsController(IItemsInterface itemService)
        {
            this.itemService = itemService;
        }
        [HttpGet("GetOneItem")]
        public async Task<ActionResult<ItemDto>> GetOneItem(int id)
        {
            return Ok(await itemService.GetOneItem(id));
        }
        [HttpGet("GetDayItems")]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetDayItems(DateTime dateTime, int WeekDay)
        {
            return Ok(await itemService.GetAllItem(WeekDay));
        }


      
        [HttpGet("GetAllItem")]

        public async Task<ActionResult<IEnumerable<ItemDto>>> GetAllItem()
        {
            return Ok(await itemService.GetAllItem());
        }
        [HttpPost("CreateItem")]
        [Authorize(Roles = Roles.ADMIN)]
        public async Task<ActionResult<ItemDto>> CreateItem(CreateItemDto model)
        {
            return Ok(await itemService.CreateItem(model));
        }
    }
}
