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
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_AddNewContest").Options;

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
    }
}