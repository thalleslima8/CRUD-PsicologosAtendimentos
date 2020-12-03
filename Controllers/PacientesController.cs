using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PacientesAtendimentos.Data;
using PacientesAtendimentos.Models;
using PacientesAtendimentos.Models.Enums;
using PacientesAtendimentos.Models.ViewModel;
using PacientesAtendimentos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PacientesAtendimentos.Controllers
{
    public class PacientesController : Controller
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IAtendimentoRepository _atendimentoRepository;

        public PacientesController(DataContext context, IPacienteRepository pacienteRepository, IAtendimentoRepository atendimentoRepository)
        {
            _pacienteRepository = pacienteRepository;
            _atendimentoRepository = atendimentoRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var pacientes = _pacienteRepository.GetAll();
            //var atendimentos = _atendimentoRepository.GetAll();
            //var model = new PacienteViewModel()
            //{
            //    Pacientes = pacientes,
            //    Atendimentos = atendimentos
            //};
            return View(pacientes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var atendimentos = _atendimentoRepository.GetAll();
            var Sexos = Enum.GetValues(typeof(Sexo)).Cast<Sexo>().ToList();
            var EstadoCivis = Enum.GetValues(typeof(EstadoCivil)).Cast<EstadoCivil>().ToList();

            var model = new PacienteViewModel()
            {
                Atendimentos = atendimentos,
                ListaEstadoCivil = EstadoCivis,
                ListaSexos = Sexos
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Create(Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                var atendimentos = _atendimentoRepository.GetAll();
                var Sexos = Enum.GetValues(typeof(Sexo)).Cast<Sexo>().ToList();
                var EstadoCivis = Enum.GetValues(typeof(EstadoCivil)).Cast<EstadoCivil>().ToList();

                var model = new PacienteViewModel()
                {
                    Atendimentos = atendimentos,
                    ListaEstadoCivil = EstadoCivis,
                    ListaSexos = Sexos
                };
                return View(model);
            }

            await _pacienteRepository.Save(paciente);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var atendimentos = _atendimentoRepository.GetAll();
            var Sexos = Enum.GetValues(typeof(Sexo)).Cast<Sexo>().ToList();
            var EstadoCivis = Enum.GetValues(typeof(EstadoCivil)).Cast<EstadoCivil>().ToList();

            if (id == null)
            {
                ModelState.AddModelError("", "Id nulo.");
                return RedirectToAction("Index");
            }

            var paciente = await _pacienteRepository.GetById((int)id);
            if(paciente == null)
            {
                ModelState.AddModelError("", "Paciente não encontrado.");
                return RedirectToAction("Index");
            }

            var model = new PacienteViewModel()
            {
                Paciente = paciente,
                Atendimentos = atendimentos,
                ListaEstadoCivil = EstadoCivis,
                ListaSexos = Sexos
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                

                var pac = await _pacienteRepository.GetById(id);
                var atendimentos = _atendimentoRepository.GetAll();
                var Sexos = Enum.GetValues(typeof(Sexo)).Cast<Sexo>().ToList();
                var EstadoCivis = Enum.GetValues(typeof(EstadoCivil)).Cast<EstadoCivil>().ToList();

                var model = new PacienteViewModel()
                {
                    Paciente = pac,
                    Atendimentos = atendimentos,
                    ListaEstadoCivil = EstadoCivis,
                    ListaSexos = Sexos
                };

                if (id != paciente.Id)
                {
                    ModelState.AddModelError("", "Keys Inválidas!");
                    return View(model);
                }

                ModelState.AddModelError("", "Informações inválidas!");
                return View(model);
            }
            try
            {
                await _pacienteRepository.Update(paciente);
                return RedirectToAction("Index");
            }
            catch (DbUpdateConcurrencyException e)
            {
                return NotFound(e.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("", "Id Inválido!");
                return RedirectToAction("Index");
            }
            var paciente = await _pacienteRepository.GetById((int)id);
            if (paciente == null)
            {
                ModelState.AddModelError("", "Paciente Inválido!");
                return RedirectToAction("Index");
            }

            return View(paciente);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("", "Id nulo.");
                return RedirectToAction("Index");
            }

            var atendimentos = _atendimentoRepository.GetAll();
            var Sexos = Enum.GetValues(typeof(Sexo)).Cast<Sexo>().ToList();
            var EstadoCivis = Enum.GetValues(typeof(EstadoCivil)).Cast<EstadoCivil>().ToList();


            var paciente = await _pacienteRepository.GetById((int)id);
            if (paciente == null)
            {
                ModelState.AddModelError("", "Paciente não encontrado.");
                return RedirectToAction("Index");
            }

            var model = new PacienteViewModel()
            {
                Paciente = paciente,
                Atendimentos = atendimentos,
                ListaEstadoCivil = EstadoCivis,
                ListaSexos = Sexos
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var paciente = await _pacienteRepository.GetById(id);
            if (paciente == null)
            {
                var atendimentos = _atendimentoRepository.GetAll();
                var Sexos = Enum.GetValues(typeof(Sexo)).Cast<Sexo>().ToList();
                var EstadoCivis = Enum.GetValues(typeof(EstadoCivil)).Cast<EstadoCivil>().ToList();

                var model = new PacienteViewModel()
                {
                    Paciente = paciente,
                    Atendimentos = atendimentos,
                    ListaEstadoCivil = EstadoCivis,
                    ListaSexos = Sexos
                };

                ModelState.AddModelError("", "Informações inválidas!");
                return View(model);
            }
            try
            {
                await _pacienteRepository.Remove(paciente);
                return RedirectToAction("Index");
            }
            catch (DbUpdateConcurrencyException e)
            {
                return NotFound(e.Message);
            }

        }

    }
}
