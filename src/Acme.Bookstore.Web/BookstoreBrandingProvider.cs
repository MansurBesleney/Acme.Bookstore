using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.Localization;
using Acme.Bookstore.Localization;

namespace Acme.Bookstore.Web;

[Dependency(ReplaceServices = true)]
public class BookstoreBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<BookstoreResource> _localizer;

    public BookstoreBrandingProvider(IStringLocalizer<BookstoreResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
