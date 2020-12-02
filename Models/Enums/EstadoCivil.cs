using System.ComponentModel.DataAnnotations;

namespace PacientesAtendimentos.Models.Enums
{
    public enum EstadoCivil
    {
        Solteiro,
        Casado,
        [Display(Name = "União Estável")]
        UniaoEstavel,
        Divorciado,
        Viuvo
    }
}
