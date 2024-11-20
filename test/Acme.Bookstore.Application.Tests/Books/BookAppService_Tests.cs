﻿using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Xunit;

namespace Acme.Bookstore.Books
{
    public abstract class BookAppService_Tests<TStartupModule> : BookstoreApplicationTestBase<TStartupModule> where TStartupModule : IAbpModule
    {
        private readonly IBookAppService _bookAppService;

        protected BookAppService_Tests()
        {
            _bookAppService = GetRequiredService<IBookAppService>();
        }

        [Fact]
        public async Task Should_Get_List_Of_Books()
        {
            var result = await _bookAppService.GetListAsync(
                    new PagedAndSortedResultRequestDto()
            );

            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(b => b.Name == "1984");
        }

        [Fact]
        public async Task Should_Create_A_Valid_Book()
        {
            var result = await _bookAppService.CreateAsync(
                    new CreateUpdateBookDto
                    {
                        Name = "Test",
                        Price = 10,
                        PublishDate = DateTime.Now,
                        Type = BookType.ScienceFiction
                    }
            );

            result.Id.ShouldNotBe(Guid.Empty);
            result.Name.ShouldBe("Test");
        }

        [Fact]
        public async Task Should_Not_Create_A_Book_Without_Name()
        {
            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                await _bookAppService.CreateAsync(
                    new CreateUpdateBookDto
                    {
                        Name = "",
                        Price = 10,
                        PublishDate = DateTime.Now,
                        Type = BookType.Undefined 
                    }    
                );
            });
            

            exception.ValidationErrors
                .ShouldContain(err => err.MemberNames.Any(mem => mem == "Name") );
        }
    }
}