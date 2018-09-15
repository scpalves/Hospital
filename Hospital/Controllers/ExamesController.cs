using Hospital.Models;
using Hospital.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Hospital.Controllers
{
    public class ExamesController : Controller
    {
        private HospitalEntities _context;

        public ExamesController()
        {
            _context = new HospitalEntities();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Medico
        public ActionResult Index()
        {
            var exame = _context.Exame.ToList();

            if (exame == null)
                return HttpNotFound();

            return View(exame);
        }


        public ActionResult New()
        {

            var viewModel = new ExamesViewModel()
            {

            };
            return View("ExameForm", viewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Exame exame)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ExamesViewModel(exame)
                {

                };
                return View("ExameForm", viewModel);
            }

            if (exame.Id == 0)
            {

                _context.Exame.Add(exame);

            }
            else
            {

                var exameInBD = _context.Exame.Single(c => c.Id == exame.Id);

                exameInBD.Name = exame.Name;
                exameInBD.Preco = exame.Preco;
   
            }

            _context.SaveChanges();



            return RedirectToAction("Index", "Exames");
        }

        public ActionResult Edit(int id)
        {
            var exame = _context.Exame.SingleOrDefault(c => c.Id == id);

            if (exame == null)
                return HttpNotFound();

            var viewModel = new ExamesViewModel(exame)
            {

            };
            return View("ExameForm", viewModel);
        }



        public ActionResult Details(int id)
        {
            var exame = _context.Exame.SingleOrDefault(c => c.Id == id);

            if (exame == null)
                return HttpNotFound();

            return View(exame);
        }



        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var examesInDb = _context.Exame.SingleOrDefault(c => c.Id == id);
            if (examesInDb == null)
            {
                return HttpNotFound();
            }
            return View(examesInDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var examesInDb = _context.Exame.SingleOrDefault(c => c.Id == id);
                _context.Exame.Remove(examesInDb);
               // TempData["Msg"] = "Contacto removido com sucesso";
                _context.SaveChanges();
                return RedirectToAction("Index", "Exames");
            }
            catch (Exception e1)
            {

                TempData["Msg"] = "Falha ao remover Contacto: " + e1.Message;
                return RedirectToAction("Index");
            }

        }


  
    }
}