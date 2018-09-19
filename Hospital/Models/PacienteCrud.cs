using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital.Models
{
    public class PacienteCrud
    {
 		private HospitalEntities db;

        public PacienteCrud()
		{
			db = new HospitalEntities();
		}

        public IEnumerable<Paciente> GetAll()
		{
			return db.Paciente.ToList();
		}
	}
}