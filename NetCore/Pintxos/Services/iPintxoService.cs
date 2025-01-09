using System;
using System.Threading.Tasks;
using Pintxos.Models;

namespace Pintxos.Services
{
    public interface IPintxoService
    {
        Task<PintxoModel[]> GetPintxosAsync();
        Task<PintxoModel> AddPintxoAsync(PintxoModel newPintxo);
        Task<bool> ScorePintxo(Guid id, int value);
        
    }
}