using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital.Models
{
    public class MedicoCrud
    {
 		private HospitalEntities db;

        public MedicoCrud()
		{
			db = new HospitalEntities();
		}

        public IEnumerable<Medico> GetAll()
		{
			return db.Medico.ToList();
		}
	}
}