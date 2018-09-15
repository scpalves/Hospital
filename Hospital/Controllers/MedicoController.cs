using Hospital.Models;
using Hospital.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital.Controllers
{
    public class MedicoController : Controller
    {
        private HospitalEntities _context;

        public MedicoController()
        {
            _context= new HospitalEntities();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Medico
        public ActionResult Index()
        {
            var medico = _context.Medico.ToList().Where(w => w.Status == true);
                                     
            if (medico == null)
             return HttpNotFound();

            return View( medico);
        }


        public ActionResult AllMedicos()
        {
            var medico = _context.Medico.ToList();

            if (medico == null)
                return HttpNotFound();

            return View(medico);
        }

    


        public ActionResult MedicosInactivos()
        {

            var medico = _context.Medico.ToList().Where(w => w.Status == false);

            return View(medico);
        }

        public ActionResult New()
        {
            
            var viewModel = new MedicoViewModel()
            {

            };
            return View("MedicoForm", viewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Medico medico)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MedicoViewModel(medico)
                {

                };
                return View("MedicoForm", viewModel);
            }

            if (medico.Id == 0)
            {
                   medico.Status = true;
                _context.Medico.Add(medico);

            }
            else
            {
                medico.Status = true;
                var medicoInBD = _context.Medico.Single(c => c.Id == medico.Id);

                medicoInBD.FirstName = medico.FirstName;
                medicoInBD.LastName = medico.LastName;
                medicoInBD.Email = medico.Email;
                medicoInBD.Contact = medico.Contact;
                medicoInBD.Status = medico.Status;
            }

            _context.SaveChanges();



            return RedirectToAction("Index", "Medico");
        }


        public ActionResult Edit(int id)
        {
            var medico = _context.Medico.SingleOrDefault(c => c.Id == id);

            if (medico == null)
                return HttpNotFound();

            var viewModel = new MedicoViewModel(medico)
            {

            };
            return View("MedicoForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveDelete(Medico medico)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MedicoViewModel(medico)
                {

                };
                return View("Delete", viewModel);
            }

                medico.Status = false;
                var medicoInBD = _context.Medico.Single(c => c.Id == medico.Id);

                medicoInBD.FirstName = medico.FirstName;
                medicoInBD.LastName = medico.LastName;
                medicoInBD.Email = medico.Email;
                medicoInBD.Contact = medico.Contact;
                medicoInBD.Status = medico.Status;
           

            _context.SaveChanges();



            return RedirectToAction("Index", "Medico");
        }





        public ActionResult Delete(int id)
        {
            var medico = _context.Medico.SingleOrDefault(c => c.Id == id);

            if (medico == null)
                return HttpNotFound();

            var viewModel = new MedicoViewModel(medico)
            {

            };
            return View("Delete", viewModel);
        }







        public ActionResult Details(int id)
        {
            var medico = _context.Medico.SingleOrDefault(c => c.Id == id);

            if (medico == null)
                return HttpNotFound();

            return View(medico);
        }




        //public ActionResult Delete(int id)
        //{


        //    var medico = _context.Medico.SingleOrDefault(c => c.Id == id);

        //            if (medico == null)
        //        return HttpNotFound();

        //    var viewModel = new MedicoViewModel(medico)
        //    {

        //    };
        //    return View("Delete", viewModel);
        //}




        //public ActionResult Delete(int id)
        //{

          
        //    var medico = _context.Medico.SingleOrDefault(c => c.Id == id);
            
        //     medico.Status =  false;

        //     _context.Entry(medico).State = EntityState.Modified;

        //     _context.SaveChanges();
        //    if (medico == null)
        //        return HttpNotFound();

        //    var viewModel = new MedicoViewModel(medico)
        //    {
                
        //    };
        //    return View("Delete", viewModel);
        //}




        //public ActionResult Edit(int id)
        //{
        //    var medico = _context.Medico.SingleOrDefault(c => c.Id == id);

        //    if (medico == null)
        //        return HttpNotFound();

        //    var viewModel = new MedicoViewModel(medico)
        //    {

        //    };
        //    return View("MedicoForm", viewModel);
        //}



    }
}