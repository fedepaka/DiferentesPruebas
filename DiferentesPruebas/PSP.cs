//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiferentesPruebas
{
    using System;
    using System.Collections.Generic;
    
    public partial class PSP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PSP()
        {
            this.SUSCRIBER = new HashSet<SUSCRIBER>();
        }
    
        public long ID { get; set; }
        public string NAME { get; set; }
        public long CREATED_USER_ID { get; set; }
        public Nullable<long> MODIFIED_USER_ID { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public Nullable<System.DateTime> MODIFIED_DATE { get; set; }
        public byte DELETED { get; set; }
        public Nullable<System.DateTime> DELETED_DATE { get; set; }
        public Nullable<byte> ENABLED { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUSCRIBER> SUSCRIBER { get; set; }
    }
}
