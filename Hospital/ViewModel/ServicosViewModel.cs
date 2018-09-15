using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital.ViewModel
{
    public class ServicosViewModel
    {

        public int Id { get; set; }
        public string Nome { get; set; }


                public string Title
        {
            get
            {
                if (Id != 0)
                    return "Edit Servicos";

                return "New Servicos";
            }

        }

        public ServicosViewModel()
        {
            Id = 0;
        }


        public ServicosViewModel(Servicos servicos)
        {
            Id = servicos.Id;
            Nome = servicos.Nome;


        }
    }
}