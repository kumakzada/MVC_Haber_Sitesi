namespace HaberProjesi2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Haber")]
    public partial class Haber
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Haber()
        {
            Resim = new HashSet<Resim>();
            Yorum = new HashSet<Yorum>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string Baslik { get; set; }

        [StringLength(200)]
        public string Ozet { get; set; }

        [Column(TypeName = "ntext")]
        public string Icerik { get; set; }

        public DateTime? YayinTarih { get; set; }

        public int? YazarID { get; set; }

        public int? KategoriID { get; set; }

        public int? HaberTipi { get; set; }

        [StringLength(200)]
        public string VideoYol { get; set; }

        [StringLength(200)]
        public string ResimYol { get; set; }

        [StringLength(200)]
        public string KucukResimYol { get; set; }

        public int? Goruntulenme { get; set; }

        public virtual HaberTipi HaberTipi1 { get; set; }

        public virtual Kategori Kategori { get; set; }

        public virtual Yazar1 Yazar1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Resim> Resim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Yorum> Yorum { get; set; }
    }
}
