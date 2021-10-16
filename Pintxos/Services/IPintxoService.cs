using System;
using System.Threading.Tasks;
using Pintxos.Models;

namespace Pintxos.Services 
{
    public interface IPintxoService
    {
        Task<ContestModel[]> GetContestsAsync();
        Task<bool> AddContestAsync(ContestModel newContest);
        Task<bool> MarkAsActive(Guid id);
    }
}