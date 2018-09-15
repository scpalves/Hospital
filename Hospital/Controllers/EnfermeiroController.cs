using Hospital.Models;
using Hospital.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital.Controllers
{
    public class EnfermeiroController : Controller
    {
      private HospitalEntities _context;

      public EnfermeiroController()
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
            var enfermeiro = _context.Enfermeiro.ToList().Where(w => w.Status == true);

            if (enfermeiro == null)
             return HttpNotFound();

            return View(enfermeiro);
        }


        public ActionResult AllEnfermeiros()
        {
            var enfermeiro = _context.Enfermeiro.ToList();

            if (enfermeiro == null)
                return HttpNotFound();

            return View(enfermeiro);
        }

    


        public ActionResult EnfermeiroInactivo()
        {

            var enfermeiro = _context.Enfermeiro.ToList().Where(w => w.Status == false);

            return View(enfermeiro);
        }

        public ActionResult New()
        {

            var viewModel = new EnfermeiroViewModel()
            {

            };
            return View("EnfermeiroForm", viewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Enfermeiro enfermeiro)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new EnfermeiroViewModel(enfermeiro)
                {

                };
                return View("EnfermeiroForm", viewModel);
            }

            if (enfermeiro.Id == 0)
            {
                enfermeiro.Status = true;
                _context.Enfermeiro.Add(enfermeiro);

            }
            else
            {
                enfermeiro.Status = true;
                var enfermeiroInBD = _context.Enfermeiro.Single(c => c.Id == enfermeiro.Id);

                enfermeiroInBD.FirstName = enfermeiro.FirstName;
                enfermeiroInBD.LastName = enfermeiro.LastName;
                enfermeiroInBD.Email = enfermeiro.Email;
                enfermeiroInBD.Contact = enfermeiro.Contact;
                enfermeiroInBD.Status = enfermeiro.Status;
            }

            _context.SaveChanges();



            return RedirectToAction("Index", "Enfermeiro");
        }


        public ActionResult Edit(int id)
        {
            var enfermeiro = _context.Enfermeiro.SingleOrDefault(c => c.Id == id);

            if (enfermeiro == null)
                return HttpNotFound();

            var viewModel = new EnfermeiroViewModel(enfermeiro)
            {

            };
            return View("EnfermeiroForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveDelete(Enfermeiro enfermeiro)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new EnfermeiroViewModel(enfermeiro)
                {

                };
                return View("Delete", viewModel);
            }

            enfermeiro.Status = false;
            var enfermeiroInBD = _context.Enfermeiro.Single(c => c.Id == enfermeiro.Id);

            enfermeiroInBD.FirstName = enfermeiro.FirstName;
            enfermeiroInBD.LastName = enfermeiro.LastName;
            enfermeiroInBD.Email = enfermeiro.Email;
            enfermeiroInBD.Contact = enfermeiro.Contact;
            enfermeiroInBD.Status = enfermeiro.Status;
           

            _context.SaveChanges();



            return RedirectToAction("Index", "Enfermeiro");
        }





        public ActionResult Delete(int id)
        {
            var enfermeiro = _context.Enfermeiro.SingleOrDefault(c => c.Id == id);

            if (enfermeiro == null)
                return HttpNotFound();

            var viewModel = new EnfermeiroViewModel(enfermeiro)
            {

            };
            return View("Delete", viewModel);
        }







        public ActionResult Details(int id)
        {
            var enfermeiro = _context.Enfermeiro.SingleOrDefault(c => c.Id == id);

            if (enfermeiro == null)
                return HttpNotFound();

            return View(enfermeiro);
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





    }
}