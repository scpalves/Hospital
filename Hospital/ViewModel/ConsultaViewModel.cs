using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital.ViewModel
{
    public class ConsultaViewModel
    {

        public IEnumerable<Paciente> paciente { get; set; }
        public IEnumerable<Medico> medico { get; set; }
        public IEnumerable<Exame> exame { get; set; }
        public IEnumerable<Prescricao> prescricao { get; set; }
        public IEnumerable<Internamento> internamento { get; set; }

        public int Id { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdMedico { get; set; }
        public int? IdExames { get; set; }
        public int? IdPrescricao { get; set; }
        public int? IdInternamento { get; set; }
        public string Sintomas { get; set; }
        public DateTime? DataConsulta { get; set; }
        public string Diagnostico { get; set; }
        public  Exame Exame { get; set; }
        public  Internamento Internamento { get; set; }
        public  Medico Medico { get; set; }
        public  Paciente Paciente { get; set; }
        public  Prescricao Prescricao { get; set; }

     public string Title
        {
            get
            {
                if (Id != 0)
                    return "Edit Consulta";

                return "Nova Consulta";
            }

        }

        public ConsultaViewModel()
        {
            Id = 0;
        }


        public ConsultaViewModel(Consulta consulta)
        {
            Id = consulta.Id;
            IdPaciente = consulta.IdPaciente;
            IdMedico = consulta.IdMedico;
            IdExames = consulta.IdExames;
            IdPrescricao = consulta.IdPrescricao;
            //IdInternamento = consulta.IdInternamento;
            Sintomas = consulta.Sintomas;
            DataConsulta = consulta.DataConsulta;
            Diagnostico = consulta.Diagnostico;
            Exame = consulta.Exame;
            //Internamento = consulta.Internamento;
            Medico = consulta.Medico;
            Paciente = consulta.Paciente;
            Prescricao = consulta.Prescricao;

        }


    }



}