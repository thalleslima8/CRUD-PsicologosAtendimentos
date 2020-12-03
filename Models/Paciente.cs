using PacientesAtendimentos.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PacientesAtendimentos.Models
{
    public class Paciente
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MinLength(3, ErrorMessage = ("Precisa ter no mínimo 3 caracteres"))]
        public string Nome { get; set; } = "";

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name = "Data de Nasc.")]
        public DateTime DataNascimento { get; set; } = new DateTime();

        [Required(ErrorMessage = "Campo Obrigatório")]
        public Sexo Sexo { get; set; } = Sexo.Outros;

        [Required(ErrorMessage = "Campo Obrigatório")]
        public EstadoCivil EstadoCivil { get; set; } = EstadoCivil.Solteiro;

        [Required(ErrorMessage = "Campo Obrigatório")]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Telefone { get; set; } = "";

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MinLength(3, ErrorMessage =("Precisa ter no mínimo 3 caracteres"))]
        public string Contato { get; set; } = "";

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MinLength(3, ErrorMessage = ("Precisa ter no mínimo 3 caracteres"))]
        public string Profissao { get; set; } = "";

        public List<Atendimento> Atendimentos { get; set; }


        public Paciente()
        {       
        }


    }
}
