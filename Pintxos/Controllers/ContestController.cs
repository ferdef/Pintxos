using System;
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

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddContest(ContestModel newContest)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var successful = await _pintxoService.AddContestAsync(newContest);
            if (!successful)
            {
                return BadRequest("Could not add Contest");
            }

            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkActive(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }

            var successful = await _pintxoService.MarkContestAsActive(id);
            if(!successful)
            {
                return BadRequest("Could not activate contest");
            }
            return RedirectToAction("Index");
        }
    }
}