//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL_EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            this.VentaProductoes = new HashSet<VentaProducto>();
        }
    
        public int IdProducto { get; set; }
        public string ProductoNombre { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Stock { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> IdProvedor { get; set; }
        public Nullable<int> IdDepartamento { get; set; }
    
        public virtual Provedor Provedor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VentaProducto> VentaProductoes { get; set; }
        public virtual Departamento Departamento { get; set; }
    }
}
