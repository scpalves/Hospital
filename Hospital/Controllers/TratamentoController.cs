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
    public class TratamentoController : Controller
    {
        private HospitalEntities _context;

        public TratamentoController()
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
            var tratamento = _context.Tratamento.ToList();

            if (tratamento == null)
                return HttpNotFound();

            return View(tratamento);
        }


        public ActionResult New()
        {

            var viewModel = new TratamentoViewModel()
            {

            };
            return View("TratamentoForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Tratamento tratamento)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new TratamentoViewModel(tratamento)
                {

                };
                return View("TratamentoForm", viewModel);
            }

            if (tratamento.Id == 0)
            {

                _context.Tratamento.Add(tratamento);

            }
            else
            {

                var tratamentoInBD = _context.Tratamento.Single(c => c.Id == tratamento.Id);

                tratamentoInBD.Name = tratamento.Name;
                tratamentoInBD.Preco = tratamento.Preco;

            }

            _context.SaveChanges();



            return RedirectToAction("Index", "Tratamento");
        }

        public ActionResult Edit(int id)
        {
            var tratamento = _context.Tratamento.SingleOrDefault(c => c.Id == id);

            if (tratamento == null)
                return HttpNotFound();

            var viewModel = new TratamentoViewModel(tratamento)
            {

            };
            return View("TratamentoForm", viewModel);
        }



        public ActionResult Details(int id)
        {
            var tratamento = _context.Tratamento.SingleOrDefault(c => c.Id == id);

            if (tratamento == null)
                return HttpNotFound();

            return View(tratamento);
        }



        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tratamentoInBD = _context.Tratamento.SingleOrDefault(c => c.Id == id);
            if (tratamentoInBD == null)
            {
                return HttpNotFound();
            }
            return View(tratamentoInBD);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var tratamentoInBD = _context.Tratamento.SingleOrDefault(c => c.Id == id);
                _context.Tratamento.Remove(tratamentoInBD);
                // TempData["Msg"] = "Contacto removido com sucesso";
                _context.SaveChanges();
                return RedirectToAction("Index", "Tratamento");
            }
            catch (Exception e1)
            {

                TempData["Msg"] = "Falha ao remover Contacto: " + e1.Message;
                return RedirectToAction("Index");
            }

        }



    }
}