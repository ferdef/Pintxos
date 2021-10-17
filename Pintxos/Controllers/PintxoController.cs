using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pintxos.Models;
using Pintxos.Services;

namespace Pintxos.Controllers
{
    public class PintxoController : Controller
    {
        private readonly IPintxoService _pintxoService;

        public PintxoController(IPintxoService pintxoService)
        {
            _pintxoService = pintxoService;
        }

        public async Task<IActionResult> Index()
        {
            var pintxos = await _pintxoService.GetPintxosAsync();

            var model = new PintxoViewModel()
            {
                Items = pintxos
            };
            
            return View(model);
        }
    }
}