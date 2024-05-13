namespace Ejercicio3_324.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("transaccion")]
    public partial class transaccion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int? cuenta_origen_id { get; set; }

        public int? cuenta_destino_id { get; set; }

        public double? monto { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha { get; set; }

        public virtual cuenta cuenta { get; set; }

        public virtual cuenta cuenta1 { get; set; }
    }
}
