using PacientesAtendimentos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PacientesAtendimentos.Repositories
{
    public interface IPacienteRepository
    {
        List<Paciente> GetAll();
        Task<Paciente> GetById(int id);
        Task Remove(Paciente paciente);
        Task Save(Paciente paciente);
        Task Update(Paciente paciente);

        List<Atendimento> GetAtendimentos(int id);
    }
}