using System;
using System.Collections.Generic;
using MgnWebApi.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MgnWebApi.Interface {
    public interface IClienteRepository {
        IEnumerable<Cliente> GetAll();
        Cliente GetById(Int32 id);
        void Insert(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(Int32 id);
        void Save();
    }
}