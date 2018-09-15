using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital.ViewModel
{
    public class ExamesViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Preco { get; set; }



        public string Title
        {
            get
            {
                if (Id != 0)
                    return "Edit Exame";

                return "New Exame";
            }

        }

        public ExamesViewModel()
        {
            Id = 0;
        }


        public ExamesViewModel(Exame exame)
        {
            Id = exame.Id;
            Name = exame.Name;
            Preco = exame.Preco;

        }
    }
    }