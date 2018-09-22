using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital.ViewModel
{
    public class ConsultaPacienteViewModel
    {

        public IQueryable <Consulta> consulta { get; set; }
        public Paciente Paciente { get; set; }

    }
}