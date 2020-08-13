using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OldMotors.Entityes.Notification
{
    public class Notifiers
    {
        public Notifiers()
        {
            Notificacoes = new List<Notifiers>();
        }

        [NotMapped] public string NomePropriedade { get; set; }
        [NotMapped] public string Mensagem { get; set; }
        [NotMapped] public List<Notifiers> Notificacoes { get; set; }


        public bool ValidarPropriedadeString(string valor, string nomePropriedade)
        {
            if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notificacoes.Add(new Notifiers
                {
                    Mensagem = "O Campo e Obrigatório",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }

            return true;
        }

        public bool ValidarPropriedadeInt(int valor, string nomePropriedade)
        {
            if (valor < 1 || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notificacoes.Add(new Notifiers
                {
                    Mensagem = "O Valor deve ser maior que 0",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }

            return true;
        }

        public bool ValidarPropriedadeDecimal(decimal valor, string nomePropriedade)
        {
            if (valor < 1 || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notificacoes.Add(new Notifiers
                {
                    Mensagem = "O Valor deve ser maior que 0",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }

            return true;
        }
    }
}

