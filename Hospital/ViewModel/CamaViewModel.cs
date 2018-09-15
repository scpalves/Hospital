using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital.ViewModel
{
    public class CamaFormViewModel
    {

        public IEnumerable<Servicos> Servicos { get; set; }
        public Cama Cama { get; set; }



        public string Title
        {
            get
            {
                if (Cama != null && Cama.Id != 0)
                    return "Edit Cama";

                return "New Cama";
            }

        }
    }
}