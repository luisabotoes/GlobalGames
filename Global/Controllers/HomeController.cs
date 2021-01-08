using Global.Dados;
using Global.Dados.Entidades;
using Global.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sobre()
        {
            ViewData["Message"] = "A descrição da sua empresa.";

            return View();
        }

        public IActionResult Create()
        {
            ViewData["Message"] = "Os seus serviços.";
            return View();
        }

        public IActionResult Inscricoes()
        {
            ViewData["Mensagem"] = "Inscrição feita com sucesso.";
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Mensagem")] Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contacto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(await _context.Contactos.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Inscricoes([Bind("Id,Nome,Apelido,Morada,Localidade,CartaoCidadao,DataNascimento")] Inscricao inscricao)
        {       
            if (ModelState.IsValid)
            {
                _context.Add(inscricao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Inscricoes) );
            }
            return View(await _context.Inscricoes.ToListAsync());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

