using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interface;
using DataAccess.Data;
using DataAccess.Data.Entities;
using IDK_Api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IDK_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeworkController : ControllerBase
    {
        private readonly IHomeworkService homeworkService;
        public HomeworkController(IHomeworkService homeworkService)
        {
            this.homeworkService = homeworkService; 
        }

        [HttpGet("GeHomeWorkItems")]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<HomeWorkItemDto>>> GeHomeWorkItems(DateTime dateTime)
        {
            return Ok(await homeworkService.GeHomeWorkItems(dateTime));

        }

        [HttpPost("CreateHomeWork")]
        [Authorize(Roles = Roles.ADMIN)]

        public async Task<ActionResult<HomeWorkItemCreateDto>> CreateHomeWork(HomeWorkItemCreateDto model)
        {
            return Ok(await homeworkService.CreateHomeWork(model));
        }


        [HttpGet("GetOneHomework")]


        public async Task<ActionResult<HomeWorkItemDto>> GetOneHomework(int id)
        {
            return Ok(await homeworkService.GetOneHomeWorkItem(id));
        }
        [HttpDelete("RemoveItem")]
        [Authorize(Roles = Roles.ADMIN)]

        public async Task<IActionResult> RemoveItem(int Id)
        {
            await homeworkService.Delete(Id);
          

            return NoContent();
        }
        [HttpPut("EditHomeWork")]
        [Authorize(Roles = Roles.ADMIN)]
        public async Task<ActionResult<HomeWorkItemDto>> EditHomeWork(HomeWorkItemDto model)
        {
            return Ok(await homeworkService.EditHome(model));
        }

    }
}
