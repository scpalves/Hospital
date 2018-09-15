using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital.ViewModel
{
    public class TratamentoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Preco { get; set; }


          public string Title
        {
            get
            {
                if (Id != 0)
                    return "Edit Tratamento";

                return "New Tratamento";
            }

        }

        public TratamentoViewModel()
        {
            Id = 0;
        }


        public TratamentoViewModel(Tratamento tratamento)
        {
            Id = tratamento.Id;
            Name = tratamento.Name;
            Preco = tratamento.Preco;

        }


    }
}