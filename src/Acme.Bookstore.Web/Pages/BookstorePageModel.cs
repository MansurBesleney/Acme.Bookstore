using Acme.Bookstore.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acme.Bookstore.Web.Pages;

public abstract class BookstorePageModel : AbpPageModel
{
    protected BookstorePageModel()
    {
        LocalizationResourceType = typeof(BookstoreResource);
    }
}
