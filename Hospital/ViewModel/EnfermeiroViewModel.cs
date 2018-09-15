using Hospital.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital.ViewModel
{
    public class EnfermeiroViewModel
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

        public EnfermeiroViewModel()
        {
            Id = 0;
        }


        public EnfermeiroViewModel(Enfermeiro enfermeiro)
        {
            Id = enfermeiro.Id;
            FirstName = enfermeiro.FirstName;
            LastName = enfermeiro.LastName;
            Email = enfermeiro.Email;
            Contact = enfermeiro.Contact;
            Status = enfermeiro.Status;
        }


    }
}