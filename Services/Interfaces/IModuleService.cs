using StudentRecordSystem.Dtos.Request;

using StudentRecordSystem.Dtos;
using StudentRecordSystem.Dtos.Request;
using StudentRecordSystem.Models;

namespace StudentRecordSystem.Services.Interfaces
{
    public interface IModuleService
    {
        Task<ApiResponse<Module>> AddModuleAsync(ModuleCreateDto moduleCreateDto);

        // TODO: update
        // TODO: delete
        // TODO: get all
        // TODO: get by id
    }
}
