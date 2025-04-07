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

    public class MarkdownFormatter : ContatoFormatter
    {
        public override void ExibirContatos(List<Contato> contatos)
        {
            Console.WriteLine("## Lista de Contatos\n");

            foreach (var contato in contatos)
            {
                Console.WriteLine($"- **Nome:** {contato.Nome}");
                Console.WriteLine($"- 📞 Telefone: {contato.Telefone}");
                Console.WriteLine($"- 📧 Email: {contato.Email}\n");
            }
        }
    }

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

    public class RawTextFormatter : ContatoFormatter
    {
        public override void ExibirContatos(List<Contato> contatos)
        {
            foreach (var contato in contatos)
            {
                Console.WriteLine($"Nome: {contato.Nome} | Telefone: {contato.Telefone} | Email: {contato.Email}");
            }
        }
    }

    public class ContatoRepositorio
    {
        private const string ArquivoContatos = "contatos.txt";

        public void Adicionar(Contato contato)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(ArquivoContatos, true))
                {
                    sw.WriteLine(contato.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar contato: {ex.Message}");
            }
        }

        public List<Contato> ListarTodos()
        {
            var contatos = new List<Contato>();

            if (!File.Exists(ArquivoContatos))
            {
                return contatos;
            }

            try
            {
                using (StreamReader sr = new StreamReader(ArquivoContatos))
                {
                    string linha;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(linha))
                        {
                            contatos.Add(Contato.FromString(linha));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler contatos: {ex.Message}");
            }

            return contatos;
        }
    }
    public class ContatoServico
    {
        private readonly ContatoRepositorio _repositorio;

        public ContatoServico()
        {
            _repositorio = new ContatoRepositorio();
        }

        public void AdicionarContato()
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            var contato = new Contato
            {
                Nome = nome,
                Telefone = telefone,
                Email = email
            };

            _repositorio.Adicionar(contato);
            Console.WriteLine("Contato cadastrado com sucesso!\n");
        }

        public void ListarContatos(int formato)
        {
            var contatos = _repositorio.ListarTodos();

            if (contatos.Count == 0)
            {
                Console.WriteLine("Nenhum contato cadastrado.\n");
                return;
            }

            ContatoFormatter formatter;
            switch (formato)
            {
                case 1:
                    formatter = new MarkdownFormatter();
                    break;
                case 2:
                    formatter = new TabelaFormatter();
                    break;
                case 3:
                    formatter = new RawTextFormatter();
                    break;
                default:
                    formatter = new RawTextFormatter();
                    break;
            }

            formatter.ExibirContatos(contatos);
            Console.WriteLine();
        }
    }
}
