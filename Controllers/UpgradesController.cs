using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PawWebApp.Models;
using PawWebApp.Services;

namespace PawWebApp.Controllers
{
    public class UpgradesController : Controller
    {
        private readonly IUpgradeService _upgradeService;

        public UpgradesController(IUpgradeService upgradeService)
        {
            _upgradeService = upgradeService;
        }

        // GET: Upgrades
        public async Task<IActionResult> Upgrade()
        {
            var upgrades = await _upgradeService.GetAllUpgrades();
            return View(upgrades);
        }

        // GET: Upgrades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upgrade = await _upgradeService.GetUpgradeById(id.Value);
            if (upgrade == null)
            {
                return NotFound();
            }

            return View(upgrade);
        }

        // GET: Upgrades/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Upgrades/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Subject,Details,PcPart")] Upgrade upgrade)
        {
            if (ModelState.IsValid)
            {
                await _upgradeService.CreateUpgrade(upgrade);
                return RedirectToAction(nameof(UpgradeSuccessful)); // Redirect to Upgrade action
            }
            return View(upgrade);
        }

        // GET: Upgrades/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upgrade = await _upgradeService.GetUpgradeById(id.Value);
            if (upgrade == null)
            {
                return NotFound();
            }
            return View(upgrade);
        }

        // POST: Upgrades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Subject,Details,PcPart")] Upgrade upgrade)
        {
            if (id != upgrade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _upgradeService.UpdateUpgrade(upgrade);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UpgradeExists(upgrade.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Upgrade));
            }
            return View(upgrade);
        }

        // GET: Upgrades/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upgrade = await _upgradeService.GetUpgradeById(id.Value);
            if (upgrade == null)
            {
                return NotFound();
            }

            return View(upgrade);
        }

        // POST: Upgrades/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*            var upgrade = await _context.Upgrades.FindAsync(id);
            if (upgrade != null)
            {
                _context.Upgrades.Remove(upgrade);
            }

            await _context.SaveChangesAsync();*/
            await _upgradeService.DeleteUpgrade(id);
            return RedirectToAction(nameof(Upgrade));
        }

        private bool UpgradeExists(int id)
        {
            return _upgradeService.GetUpgradeById(id) != null;
        }

        // GET: Upgrades/UpgradeSuccessful
        public IActionResult UpgradeSuccessful()
        {
            return View();
        }

    }
}
