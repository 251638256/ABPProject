using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MultiPageProject.MultiTenancy.Dto;

namespace MultiPageProject.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        ListResultDto<TenantListDto> GetTenants();

        Task CreateTenant(CreateTenantInput input);
    }
}
