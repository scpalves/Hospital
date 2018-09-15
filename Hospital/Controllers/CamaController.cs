using Hospital.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.ViewModel;

namespace Hospital.Controllers
{
    public class CamaController : Controller
    {


      private HospitalEntities _context;

             public CamaController()
        {
            _context = new HospitalEntities();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Cama
        public ActionResult Index()
        {

            var cama = _context.Cama.Include(c => c.Servicos).ToList();

            return View(cama);
        }


        public ActionResult New()
        {
            var servicos = _context.Servicos.ToList();
            var viewModel = new CamaFormViewModel
            {
                Cama = new Cama(),
                Servicos = servicos
            };
            return View("CamaForm", viewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Cama cama)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CamaFormViewModel
                {
                    Cama = cama,
                    Servicos = _context.Servicos.ToList()

                };
                return View("CamaForm", viewModel);
            }
            if (cama.Id == 0)
            {
                _context.Cama.Add(cama);

            }
            else
            {
                var camaInBD = _context.Cama.Single(c => c.Id == cama.Id);

                camaInBD.Name = cama.Name;
                camaInBD.TotalCamas = cama.TotalCamas;
                camaInBD.IdServico = cama.IdServico;
                
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Cama");
        }


        public ActionResult Details(int id)
        {
            var cama = _context.Cama.Include(c => c.Servicos).SingleOrDefault(c => c.Id == id);

            if (cama == null)
                return HttpNotFound();

            return View(cama);
        }


        public ActionResult Edit(int id)
        {
            var cama = _context.Cama.SingleOrDefault(c => c.Id == id);

            if (cama == null)
                return HttpNotFound();

            var viewModel = new CamaFormViewModel
            {
                Cama = cama,
                Servicos = _context.Servicos.ToList()
            };
            return View("CamaForm", viewModel);
        }



    }
}