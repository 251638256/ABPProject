using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MultiPageProject.Users.Dto;

namespace MultiPageProject.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task ProhibitPermission(ProhibitPermissionInput input);

        Task RemoveFromRole(long userId, string roleName);

        Task<ListResultDto<UserListDto>> GetUsers();

        ListResultDto<UserListDto> GetUsers2();

        Task CreateUser(CreateUserInput input);
    }
}