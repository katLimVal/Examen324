namespace Ejercicio3_324.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("persona")]
    public partial class persona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public persona()
        {
            cuenta = new HashSet<cuenta>();
        }

        [Key]
        [Display(Name = "Ci")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ci { get; set; }

        [Display(Name ="Nombre")]
        [StringLength(100)]
        public string nombre { get; set; }

        [Display(Name = "Apellido Paterno")]
        [StringLength(100)]
        public string apellidop { get; set; }

        [Display(Name = "Apellido Materno")]
        [StringLength(100)]
        public string apellidom { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cuenta> cuenta { get; set; }
    }
}
