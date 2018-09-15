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
    public class PrescricaoController : Controller
  {
        private HospitalEntities _context;

        public PrescricaoController()
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
            var prescricao = _context.Prescricao.ToList();

            if (prescricao == null)
                return HttpNotFound();

            return View(prescricao);
        }

        public ActionResult New()
        {

            var viewModel = new PrescricaoViewModel()
            {

            };
            return View("PrescricaoForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Prescricao prescricao)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new PrescricaoViewModel(prescricao)
                {

                };
                return View("PrescricaoForm", viewModel);
            }

            if (prescricao.Id == 0)
            {

                _context.Prescricao.Add(prescricao);

            }
            else
            {

                var prescricaoInBD = _context.Prescricao.Single(c => c.Id == prescricao.Id);

                prescricaoInBD.Nome = prescricao.Nome;
              

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Prescricao");
        }



        public ActionResult Edit(int id)
        {
            var prescricao = _context.Prescricao.SingleOrDefault(c => c.Id == id);

            if (prescricao == null)
                return HttpNotFound();

            var viewModel = new PrescricaoViewModel(prescricao)
            {

            };
            return View("PrescricaoForm", viewModel);
        }



        public ActionResult Details(int id)
        {
            var prescricao = _context.Prescricao.SingleOrDefault(c => c.Id == id);

            if (prescricao == null)
                return HttpNotFound();

            return View(prescricao);
        }



        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var prescricaoInBD = _context.Prescricao.SingleOrDefault(c => c.Id == id);
            if (prescricaoInBD == null)
            {
                return HttpNotFound();
            }
            return View(prescricaoInBD);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var prescricaoInBD = _context.Prescricao.SingleOrDefault(c => c.Id == id);
                _context.Prescricao.Remove(prescricaoInBD);
                // TempData["Msg"] = "Contacto removido com sucesso";
                _context.SaveChanges();
                return RedirectToAction("Index", "Prescricao");
            }
            catch (Exception e1)
            {

                TempData["Msg"] = "Falha ao remover Contacto: " + e1.Message;
                return RedirectToAction("Index");
            }

        }

    }
}