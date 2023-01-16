using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rentacar_ASPNET.Models.ViewModels
{
    public class ListAutoViewModel
    {
        public int idauto { get; set; }
        public string marca { get; set; }
        public string placa { get; set; }
        public string tipo { get; set; }

        public string estado { get; set; }

        public int estadoAlquiler { get; set; }
        public byte[] fotoAuto { get; set; }



    }
}