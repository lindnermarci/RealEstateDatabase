// <copyright company="SomeCompany" file="Ingatlan.cs">
// Copyright � Some Company, 2011
// </copyright>
// <auto-generated />

namespace RealEstate.Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ingatlan")]
    public partial class Ingatlan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ingatlan()
        {
            Szerzodes = new HashSet<Szerzodes>();
            Tulajdonos = new HashSet<Tulajdonos>();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "ID")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ingatlan(int ing_ID, string cim, string tipus, int alapterulet, int szobaDb)
        {
            this.Ing_ID = ing_ID;
            this.Cim = cim;
            this.Tipus = tipus;
            this.Alapterulet = alapterulet;
            this.SzobaDb = szobaDb;
            Szerzodes = new HashSet<Szerzodes>();
            Tulajdonos = new HashSet<Tulajdonos>();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Ing_ID { get; set; }

        [StringLength(70)]
        public string Cim { get; set; }

        [StringLength(20)]
        public string Tipus { get; set; }

        public int? Alapterulet { get; set; }

        public int? SzobaDb { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Szerzodes> Szerzodes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tulajdonos> Tulajdonos { get; set; }
    }
}
