using System;
using System.ComponentModel.DataAnnotations;

namespace PacientesAtendimentos.Models
{
    public class Atendimento
    {
        public int Id { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        [Display(Name = "Valor da Sessão")]
        public decimal Valor { get; set; }
        [Required]
        public Paciente Paciente { get; set; }
        public int PacienteId { get; set; }

        public Atendimento()
        {       
        }

        public Atendimento(DateTime data, decimal valor)
        {
            Data = data;
            Valor = valor;
        }
    }
}