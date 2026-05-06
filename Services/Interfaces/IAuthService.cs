using StudentRecordSystem.Dtos;
using StudentRecordSystem.Dtos.Request;
using StudentRecordSystem.Dtos.Response;
using System.Threading.Tasks;

namespace StudentRecordSystem.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ApiResponse<string>> RegisterUserAsync(RegisterUserDto registerUserDto);
        Task<LoginResponse> LoginAsync(LoginDto loginDto);
    }
}
