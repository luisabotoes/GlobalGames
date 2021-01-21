using Global.Dados;
using Global.Dados.Entidades;
using Global.Helpers;
using Global.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Global.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;
        private readonly IUserHelper userHelper;

        public HomeController(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            this.userHelper = userHelper;
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
        public async Task<IActionResult> Inscricoes([Bind("Id,Nome,Apelido,Morada,ImageFile,Localidade,CartaoCidadao,DataNascimento")] InscricaoViewModel view)
        {       
            if (ModelState.IsValid)
            {

                var path = string.Empty;

                if (view.ImageFile != null && view.ImageFile.Length > 0)
                {

                    path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\ImgInscricoes",
                        view.ImageFile.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/imginscricoes/{view.ImageFile.FileName}";
                }

                var inscricao = this.ToInscricao(view, path);

               
                _context.Add(inscricao);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Inscricoes));


            }
            return View(view);

        }

        private Inscricao ToInscricao(InscricaoViewModel view, string path)
        {
            return new Inscricao
            {
                Id = view.Id,
                ImageUrl = path,
                Nome = view.Nome,
                Apelido = view.Apelido,
                Morada = view.Morada,
                Localidade = view.Localidade,
                CartaoCidadao = view.CartaoCidadao,
                DataNascimento = view.DataNascimento

            };
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}

