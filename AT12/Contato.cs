using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT12
{
    public class Contato
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{Nome},{Telefone},{Email}";
        }

        public static Contato FromString(string linha)
        {
            var partes = linha.Split(',');
            return new Contato
            {
                Nome = partes[0],
                Telefone = partes[1],
                Email = partes[2]
            };
        }
    }
    public abstract class ContatoFormatter
    {
        public abstract void ExibirContatos(List<Contato> contatos);
    }
}
