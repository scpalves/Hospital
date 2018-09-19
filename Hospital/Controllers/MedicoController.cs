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

        private MedicoCrud db;

       public MedicoController()
		{
			_context = new HospitalEntities();

			db = new MedicoCrud();
		}

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

 


        public ActionResult Index(string SortOrder, string SortBy, string Page, string SearchString, int? pages, string currentFilter)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var medico = _context.Medico.ToList().Where(w => w.Status == true);



            if (SearchString != null)
            {
                pages = 1;
            }
            else
            {
                SearchString = currentFilter;
            }

            ViewBag.CurrentFilter = SearchString;


            if (!String.IsNullOrEmpty(SearchString))
            {
                medico = _context.Medico.Where(s => s.FirstName.ToUpper().Contains(SearchString.ToUpper()));

            }



            switch (SortBy)
            {
                case "FirstName":
                    switch (SortOrder)
                    {
                        case "Asc":
                            medico = medico.OrderBy(x => x.FirstName).ToList();
                            break;
                        case "Desc":
                            medico = medico.OrderByDescending(x => x.FirstName).ToList();
                            break;
                        default:

                            break;

                    }
                    break;

                case "LastName":
                    switch (SortOrder)
                    {
                        case "Asc":
                            medico = medico.OrderBy(x => x.LastName).ToList();
                            break;
                        case "Desc":
                            medico = medico.OrderByDescending(x => x.LastName).ToList();
                            break;
                        default:

                            break;

                    }

                    break;

                case "Email":
                    switch (SortOrder)
                    {
                        case "Asc":
                            medico = medico.OrderBy(x => x.Email).ToList();
                            break;
                        case "Desc":
                            medico = medico.OrderByDescending(x => x.Email).ToList();
                            break;
                        default:

                            break;

                    }
                    break;


                case "Contact":
                    switch (SortOrder)
                    {
                        case "Asc":
                            medico = medico.OrderBy(x => x.Contact).ToList();
                            break;
                        case "Desc":
                            medico = medico.OrderByDescending(x => x.Contact).ToList();
                            break;
                        default:

                            break;

                    }
                    break;


                case "Status":
                    switch (SortOrder)
                    {
                        case "Asc":
                            medico = medico.OrderBy(x => x.Status).ToList();
                            break;
                        case "Desc":
                            medico = medico.OrderByDescending(x => x.Status).ToList();
                            break;
                        default:

                            break;

                    }
                    break;

                default:
                    medico = medico.OrderBy(x => x.FirstName).ToList();

                    break;


            }

            ViewBag.TotalPages = Math.Ceiling(db.GetAll().Where(x => x.Status == true).Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;
            medico = medico.Skip((page - 1) * 10).Take(10);
            return View(medico);
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