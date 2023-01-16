using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rentacar_ASPNET.Models.ViewModels
{
    public class AutoViewModel
    {
        public int idauto { get; set; }
        [Required]
        [Display(Name = "Marca")]
        public string marca { get; set; }
        [Required]
        [Display(Name = "Placa")]
        public string placa { get; set; }
        [Required]
        [Display(Name = "Tipo")]
        public string tipo { get; set; }
        [Required]
        [Display(Name = "Estado")]
        public string estado { get; set; }
        [Required]
        [Display(Name = "Estado de Alquiler")]
        public int estadoAlquiler { get; set; }
        [Display(Name = "Foto")]
        public byte[] fotoAuto { get; set; }
    }
}