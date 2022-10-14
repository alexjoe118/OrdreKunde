using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OrdreKunde.Model;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OrdreKunde.Controllers
{
    [Route("[controller]/[action]")]

    public class KundeController : ControllerBase
    {
        private readonly DB _db;

        public KundeController(DB db)
        {
            _db = db;
        }

        public List<Kunde> index()
        {
            return _db.Kunde.ToList();
        }

        //AddOrEdit Get Method
        public async Task<IActionResult> AddOrEdit(int? kundreId)
        {
            //string PageName = kundreId == null ? "Create Kunder" : "Edit Kunde";
            //bool IsEdit = kundreId == null ? false : true;
            if (kundreId == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var kunde = await _db.Kunde.FindAsync(kundreId);

                if (kunde == null)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
        }

        //AddOrEdit Post Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int kundeid, [Bind("kundeid,FirstName,SecondName,Email,Address,Age")]
Kunde employeeData)
        {
            bool IsEmployeeExist = false;

            Kunde kunde = await _db.Kunde.FindAsync(kundeid);

            if (kunde != null)
            {
                IsEmployeeExist = true;
            }
            else
            {
                kunde = new Kunde();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    kunde.FirstName = employeeData.FirstName;
                    kunde.LastName = employeeData.LastName;
                    kunde.Address = employeeData.Address;
                    kunde.Email = employeeData.Email;
                    kunde.Age = employeeData.Age;

                    if (IsEmployeeExist)
                    {
                        _db.Update(kunde);
                    }
                    else
                    {
                        _db.Add(kunde);
                    }
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            //            return View(employeeData);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int? kundeid)
        {
            if (kundeid == null)
            {
                return NotFound();
            }
            var employee = await _db.Kunde.FirstOrDefaultAsync(m => m.Id == kundeid);
            if (employee == null)
            {
                return NotFound();
            }
            //return View(employee);
            return RedirectToAction(nameof(Index));
        }
        // GET: Employees/Delete/1
        public async Task<IActionResult> Delete(int? kundeid)
        {
            if (kundeid == null)
            {
                return NotFound();
            }
            var kunde = await _db.Kunde.FirstOrDefaultAsync(m => m.Id == kundeid);

            //return View(kunde);
            return RedirectToAction(nameof(Index));
        }

        // POST: Employees/Delete/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int kundeid)
        {
            var kunde = await _db.Kunde.FindAsync(kundeid);
            _db.Kunde.Remove(kunde);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
    
}

