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
        
        public async Task<PintxoModel> AddPintxoAsync(PintxoModel newPintxo)
        {
            newPintxo.Id = Guid.NewGuid();
            _context.Pintxos.Add(newPintxo);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1 ? newPintxo : null;
        }

        public async Task<PintxoModel[]> GetPintxosAsync()
        {
            var items = _context.Pintxos.ToArray();

            return items;
        }

        public Task<bool> ScorePintxo(Guid id, int value)
        {
            throw new NotImplementedException();
        }
    }
}