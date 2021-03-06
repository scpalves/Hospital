//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hospital.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Internamento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Internamento()
        {
            this.Fatura = new HashSet<Fatura>();
        }
    
        public int Id { get; set; }
        public Nullable<int> IdTratamento { get; set; }
        public Nullable<int> IdCama { get; set; }
        public Nullable<int> IdEnfermeiro { get; set; }
        public int DiasInternamento { get; set; }
        public Nullable<System.DateTime> DataInternamento { get; set; }
        public decimal Preco { get; set; }
        public string NomeInternamento { get; set; }
        public Nullable<int> IdConsulta { get; set; }
    
        public virtual Cama Cama { get; set; }
        public virtual Consulta Consulta { get; set; }
        public virtual Enfermeiro Enfermeiro { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fatura> Fatura { get; set; }
        public virtual Tratamento Tratamento { get; set; }
    }
}
