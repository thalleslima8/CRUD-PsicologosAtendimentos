using Microsoft.EntityFrameworkCore;
using PacientesAtendimentos.Data;
using PacientesAtendimentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PacientesAtendimentos.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly DataContext _context;

        public PacienteRepository(DataContext context)
        {
            _context = context;
        }

        public List<Paciente> GetAll()
        {
            return _context.Pacientes.Include(p => p.Atendimentos).ToList();
        }

        public async Task<Paciente> GetById(int id)
        {
            return await _context.Pacientes.Where(p => p.Id == id).Include(p => p.Atendimentos).FirstOrDefaultAsync();
            
        }

        public async Task Save(Paciente paciente)
        {
           _context.Add(paciente);
           await _context.SaveChangesAsync();
        }

        public async Task Remove(Paciente paciente)
        {
            _context.Remove(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Paciente paciente)
        {
            var pacienteDb = await GetById(paciente.Id);

            if (pacienteDb == null)
                throw new ArgumentNullException("Paciente não encontrado!");

            pacienteDb.Nome = paciente.Nome;
            pacienteDb.DataNascimento = paciente.DataNascimento;
            pacienteDb.Email = paciente.Email;
            pacienteDb.Profissao = paciente.Profissao;
            pacienteDb.Sexo = paciente.Sexo;
            pacienteDb.EstadoCivil = paciente.EstadoCivil;
            pacienteDb.Telefone = paciente.Telefone;
            pacienteDb.Contato = paciente.Contato;
            pacienteDb.DataNascimento = paciente.DataNascimento;
            pacienteDb.Atendimentos = paciente.Atendimentos;

            _context.Update(pacienteDb);
            await _context.SaveChangesAsync();
        }

        public List<Atendimento> GetAtendimentos(int id)
        {
            return _context.Atendimentos.Where(p => p.Paciente.Id == id).OrderBy(p => p.Data).ToList();
        }
    }
}
