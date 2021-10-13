using System.Threading.Tasks;
using Pintxos.Models;

namespace Pintxos.Services 
{
    public interface IPintxoService
    {
        public Task<ContestModel[]> GetContestsAsync();

    }
}