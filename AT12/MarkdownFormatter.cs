using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT12
{
    public class MarkdownFormatter : ContatoFormatter
    {
        public override void ExibirContatos(List<Contato> contatos)
        {
            Console.WriteLine("## Lista de Contatos\n");

            foreach (var contato in contatos)
            {
                Console.WriteLine($"- Nome: {contato.Nome}");
                Console.WriteLine($"- \u260E Telefone: {contato.Telefone}");
                Console.WriteLine($"- \u2709 Email: {contato.Email}\n");
            }
        }
    }
}
