namespace HaberProjesi2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Yazar1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Yazar1()
        {
            Haber = new HashSet<Haber>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string YazarAd { get; set; }

        [StringLength(50)]
        public string Soyad { get; set; }

        [Required]
        [StringLength(50)]
        public string Mail { get; set; }

        [Required]
        [StringLength(50)]
        public string Sifre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Haber> Haber { get; set; }
    }
}
