using PacientesAtendimentos.Models;
using System.Collections.Generic;

namespace PacientesAtendimentos.Repositories
{
    public interface IAtendimentoRepository
    {
        List<Atendimento> GetAll();
        Atendimento GetById(int id);
        void Remove(Atendimento atendimento);
        void Save(Atendimento atendimento);
        void Update(Atendimento atendimento);
    }
}