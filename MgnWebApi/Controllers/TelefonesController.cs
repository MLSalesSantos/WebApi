using System.Linq;
using MgnWebApi.vscode.Models;
using Microsoft.AspNetCore.Mvc;

namespace MgnWebApi.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class TelefonesController : ControllerBase {
        private readonly TelefonesContext _context;

        public TelefonesController(TelefonesContext context) {
            _context = context;

            if (_context.Telefones.Count() == 0) {
                _context.Telefones.Add(new Telefones { Tipo = "Tipo",
                                                        Numero = 999548265 });
                _context.SaveChanges();
            }
        }
    }
}