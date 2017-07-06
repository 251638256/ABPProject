using Abp.Web.Mvc.Views;

namespace MultiPageProject.Web.Views
{
    public abstract class MultiPageProjectWebViewPageBase : MultiPageProjectWebViewPageBase<dynamic>
    {

    }

    public abstract class MultiPageProjectWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected MultiPageProjectWebViewPageBase()
        {
            LocalizationSourceName = MultiPageProjectConsts.LocalizationSourceName;
        }
    }
}