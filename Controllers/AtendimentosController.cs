using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PacientesAtendimentos.Controllers
{
    public class AtendimentosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
