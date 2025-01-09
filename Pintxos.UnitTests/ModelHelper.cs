using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pintxos.Data;
using Pintxos.Models;
using Pintxos.Services;

namespace Pintxos.UnitTests
{
    

    public class ModelHelper
    {
        public static DbContextOptions<ApplicationDbContext> GetOptions(string name)
        {
            return new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: name).Options;
        }
        
        public static async Task<ContestModel> CreateContestAsync(
            ApplicationDbContext ctx, DateTime dt, bool? IsActive)
        {
            var service = new ContestService(ctx);
            var model = new ContestModel { ContestDate = dt };
            if (IsActive.HasValue)
            {
                model.IsActive = IsActive.Value;
            }
            return await service.AddContestAsync(model);
        }
    }
}