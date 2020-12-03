using Microsoft.EntityFrameworkCore;
using PacientesAtendimentos.Data;
using PacientesAtendimentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PacientesAtendimentos.Repositories
{
    public class AtendimentoRepository : IAtendimentoRepository
    {
        private readonly DataContext _context;

        public AtendimentoRepository(DataContext context)
        {
            _context = context;
        }

        public List<Atendimento> GetAll()
        {
            return _context.Atendimentos.Include(p => p.Paciente).ToList();
        }

        public Atendimento GetById(int id)
        {
            return _context.Atendimentos.Where(p => p.Id == id).Include(p => p.Paciente).FirstOrDefault();
        }

        public void Save(Atendimento atendimento)
        {
            _context.Add(atendimento);
            _context.SaveChanges();
        }

        public void Remove(Atendimento atendimento)
        {
            _context.Remove(atendimento);
            _context.SaveChanges();
        }

        public void Update(Atendimento atendimento)
        {
            var atendimentoDB = GetById(atendimento.Id);

            if (atendimentoDB == null)
                throw new ArgumentNullException("Paciente não encontrado!");

            atendimentoDB.Data = atendimento.Data;
            atendimentoDB.Valor = atendimento.Valor;
            atendimentoDB.PacienteId = atendimento.PacienteId;

            _context.Update(atendimentoDB);
            _context.SaveChanges();
        }

    }
}
