using System.Threading.Tasks;
using Abp.Application.Services;
using MultiPageProject.Roles.Dto;

namespace MultiPageProject.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
