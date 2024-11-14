using Microsoft.AspNetCore.Builder;
using Acme.Bookstore;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<BookstoreWebTestModule>();

public partial class Program
{
}
