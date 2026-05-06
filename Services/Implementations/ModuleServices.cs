using StudentRecordSystem.Data;
using StudentRecordSystem.Dtos.Request;
using StudentRecordSystem.Dtos;
using StudentRecordSystem.Models;
using StudentRecordSystem.Services.Interfaces;
using StudentRecordSystem.Data;

namespace StudentRecordSystem.Services.Implementations
{
    public class ModuleServices(AppDbContext dbContext) : IModuleService
    {
        public async Task<ApiResponse<Module>> AddModuleAsync(ModuleCreateDto moduleCreateDto)
        {
            ArgumentNullException.ThrowIfNull(moduleCreateDto);
            Module module = new Module()
            {   Title = moduleCreateDto.Title,
                Credits = moduleCreateDto.Credits,
                CourseId = moduleCreateDto.CourseId
            };
            dbContext.Modules.Add(module);
            await dbContext.SaveChangesAsync();
            return new ApiResponse<Module>
            {
                Success = true,
                Message = "Module added successfully",
                Data = module

            };

        }
    }
}
