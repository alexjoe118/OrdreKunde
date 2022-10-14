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

    public class HomeController : ControllerBase
    {
        private readonly DB _db;

        public HomeController(DB db)
        {
            _db = db;
        }

        public List<Ordre> index()
        {
            return _db.Ordre.ToList();
        }
        //Read
        public Ordre Detail(int? ordre_id)
        {
            if(ordre_id != null)
            {
                Ordre ordre = _db.Ordre.Find(ordre_id);
                //return View(data);
                return ordre;
            }
            return null;
        }
        //Read
        public List<Ordre> ByKunde(int? kunde_id)
        {
            if(kunde_id != null)
            {
                List < Ordre > ordres = _db.Ordre.Where(ordre => ordre.Kunde.Id == kunde_id).ToList();
                //return View(ordres);
                return ordres;
            }
            //return null;
            return null;
        }
        //Creat, Update
        [HttpPost, ActionName("Add")]
        public async Task<IActionResult> AddOrEdit(string dato, Ordre ordre, Stock stock, int Antall)
        {
            bool IsOrderExist = false;

            Ordre ExistOrdre = await _db.Ordre.FindAsync(ordre.Id);
            if(ExistOrdre != null)
            {
                IsOrderExist = true;
            }
            else
            {
                ExistOrdre = new Ordre();
            }

            
            List<OrdreLinje> ordreLinje = ExistOrdre.OrdreLinjer;
            OrdreLinje new_ordreLinje = new OrdreLinje();
            new_ordreLinje.Stock = stock;
            new_ordreLinje.Antall = Antall;
            ordreLinje.Add(new_ordreLinje);
            ExistOrdre.OrdreLinjer = ordreLinje;

            if (IsOrderExist)
            {
                _db.Update(ExistOrdre);
            }
            else
            {
                _db.Add(ExistOrdre);
            }
            

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
        // GET: Delete/1

        [HttpGet]
        public async Task<IActionResult> Delete(int? Order_id)
        {
            if (Order_id == null)
            {
                return NotFound();
            }
            var employee = await _db.Ordre.FirstOrDefaultAsync(m => m.Id == Order_id);

            return RedirectToAction(nameof(Index));
        }

        // POST: /Delete/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int employeeId)
        {
            var employee = await _db.Ordre.FindAsync(employeeId);
            _db.Ordre.Remove(employee);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



    }
}

