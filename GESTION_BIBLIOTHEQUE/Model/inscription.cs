//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GESTION_BIBLIOTHEQUE.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class inscription
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public inscription()
        {
            this.pret = new HashSet<pret>();
        }
    
        public int id { get; set; }
        public string matricule { get; set; }
        public Nullable<System.DateTime> date_inscription { get; set; }
        public Nullable<System.DateTime> date_echeance { get; set; }
        public Nullable<int> montant_ins { get; set; }
        public Nullable<int> statut { get; set; }
        public Nullable<int> client_id { get; set; }
        public Nullable<int> admin_id { get; set; }
        public Nullable<int> delet { get; set; }
    
        public virtual admins admins { get; set; }
        public virtual client client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pret> pret { get; set; }
    }
}