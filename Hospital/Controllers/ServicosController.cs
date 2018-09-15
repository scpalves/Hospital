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
    public class ServicosController : Controller
{
        private HospitalEntities _context;

        public ServicosController()
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
            var servicos = _context.Servicos.ToList();

            if (servicos == null)
                return HttpNotFound();

            return View(servicos);
        }

        public ActionResult New()
        {

            var viewModel = new ServicosViewModel()
            {

            };
            return View("ServicosForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Servicos servicos)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ServicosViewModel(servicos)
                {

                };
                return View("ServicosForm", viewModel);
            }

            if (servicos.Id == 0)
            {

                _context.Servicos.Add(servicos);

            }
            else
            {

                var servicosInBD = _context.Servicos.Single(c => c.Id == servicos.Id);

                servicosInBD.Nome = servicos.Nome;
              

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Servicos");
        }



        public ActionResult Edit(int id)
        {
            var servicos = _context.Servicos.SingleOrDefault(c => c.Id == id);

            if (servicos == null)
                return HttpNotFound();

            var viewModel = new ServicosViewModel(servicos)
            {

            };
            return View("ServicosForm", viewModel);
        }



        public ActionResult Details(int id)
        {
            var servicos = _context.Servicos.SingleOrDefault(c => c.Id == id);

            if (servicos == null)
                return HttpNotFound();

            return View(servicos);
        }



        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var servicosInBD = _context.Servicos.SingleOrDefault(c => c.Id == id);
            if (servicosInBD == null)
            {
                return HttpNotFound();
            }
            return View(servicosInBD);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var servicosInBD = _context.Servicos.SingleOrDefault(c => c.Id == id);
                _context.Servicos.Remove(servicosInBD);
                // TempData["Msg"] = "Contacto removido com sucesso";
                _context.SaveChanges();
                return RedirectToAction("Index", "Servicos");
            }
            catch (Exception e1)
            {

                TempData["Msg"] = "Falha ao remover Contacto: " + e1.Message;
                return RedirectToAction("Index");
            }

        }

    }
}