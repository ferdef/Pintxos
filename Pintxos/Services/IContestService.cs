using System;
using System.Threading.Tasks;
using Pintxos.Models;

namespace Pintxos.Services 
{
    public interface IContestService
    {
        Task<ContestModel[]> GetContestsAsync();
        Task<ContestModel> AddContestAsync(ContestModel newContest);
        Task<bool> MarkContestAsActive(Guid id);
    }
}