using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CursoOnline.Dominio.Web.Models;

namespace CursoOnline.Dominio.Web.Controllers
{
    public class CursoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Novo()
        {
            return View();
        }

        public IActionResult Salvar()
        {
            return View();
        }
    }
}
