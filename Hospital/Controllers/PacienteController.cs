using Hospital.Models;
using Hospital.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital.Controllers
{
    public class PacienteController : Controller
    {
        private HospitalEntities _context;

        private PacienteCrud db;

        public PacienteController()
        {
            _context = new HospitalEntities();

            db = new PacienteCrud();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult Index(string SortOrder, string SortBy, string Page, string SearchString, int? pages, string currentFilter)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;




            if (SearchString != null)
            {
                pages = 1;
            }
            else
            {
                SearchString = currentFilter;
            }

            ViewBag.CurrentFilter = SearchString;

            var paciente = from p in _context.Paciente

                           select p;


            if (!String.IsNullOrEmpty(SearchString))
            {
                paciente = _context.Paciente.Where(s => s.FirstName.ToUpper().Contains(SearchString.ToUpper()));

            }



            switch (SortBy)
            {
                case "FirstName":
                    switch (SortOrder)
                    {
                        case "Asc":
                            paciente = paciente.OrderBy(x => x.FirstName);
                            break;
                        case "Desc":
                            paciente = paciente.OrderByDescending(x => x.FirstName);
                            break;
                        default:

                            break;

                    }
                    break;

                case "LastName":
                    switch (SortOrder)
                    {
                        case "Asc":
                            paciente = paciente.OrderBy(x => x.LastName);
                            break;
                        case "Desc":
                            paciente = paciente.OrderByDescending(x => x.LastName);
                            break;
                        default:

                            break;

                    }

                    break;

                case "Email":
                    switch (SortOrder)
                    {
                        case "Asc":
                            paciente = paciente.OrderBy(x => x.Email);
                            break;
                        case "Desc":
                            paciente = paciente.OrderByDescending(x => x.Email);
                            break;
                        default:

                            break;

                    }
                    break;


                case "Contact":
                    switch (SortOrder)
                    {
                        case "Asc":
                            paciente = paciente.OrderBy(x => x.Contact);
                            break;
                        case "Desc":
                            paciente = paciente.OrderByDescending(x => x.Contact);
                            break;
                        default:

                            break;

                    }
                    break;


                case "Genero":
                    switch (SortOrder)
                    {
                        case "Asc":
                            paciente = paciente.OrderBy(x => x.Genero);
                            break;
                        case "Desc":
                            paciente = paciente.OrderByDescending(x => x.Genero);
                            break;
                        default:

                            break;

                    }
                    break;

                default:
                    paciente = paciente.OrderBy(x => x.FirstName);

                    break;


            }

            ViewBag.TotalPages = Math.Ceiling(db.GetAll().Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;
            paciente = paciente.Skip((page - 1) * 10).Take(10);
            return View(paciente);
        }

        public ActionResult New()
        {

            var viewModel = new PacienteViewModel()
            {

            };
            return View("PacienteForm", viewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new PacienteViewModel(paciente)
                {

                };
                return View("PacienteForm", viewModel);
            }

            if (paciente.Id == 0)
            {

                _context.Paciente.Add(paciente);

            }
            else
            {

                var pacienteInBD = _context.Paciente.Single(c => c.Id == paciente.Id);

                pacienteInBD.FirstName = paciente.FirstName;
                pacienteInBD.LastName = paciente.LastName;
                pacienteInBD.Email = paciente.Email;
                pacienteInBD.Contact = paciente.Contact;
                pacienteInBD.Genero = paciente.Genero;
                pacienteInBD.GrupoSanguineo = paciente.GrupoSanguineo;
                pacienteInBD.Address = paciente.Address;
                pacienteInBD.Localidade = paciente.Localidade;
                pacienteInBD.DataNascimento = paciente.DataNascimento;
            }

            _context.SaveChanges();



            return RedirectToAction("Index", "Paciente");
        }


        public ActionResult Edit(int id)
        {
            var paciente = _context.Paciente.SingleOrDefault(c => c.Id == id);

            if (paciente == null)
                return HttpNotFound();

            var viewModel = new PacienteViewModel(paciente)
            {

            };
            return View("PacienteForm", viewModel);
        }





        public ActionResult Details(int id)
        {
            var paciente = _context.Paciente.SingleOrDefault(c => c.Id == id);

            if (paciente == null)
                return HttpNotFound();

            return View(paciente);
        }




        


    }
}