using Global.Dados;
using Global.Dados.Entidades;
using Global.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Global.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }



        public async Task<IActionResult> Servicos([Bind("Id,Nome,Email,Mensagem")] Contacto contacto)
        {
            ViewData["Message"] = "Os seus serviços.";

            if (ModelState.IsValid)
            {
                _context.Add(contacto);
                await _context.SaveChangesAsync();
                
            }
            return View(await _context.Contactos.ToListAsync());
        }





        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sobre()
        {
            ViewData["Message"] = "A descrição da sua empresa.";

            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

