using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pintxos.Data;
using Pintxos.Services;
using Pintxos.Models;
using Xunit;

namespace Pintxos.UnitTests
{
    public class ContestServiceShould
    {
        [Fact]
        public async Task AddNewContest()
        {
            var options = ModelHelper.GetOptions("Test_AddNewContest");

            using (var context = new ApplicationDbContext(options))
            {
                var service = new ContestService(context);

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
        public async Task CreateOneActiceMarksOthersAsInactive()
        {
            var options = ModelHelper.GetOptions("Test_CreateActive");
            using (var context = new ApplicationDbContext(options))
            {
                var service = new ContestService(context);

                await service.AddContestAsync(new ContestModel
                {
                    ContestDate = DateTime.Today,
                    IsActive = true
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

        [Fact]
        public async Task MarkOneActiceMarksOthersAsInactive()
        {
            var options = ModelHelper.GetOptions("Test_MarkAsActive");
            using (var context = new ApplicationDbContext(options))
            {
                var service = new ContestService(context);

                await service.AddContestAsync(new ContestModel
                {
                    ContestDate = DateTime.Today,
                    IsActive = false
                });
                await service.AddContestAsync(new ContestModel
                {
                    ContestDate = DateTime.Today,
                    IsActive = true
                });
                var first = await context.Contests.FirstAsync();
                var marked = service.MarkContestAsActive(first.Id);
            }
            using (var context = new ApplicationDbContext(options))
            {
                var itemsInDatabase = await context.Contests.CountAsync();
                Assert.Equal(2, itemsInDatabase);
                
                var items = await context.Contests.ToListAsync();
                
                Assert.True(items[0].IsActive);
                Assert.False(items[1].IsActive);
            }
        }
    }
}