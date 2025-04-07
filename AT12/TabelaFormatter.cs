using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT12
{
    public class TabelaFormatter : ContatoFormatter
    {
        public override void ExibirContatos(List<Contato> contatos)
        {
            int nomeWidth = Math.Max(contatos.Max(c => c.Nome.Length), "Nome".Length) + 2;
            int telefoneWidth = Math.Max(contatos.Max(c => c.Telefone.Length), "Telefone".Length) + 2;
            int emailWidth = Math.Max(contatos.Max(c => c.Email.Length), "Email".Length) + 2;

            string linhaSeparadora = new string('-', nomeWidth + telefoneWidth + emailWidth + 4);

            Console.WriteLine(linhaSeparadora);
            Console.WriteLine($"| {"Nome".PadRight(nomeWidth)}| {"Telefone".PadRight(telefoneWidth)}| {"Email".PadRight(emailWidth)}|");
            Console.WriteLine(linhaSeparadora);

            foreach (var contato in contatos)
            {
                Console.WriteLine($"| {contato.Nome.PadRight(nomeWidth)}| {contato.Telefone.PadRight(telefoneWidth)}| {contato.Email.PadRight(emailWidth)}|");
            }

            Console.WriteLine(linhaSeparadora);
        }
    }
}
