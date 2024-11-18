using Acme.Bookstore.Books;
using AutoMapper;

namespace Acme.Bookstore.Web;

public class BookstoreWebAutoMapperProfile : Profile
{
    public BookstoreWebAutoMapperProfile()
    {
        //Define your object mappings here, for the Web project
        CreateMap<BookDto, CreateUpdateBookDto>();
    }
}
