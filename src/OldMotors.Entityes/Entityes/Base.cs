using System.ComponentModel.DataAnnotations;
using OldMotors.Entityes.Notification;

namespace OldMotors.Entityes.Entityes
{
    public class Base : Notifiers
    {
        [Display(Name = "Codigo")]
        public int Id { get; set; }
        [Display(Name = "Nome")]
        public string Nome { get; set; }

    }
}
