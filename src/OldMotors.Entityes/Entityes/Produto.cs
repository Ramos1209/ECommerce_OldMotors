using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OldMotors.Entityes.Notification;

namespace OldMotors.Entityes.Entityes
{
   public class Produto: Notifiers
    {
        public int Id { get; set; }
        [MaxLength(1250)]
        public string Nome { get; set; }
        [MaxLength(120)]
        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        [MaxLength(2000)]
        public string Observacao { get; set; }

        public int QuantidadeEstoque { get; set; }

        [Display(Name = "Usuario")]
        [ForeignKey("ApplicationUser")]
        [Column(Order = 1)]
        public string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public bool Estado { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
