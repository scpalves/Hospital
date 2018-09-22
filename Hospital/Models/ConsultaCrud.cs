using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hospital.Models
{
    public class ConsultaCrud
    {
        private HospitalEntities db;

        public ConsultaCrud()
        {
            db = new HospitalEntities();
        }

        public IEnumerable<Consulta> GetAll()
        {
            return db.Consulta.ToList();
        }

        public Consulta GetByID(int Id)
        {
            return db.Consulta.Find(Id);
        }



        public void Insert(Consulta consulta)
        {
            db.Consulta.Add(consulta);
            Save();
        }
        public void Delete(int Id)
        {
            Consulta consulta = db.Consulta.Find(Id);
            db.Consulta.Remove(consulta);
            Save();
        }
        public void Update(Consulta consulta)
        {
            db.Entry(consulta).State = EntityState.Modified;
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}