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
        public async Task AddNewPintxo()
        {
            const string Name = "Test1";
            const string Description = "Description1";

            var options = ModelHelper.GetOptions("Test_AddNewPintxo");

            using (var context = new ApplicationDbContext(options))
            {
                var service = new PintxoService(context);

                var contest = await ModelHelper.CreateContestAsync(context, DateTime.Today, false);

                await service.AddPintxoAsync(new PintxoModel
                {
                    Name = "Test1",
                    Description = "Description1",
                    Contest = contest                        
                });
            }

            using (var context = new ApplicationDbContext(options))
            {
                var itemsInDatabase = await context.Pintxos.CountAsync();
                Assert.Equal(1, itemsInDatabase);

                var item = await context.Pintxos.FirstAsync();
                Assert.Equal(Name, item.Name);
                Assert.Equal(Description, item.Description);
            }
        }       
    }
}