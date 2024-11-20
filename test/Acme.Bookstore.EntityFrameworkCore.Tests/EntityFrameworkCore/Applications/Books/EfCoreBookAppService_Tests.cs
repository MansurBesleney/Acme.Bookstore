using Acme.Bookstore.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Acme.Bookstore.EntityFrameworkCore.Applications.Books
{
    [Collection(BookstoreTestConsts.CollectionDefinitionName)]
    public class EfCoreBookAppService_Tests : BookAppService_Tests<BookstoreEntityFrameworkCoreTestModule>
    {

    }
}
