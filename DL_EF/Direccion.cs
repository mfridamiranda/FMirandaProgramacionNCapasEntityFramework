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
    
    public partial class Direccion
    {
        public int IdDireccion { get; set; }
        public string NumeroInterior { get; set; }
        public string NumeroExterior { get; set; }
        public int IdUsuario { get; set; }
        public int IdColonia { get; set; }
        public string Calle { get; set; }
    
        public virtual Colonia Colonia { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
