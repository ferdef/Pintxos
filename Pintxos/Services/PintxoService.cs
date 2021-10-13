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

            // ContestModel contest = new ContestModel()
            // {
            //     ContestDate = System.DateTime.Today
            // };

            // ContestViewModel contests = new ContestViewModel();
            // contests.Items = new ContestModel[] { contest };

            // return new[] { contest };
        }
    }
}