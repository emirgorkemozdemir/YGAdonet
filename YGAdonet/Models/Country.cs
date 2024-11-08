//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YGAdonet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Country
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Country()
        {
            this.Person = new HashSet<Person>();
        }
    
        public int CountryID { get; set; }

        [Required (ErrorMessage ="�lke ad� bo� b�rak�lamaz.")]
        [MaxLength(20,ErrorMessage ="�lke ad� 20 karakterden fazla olamaz.")]
        public string CountryName { get; set; }

        [Required(ErrorMessage = "�lkedeki kay�tl� ki�i say�s� bo� b�rak�lamaz.")]
        public int CountryCount { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> Person { get; set; }
    }
}
