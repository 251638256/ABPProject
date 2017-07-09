using System.Reflection;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.Zero;
using Abp.Zero.Configuration;
using MultiPageProject.Authorization;
using MultiPageProject.Authorization.Roles;
using MultiPageProject.MultiTenancy;
using MultiPageProject.Users;

namespace MultiPageProject
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class MultiPageProjectCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            //Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);
            //Configuration.Modules.Zero().EntityTypes.cv

            //Remove the following line to disable multi-tenancy.
            //Configuration.MultiTenancy.IsEnabled = MultiPageProjectConsts.MultiTenancyEnabled;


            //Add/remove localization sources here
            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    MultiPageProjectConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        Assembly.GetExecutingAssembly(),
                        "MultiPageProject.Localization.Source"
                        )
                    )
                );

            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Authorization.Providers.Add<MultiPageProjectAuthorizationProvider>();
            //Configuration.Modules.AbpConfiguration.s
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
