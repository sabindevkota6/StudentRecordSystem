using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRecordSystem.Dtos.Request;
using StudentRecordSystem.Services.Interfaces;


namespace StudentRecordSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulesController(IModuleService moduleService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddModule(ModuleCreateDto moduleCreateDto)
        {
            var response = await moduleService.AddModuleAsync(moduleCreateDto);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
