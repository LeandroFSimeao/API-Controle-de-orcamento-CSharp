using System;
using System.ComponentModel.DataAnnotations;

namespace OrcamentoAPI.Models
{
    public class Receita
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O campo valor é obrigatório")]
        public double Valor { get; set; }
        [Required(ErrorMessage = "O campo data é obrigatório")]
        public DateTime Data { get; set; }

    }
}
