using PacientesAtendimentos.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PacientesAtendimentos.Models.ViewModel
{
    public class PacienteViewModel
    {
        public Paciente Paciente { get; set; }
        public IList<Atendimento> Atendimentos { get; set; }
        public IList<Sexo> ListaSexos { get; set; }
        public IList<EstadoCivil> ListaEstadoCivil{ get; set; }

        public PacienteViewModel()
        {

        }
    }
}
