using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pintxos.Data;
using Pintxos.Services;
using Pintxos.Models;
using Xunit;

namespace Pintxos.UnitTests
{
    public class PintxoServiceShould
    {
        [Fact]
        public async Task AddNewContest()
        {
            var options = GetOptions("Test_AddNewContest");

            using (var context = new ApplicationDbContext(options))
            {
                var service = new PintxoService(context);

                await service.AddContestAsync(new ContestModel
                {
                    ContestDate = DateTime.Today
                });
            }

            using (var context = new ApplicationDbContext(options))
            {
                var itemsInDatabase = await context.Contests.CountAsync();
                Assert.Equal(1, itemsInDatabase);

                var item = await context.Contests.FirstAsync();
                Assert.Equal(DateTime.Today, item.ContestDate);
                Assert.False(item.IsActive);
            }
        }       

        [Fact]
        public async Task ActivatingOneMarksOthersAsInactive()
        {
            var options = GetOptions("Test_MarkAsInactive");
            using (var context = new ApplicationDbContext(options))
            {
                var service = new PintxoService(context);

                await service.AddContestAsync(new ContestModel
                {
                    ContestDate = DateTime.Today
                });
                await service.AddContestAsync(new ContestModel
                {
                    ContestDate = DateTime.Today,
                    IsActive = true
                });
            }
            using (var context = new ApplicationDbContext(options))
            {
                var itemsInDatabase = await context.Contests.CountAsync();
                Assert.Equal(2, itemsInDatabase);
                
                var items = await context.Contests.ToListAsync();
                
                Assert.False(items[0].IsActive);
                Assert.True(items[1].IsActive);
            }
            
        }

        DbContextOptions<ApplicationDbContext> GetOptions(string name)
        {
            return new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: name).Options;
        }
    }
}