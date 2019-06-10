using System;
using System.Collections.Generic;

namespace MgnWebApi.Models {
    public class Cliente  {
        public Int32 IdCliente { get; set; }
        public String Nome { get; set; }
        public String Cpf { get; set; }
        public String Rg { get; set; }
        public IEnumerable<Telefones> Telefones { get; set; }
        public Endereco Endereco { get; set; }


    }
}