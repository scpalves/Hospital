using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hospital.Models;
using System.ComponentModel.DataAnnotations;

namespace Hospital.ViewModel
{
    public class MedicoViewModel
    {


        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public Nullable<bool> Status { get; set; }


        public string Title
        {
            get
            {
                if (Id != 0)
                    return "Edit Medico";

                return "New Medico";
            }

        }

        public MedicoViewModel()
        {
            Id = 0;
        }


        public MedicoViewModel(Medico medico)
        {
            Id = medico.Id;
            FirstName = medico.FirstName;
            LastName = medico.LastName;
            Email = medico.Email;
            Contact = medico.Contact;
            Status = medico.Status;
        }

    }
}