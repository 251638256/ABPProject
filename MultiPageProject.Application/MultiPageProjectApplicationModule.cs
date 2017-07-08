using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using MultiPageProject.DTOMappping;
using Castle.MicroKernel.Registration;

namespace MultiPageProject
{
    [DependsOn(typeof(MultiPageProjectCoreModule), typeof(AbpAutoMapperModule))]
    public class MultiPageProjectApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                //Add your custom AutoMapper mappings here...
                //mapper.CreateMap<,>()
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            //注册IDtoMapping
            IocManager.IocContainer.Register(
                Classes.FromAssembly(Assembly.GetExecutingAssembly())
                    .IncludeNonPublicTypes()
                    .BasedOn<IDtoMapping>()
                    .WithService.Self()
                    .WithService.DefaultInterfaces()
                    .LifestyleTransient()
            );

            //解析依赖，并进行映射规则创建
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper => {
                var mappers = IocManager.IocContainer.ResolveAll<IDtoMapping>();
                foreach (var dtomap in mappers)
                    dtomap.CreateMapping(mapper);
            });

            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            //Configuration.Authorization.Providers.Add<MyAuthorizationProvider>();
        }
    }
}
