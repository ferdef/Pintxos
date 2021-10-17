using System;
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
        
        public Task<bool> AddPintxoAsync(PintxoModel newPintxo)
        {
            throw new NotImplementedException();
        }

        public Task<PintxoModel> GetPintxosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ScorePintxo(Guid id, int value)
        {
            throw new NotImplementedException();
        }
    }
}