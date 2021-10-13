using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Pintxos.Models;
using Pintxos.Services;

namespace Pintxos.Controllers
{
    public class ContestController : Controller
    {
        private readonly IPintxoService _pintxoService;
        public ContestController(IPintxoService contestService)
        {
            _pintxoService = contestService;
        }
        public async Task<IActionResult> Index()
        {
            var contests = await _pintxoService.GetContestsAsync();

            var model = new ContestViewModel()
            {
                Items = contests
            };

            return View(model);
        }
    }
}