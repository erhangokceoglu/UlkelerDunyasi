using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Diagnostics;
using UlkelerDunyasi.Models;
using UlkelerDunyasi.Models.Data;

namespace UlkelerDunyasi.Controllers
{
    public class HomeController : Controller
    {
        private readonly UygulamaDbContext _db;
        public HomeController(UygulamaDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Ulkeler.ToList());
        }

        [ValidateAntiForgeryToken]
        public IActionResult UlkeKaydet(Ulke ulke)
        {
            if (ModelState.IsValid)
            {
                if (ulke.Id == 0)
                {
                    _db.Add(ulke);
                    TempData["Mesaj"] = $"\"{ulke.Ad}\" adlı ülke başarıyla eklendi.";
                }
                else
                {
                    _db.Update(ulke);
                    TempData["Mesaj"] = $"\"{ulke.Ad}\" adlı ülke başarıyla güncellendi.";
                }
                _db.SaveChanges();

            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult UlkeSil(Ulke ulke)
        {
            if (ModelState.IsValid)
            {
                _db.Remove(ulke);
                TempData["Mesaj"] = $"\"{ulke.Ad}\" adlı ülke başarıyla silindi.";
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}