//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace rentacar_ASPNET.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class alquiler
    {
        public int idAlquiler { get; set; }
        public int idCliente { get; set; }
        public int idAuto { get; set; }
        public int idUsuario { get; set; }
        public System.DateTime fechaAlquiler { get; set; }
        public System.DateTime fechaDevolucion { get; set; }
        public float Precio { get; set; }
    
        public virtual cliente cliente { get; set; }
        public virtual auto auto { get; set; }
        public virtual usuarios usuarios { get; set; }
    }
}
