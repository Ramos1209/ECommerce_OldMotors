using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OldMotors.Entityes.Entityes.Enum;
using OldMotors.Entityes.Notification;

namespace OldMotors.Entityes.Entityes
{
    public class CompraUsuario:Notifiers
    {
        public int Id { get; set; }


        [Display(Name = "Produto")]
        [ForeignKey("Produto")]
        [Column(Order = 1)]
        public int IdProduto { get; set; }
        public virtual Produto Produto { get; set; }

        public EstadoCompra Estado { get; set; }
        [Display(Name = "Quantidade")]
        public int QtdCompra { get; set; }
        [Display(Name = "Usuario")]
        [ForeignKey("ApplicationUser")]
        [Column(Order = 1)]
        public string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
