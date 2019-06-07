using System.Linq;
using MgnWebApi.vscode.Models;
using Microsoft.AspNetCore.Mvc;

namespace MgnWebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
     private readonly EnderecoContext _context;

     public EnderecoController(EnderecoContext context)
     {
         _context = context;

         if (_context.Endereco.Count() == 0)
         {
             _context.Endereco.Add(new Endereco { Cep = 20766041,
                                                  Logradouro = "Endereço do clientes",
                                                  Numero = 123,
                                                  Bairro = "Bairro",
                                                  Municipio = "Municipio",
                                                  Uf = "RJ" });
            _context.SaveChanges();
         }
     }
   
        
    }
}