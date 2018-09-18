using Hospital.Models;
using Hospital.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace Hospital.Controllers
{
	public class EnfermeiroController : Controller
	{
		private HospitalEntities _context;

		private EnfermeiroCrud db;

		public EnfermeiroController()
		{
			_context = new HospitalEntities();

			db = new EnfermeiroCrud();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		// GET: Medico
		public ActionResult Index(string SortOrder, string SortBy, string Page)
		{
			ViewBag.SortOrder = SortOrder;
			ViewBag.SortBy = SortBy;
			var enfermeiro = _context.Enfermeiro.ToList().Where(w => w.Status == true);

			switch (SortBy)
			{
				case "FirstName":
					switch (SortOrder)
					{
						case "Asc":
							enfermeiro = enfermeiro.OrderBy(x => x.FirstName).ToList();
							break;
						case "Desc":
							enfermeiro = enfermeiro.OrderByDescending(x => x.FirstName).ToList();
							break;
						default:

							break;

					}
					break;

				case "LastName":
					switch (SortOrder)
					{
						case "Asc":
							enfermeiro = enfermeiro.OrderBy(x => x.LastName).ToList();
							break;
						case "Desc":
							enfermeiro = enfermeiro.OrderByDescending(x => x.LastName).ToList();
							break;
						default:

							break;

					}

					break;

				case "Email":
					switch (SortOrder)
					{
						case "Asc":
							enfermeiro = enfermeiro.OrderBy(x => x.Email).ToList();
							break;
						case "Desc":
							enfermeiro = enfermeiro.OrderByDescending(x => x.Email).ToList();
							break;
						default:

							break;

					}
					break;


				case "Contact":
					switch (SortOrder)
					{
						case "Asc":
							enfermeiro = enfermeiro.OrderBy(x => x.Contact).ToList();
							break;
						case "Desc":
							enfermeiro = enfermeiro.OrderByDescending(x => x.Contact).ToList();
							break;
						default:

							break;

					}
					break;


				case "Status":
					switch (SortOrder)
					{
						case "Asc":
							enfermeiro = enfermeiro.OrderBy(x => x.Status).ToList();
							break;
						case "Desc":
							enfermeiro = enfermeiro.OrderByDescending(x => x.Status).ToList();
							break;
						default:

							break;

					}
					break;

				default:
					enfermeiro = enfermeiro.OrderBy(x => x.FirstName).ToList();

					break;

	
			}

			ViewBag.TotalPages = Math.Ceiling(db.GetAll().Where(x => x.Status == true).Count()/10.0);
			int page = int.Parse(Page == null ? "1" : Page);
			ViewBag.Page = page;
			enfermeiro = enfermeiro.Skip((page - 1)*10).Take(10);
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