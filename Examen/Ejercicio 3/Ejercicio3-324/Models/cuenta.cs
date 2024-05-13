namespace Ejercicio3_324.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cuenta")]
    public partial class cuenta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cuenta()
        {
            transaccion = new HashSet<transaccion>();
            transaccion1 = new HashSet<transaccion>();
        }
        [Display(Name = "#")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Display(Name = "Persona id")]
        public int? persona_id { get; set; }

        [Display(Name = "Tipo cuenta")]
        [StringLength(50)]
        public string tipo_cuenta { get; set; }

        [Display(Name = "Saldo")]
        public double? saldo { get; set; }

        public virtual persona persona { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<transaccion> transaccion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<transaccion> transaccion1 { get; set; }
    }
}
