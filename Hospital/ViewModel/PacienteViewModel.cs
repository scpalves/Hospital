using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital.ViewModel
{
    public class PacienteViewModel
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Genero { get; set; }
        public string GrupoSanguineo { get; set; }
        public string Address { get; set; }
        public string Localidade { get; set; }
        public DateTime? DataNascimento { get; set; }

        public string Title
        {
            get
            {
                if (Id != 0)
                    return "Edit Paciente";

                return "New Paciente";
            }

        }

        public PacienteViewModel()
        {
            Id = 0;
        }


        public PacienteViewModel(Paciente paciente)
        {
            Id = paciente.Id;
            FirstName = paciente.FirstName;
            LastName = paciente.LastName;
            Email = paciente.Email;
            Contact = paciente.Contact;
            Genero = paciente.Genero;
            GrupoSanguineo = paciente.GrupoSanguineo;
            Address = paciente.Address;
            Localidade = paciente.Localidade;
            DataNascimento = paciente.DataNascimento;
        }

    }
}