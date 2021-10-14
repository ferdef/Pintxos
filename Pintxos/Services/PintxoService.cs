using System;
using System.Linq;
using System.Threading.Tasks;
using Pintxos.Data;
using Pintxos.Models;

namespace Pintxos.Services
{
    public class PintxoService : IPintxoService
    {
        private readonly ApplicationDbContext _context;

        public PintxoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ContestModel[]> GetContestsAsync()
        {
            var items = _context.Contests.ToArray();

            return items;
        }

        public async Task<bool> AddContestAsync(ContestModel newContest)
        {
            newContest.Id = Guid.NewGuid();

            _context.Contests.Add(newContest);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}