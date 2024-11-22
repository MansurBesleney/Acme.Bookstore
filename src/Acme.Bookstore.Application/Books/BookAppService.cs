using Acme.Bookstore.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.Bookstore.Books
{
    public class BookAppService : CrudAppService<
        Book,
        BookDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateBookDto>,
        IBookAppService
    {
        public BookAppService(IRepository<Book, Guid> repository) : base(repository)
        {
            GetPolicyName = BookstorePermissions.Books.Default;
            GetListPolicyName = BookstorePermissions.Books.Default;
            CreatePolicyName = BookstorePermissions.Books.Create;
            UpdatePolicyName = BookstorePermissions.Books.Edit;
            DeletePolicyName = BookstorePermissions.Books.Delete;
        }
    }
}
