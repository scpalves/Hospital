using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital.Models
{
	public class EnfermeiroCrud
	{

		private HospitalEntities db;

		public EnfermeiroCrud()
		{
			db = new HospitalEntities();
		}

		public IEnumerable<Enfermeiro> GetAll()
		{
			return db.Enfermeiro.ToList();
		}
	}
}