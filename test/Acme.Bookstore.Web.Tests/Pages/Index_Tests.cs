using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Acme.Bookstore.Pages;

[Collection(BookstoreTestConsts.CollectionDefinitionName)]
public class Index_Tests : BookstoreWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
