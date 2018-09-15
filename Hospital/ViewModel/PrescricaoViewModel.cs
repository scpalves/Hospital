using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital.ViewModel
{
    public class PrescricaoViewModel
    {

        public int Id { get; set; }
        public string Nome { get; set; }




        public string Title
        {
            get
            {
                if (Id != 0)
                    return "Edit Prescrição";

                return "New Prescrição";
            }

        }

        public PrescricaoViewModel()
        {
            Id = 0;
        }


        public PrescricaoViewModel(Prescricao prescricao)
        {
            Id = prescricao.Id;
            Nome = prescricao.Nome;


        }
    }
}