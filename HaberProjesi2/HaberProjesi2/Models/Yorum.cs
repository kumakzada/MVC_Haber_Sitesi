namespace HaberProjesi2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Yorum")]
    public partial class Yorum
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Yorum()
        {
            Kullanici = new HashSet<Kullanici>();
        }

        public int ID { get; set; }

        public int? HaberID { get; set; }

        [StringLength(110)]
        public string Baslik { get; set; }

        [StringLength(50)]
        public string IP { get; set; }

        [StringLength(50)]
        public string Ad { get; set; }

        [StringLength(50)]
        public string Soyad { get; set; }

        [StringLength(100)]
        public string Mail { get; set; }

        public DateTime? Tarih { get; set; }

        public bool? Onayli { get; set; }

        public int? Begeni { get; set; }

        public int? Tiksinti { get; set; }

        public virtual Haber Haber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kullanici> Kullanici { get; set; }
    }
}
