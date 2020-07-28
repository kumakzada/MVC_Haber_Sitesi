namespace HaberProjesi2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Resim")]
    public partial class Resim
    {
        public int ID { get; set; }

        public int? HaberID { get; set; }

        [StringLength(150)]
        public string Ozet { get; set; }

        [StringLength(150)]
        public string ResimYol { get; set; }

        [StringLength(150)]
        public string KucukResimYol { get; set; }

        public virtual Haber Haber { get; set; }
    }
}
