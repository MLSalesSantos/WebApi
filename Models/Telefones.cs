
using System;

/// <summary>
/// Summary description for Class1
/// </summary> 
namespace MgnWebApi.Models {

    public class Telefones {
        public Int32 TelefoneId { get; set; }
        public String Tipo { get; set; }
        public String Numero { get; set; }
        public Int32 ClienteId { get; set; }
    }
}