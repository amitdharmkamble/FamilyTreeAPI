﻿using FamilyTreeAPI.Contexts;
using FamilyTreeAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FamilyTreeTests
{
    public class CreatorContextTests
    {
        [Fact]
        public void CreatorContext_CanBeInstantiatedWithInMemoryDatabase()
        {
            var serviceProvider = new ServiceCollection()
                                        .AddDbContext<CreatorContext>(options =>
                                            options.UseInMemoryDatabase("TestDatabase"))
                                        .BuildServiceProvider();
            var context = serviceProvider.GetService<CreatorContext>();
            Assert.NotNull(context);
        }

        [Fact]
        public void CreatorContext_CanAddAndRetrieveCreated()
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<CreatorContext>(options =>
                    options.UseInMemoryDatabase("TestDatabase"))
                .BuildServiceProvider();
            using (var context = serviceProvider.GetService<CreatorContext>())
            {
                Assert.NotNull(context);
                Guid _creatorId = Guid.Empty;
                Creator creator = new Creator
                {
                    Id = Guid.NewGuid(),
                    FirstName = "First Name",
                    LastName = "Last Name",
                    CreatedAt = DateTime.UtcNow,
                };
                _creatorId = creator.Id;
                context.Add(creator);
                context.SaveChanges();
                var createdCreator = context.Creators.FirstOrDefault(c => c.Id == _creatorId);
                Assert.Equal(_creatorId, createdCreator?.Id);
            }
        }
    }
}
