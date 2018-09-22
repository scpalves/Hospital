using Hospital.Models;
using Hospital.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital.Controllers
{
    public class ConsultaController : Controller
    {
        private HospitalEntities _context;

        private ConsultaCrud db;
        public ConsultaController()
        {
            _context = new HospitalEntities();

            db = new ConsultaCrud();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Medico
        public PartialViewResult Index(int id)
        {

            var consulta = _context.Consulta.Where(c => c.IdPaciente == id);


            return PartialView("_ConsultaList", consulta);
        }

        public ActionResult New( int id)
        {

             var paciente = _context.Paciente.ToList().Where(c => c.Id == id);
            var medico = _context.Medico.ToList().Where(w => w.Status == true);
            var exame = _context.Exame.ToList();
            var prescricao = _context.Prescricao.ToList();
            var internamento = _context.Internamento.ToList();


            var viewModel = new ConsultaViewModel()

            {
                paciente = paciente,
                medico = medico,
                exame = exame,
                prescricao = prescricao,
                internamento = internamento
            };
            return View("ConsultaForm", viewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Consulta consulta)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ConsultaViewModel(consulta)
                {
                    IdPaciente = consulta.IdPaciente,
                    paciente = _context.Paciente.ToList(),
                    medico = _context.Medico.ToList(),
                    exame = _context.Exame.ToList(),
                    prescricao = _context.Prescricao.ToList(),
                    internamento = _context.Internamento.ToList(),
                  

                };
                return View("ConsultaForm", viewModel);
            }

                 

                 consulta.DataConsulta = DateTime.Now;
                _context.Consulta.Add(consulta);

          

            _context.SaveChanges();



            return RedirectToAction("Details", "Paciente", new {@id= consulta.IdPaciente});
        }


    }
}